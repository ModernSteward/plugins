using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModernSteward;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            GMailIntegration mail = new GMailIntegration("renegat96@gmail.com", "esdcf878");
            Console.WriteLine("New mails: {0}", mail.NewMessagesCount);
            for (int i = 0;i < mail.Entries.Count; ++i)
            {
                Console.WriteLine("{0} {1} {2}", mail.Entries[i].FromEmail, mail.Entries[i].Id, mail.Entries[i].Link);
            }
            Console.ReadLine();
        }
    }
}