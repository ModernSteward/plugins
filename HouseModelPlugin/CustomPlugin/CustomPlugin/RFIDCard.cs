using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModernSteward
{
	[Serializable]
	public class RFIDCard
	{
		public string Code { get; set; }
		public List<string> Commands;

		public RFIDCard(string aCode, List<string> aCommands)
		{
			Code = aCode;
			Commands = aCommands;
		}

		public RFIDCard(string cardCode)
		{
			Commands = new List<string>();
			Code = cardCode;
		}

		public override string ToString()
		{
			return Code;
		}
	}
}
