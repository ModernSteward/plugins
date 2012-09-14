using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModernSteward
{
	class Program
	{
		[STAThread]
		public static void Main()
		{
			CustomPlugin plugin = new CustomPlugin();
			plugin.Initialize();
		}
	}
}
