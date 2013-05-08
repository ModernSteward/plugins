//source: https://gist.github.com/SamSaffron/101357

// slightly changed by Hristo Stoyanov 2013

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Management;
using System.Net.Sockets;
using System.IO;

/*
 +----[ Remote control commands ]
|
| add XYZ  . . . . . . . . . . . . add XYZ to playlist
| enqueue XYZ  . . . . . . . . . queue XYZ to playlist
| playlist . . . . .  show items currently in playlist
| play . . . . . . . . . . . . . . . . . . play stream
| stop . . . . . . . . . . . . . . . . . . stop stream
| next . . . . . . . . . . . . . .  next playlist item
| prev . . . . . . . . . . . .  previous playlist item
| goto . . . . . . . . . . . . . .  goto item at index
| repeat [on|off] . . . .  toggle playlist item repeat
| loop [on|off] . . . . . . . . . toggle playlist loop
| random [on|off] . . . . . . .  toggle random jumping
| clear . . . . . . . . . . . . . . clear the playlist
| status . . . . . . . . . . . current playlist status
| title [X]  . . . . . . set/get title in current item
| title_n  . . . . . . . .  next title in current item
| title_p  . . . . . .  previous title in current item
| chapter [X]  . . . . set/get chapter in current item
| chapter_n  . . . . . .  next chapter in current item
| chapter_p  . . . .  previous chapter in current item
|
| seek X . . . seek in seconds, for instance `seek 12'
| pause  . . . . . . . . . . . . . . . .  toggle pause
| fastforward  . . . . . . . .  .  set to maximum rate
| rewind  . . . . . . . . . . . .  set to minimum rate
| faster . . . . . . . . . .  faster playing of stream
| slower . . . . . . . . . .  slower playing of stream
| normal . . . . . . . . . .  normal playing of stream
| f [on|off] . . . . . . . . . . . . toggle fullscreen
| info . . . . .  information about the current stream
| stats  . . . . . . . .  show statistical information
| get_time . . seconds elapsed since stream's beginning
| is_playing . . . .  1 if a stream plays, 0 otherwise
| get_title . . . . .  the title of the current stream
| get_length . . . .  the length of the current stream
|
| volume [X] . . . . . . . . . .  set/get audio volume
| volup [X]  . . . . . . .  raise audio volume X steps
| voldown [X]  . . . . . .  lower audio volume X steps
| adev [X] . . . . . . . . . . .  set/get audio device
| achan [X]. . . . . . . . . .  set/get audio channels
| atrack [X] . . . . . . . . . . . set/get audio track
| vtrack [X] . . . . . . . . . . . set/get video track
| vratio [X]  . . . . . . . set/get video aspect ratio
| vcrop [X]  . . . . . . . . . . .  set/get video crop
| vzoom [X]  . . . . . . . . . . .  set/get video zoom
| snapshot . . . . . . . . . . . . take video snapshot
| strack [X] . . . . . . . . . set/get subtitles track
| key [hotkey name] . . . . . .  simulate hotkey press
| menu . . [on|off|up|down|left|right|select] use menu
|
| help . . . . . . . . . . . . . . . this help message
| longhelp . . . . . . . . . . . a longer help message
| logout . . . . . . .  exit (if in socket connection)
| quit . . . . . . . . . . . . . . . . . . .  quit vlc
|
+----[ end of help ]
 
 */
namespace ModernSteward
{

    enum VlcCommand
    {
        Add,
        Enqueue,
        Play,
        Stop,
        F,
        Is_Playing,
        Get_Time,
        Seek,
        Pause,
        FastForward,
        Rewind,
        Quit
    }

    public class VlcRemote
    {
        // maximum 2 second wait on results. 
        const int WaitTimeout = 2000;

        static ASCIIEncoding ASCIIEncoding = new ASCIIEncoding();

        Process vlcProcess;
        TcpClient client;

        static int GetParentProcessId(int Id)
        {
            int parentPid = 0;
            using (ManagementObject mo = new ManagementObject("win32_process.handle='"
            + Id.ToString() + "'"))
            {
                mo.Get();
                parentPid = Convert.ToInt32(mo["ParentProcessId"]);
            }
            return parentPid;
        }


        public VlcRemote()
        {

            string vlcPath = null;
            var vlcKey = Registry.LocalMachine.OpenSubKey(@"Software\VideoLan\VLC");
            if (vlcKey == null)
            {
                vlcKey = Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\VideoLan\VLC");
            }
            if (vlcKey != null)
            {
                vlcPath = vlcKey.GetValue(null) as string;
            }

            if (vlcPath == null)
            {
                throw new ApplicationException("Can not find the VLC executable!");
            }

            var info = new ProcessStartInfo(vlcPath, "-I rc --rc-host=localhost:9876");
            vlcProcess = Process.Start(info);
            client = new TcpClient("localhost", 9876);
        }

        public Process VlcPlaybackProcess
        {
            get
            {
                var currentProcessId = Process.GetCurrentProcess().Id;
                Process vlcProcess = null;
                foreach (var process in Process.GetProcessesByName("vlc"))
                {
                    if (GetParentProcessId(process.Id) == currentProcessId)
                    {
                        vlcProcess = process;
                        break;
                    }
                }
                return vlcProcess;
            }
        }

        public void Add(string filename)
        {
            SendCommand(VlcCommand.Add, filename);
        }

        public void Enqueue(string filename)
        {
            SendCommand(VlcCommand.Enqueue, filename);
        }

        public void Play()
        {
            SendCommand(VlcCommand.Play);
        }

        public void Stop()
        {
            SendCommand(VlcCommand.Stop);
        }

        public void Quit()
        {
            SendCommand(VlcCommand.Quit);
        }

        public void GoToFullScreen()
        {
            SendCommand(VlcCommand.F, "on");
        }

        public bool IsPlaying
        {
            get
            {
                SendCommand(VlcCommand.Is_Playing);
                string result = WaitForResult().Trim();
                return result == "1";
            }
        }

        public int Position
        {
            get
            {
                SendCommand(VlcCommand.Get_Time);
                var result = WaitForResult().Trim();
                return Convert.ToInt32(result);
            }
            set
            {
                SendCommand(VlcCommand.Seek, value.ToString());
            }
        }

        public void FastForward()
        {
            SendCommand(VlcCommand.FastForward);
        }

        public void Rewind()
        {
            SendCommand(VlcCommand.Rewind);
        }

        string WaitForResult()
        {
            string result = "";
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalMilliseconds < WaitTimeout)
            {
                result = ReadTillEnd();
                if (!string.IsNullOrEmpty(result))
                {
                    break;
                }
            }
            return result;
        }

        void SendCommand(VlcCommand command)
        {
            SendCommand(command, null);
        }

        void SendCommand(VlcCommand command, string param)
        {
            // flush old stuff
            ReadTillEnd();

            string packet = Enum.GetName(typeof(VlcCommand), command).ToLower();
            if (param != null)
            {
                packet += " " + param;
            }
            packet += Environment.NewLine;

            var buffer = ASCIIEncoding.GetBytes(packet);
            client.GetStream().Write(buffer, 0, buffer.Length);
            client.GetStream().Flush();


            Trace.Write(packet);

        }

        public string ReadTillEnd()
        {
            StringBuilder sb = new StringBuilder();
            while (client.GetStream().DataAvailable)
            {
                int b = client.GetStream().ReadByte();
                if (b >= 0)
                {
                    sb.Append((char)b);
                }
                else
                {
                    break;
                }
            }
            return sb.ToString();
        }

    }
}