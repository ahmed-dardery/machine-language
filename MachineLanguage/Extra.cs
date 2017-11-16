using System;
using System.Collections.Generic;
using System.Text;

namespace MachineLanguage
{
	public class Extra
	{
		public static string[] mydescriptions = new string[] {
			"NOTHING. Advance to the next step.",
			"LOAD Register {0} with the content of memory at address {1}{2}.",
			"LOAD Register {0} with bit pattern {1}{2}.",					  
			"STORE the bit pattern of Register {0} in memory at address {1}{2}.",
			"MOVE the bit pattern of Register {1} into Register {2}",
			"ADD the bit patterns of Registers {1} and {2} as if they were integers, and store the result in Register {0}",
			"ADD the bit patterns of Registers {1} and {2} as if they were floating point numbers, and store the result in Register {0}",
			"OR the bit patterns of Registers {1} and {2}, and store the result in Register {0}.",
			"AND the bit patterns of Registers {1} and {2}, and store the result in Register {0}.",
			"XOR the bit patterns of Registers {1} and {2}, and store the result in Register {0}.",
			"ROTATE the bit pattern in Register {0} one bit to the right {2} times.",
			"JUMP to the instruction located in memory at address {1}{2} if the bit pattern in Register {0} matches with the bit pattern in Register 0.",
			"HALT the execution.",				
			"INVALID OPERATION: halts the execution.",
			"INVALID OPERATION: halts the execution.",
			"INVALID OPERATION: halts the execution."
		};

		public static string ToBin(int value, int len)
		{
			return (len > 1 ? ToBin(value >> 1, len - 1) : null) + "01"[value & 1];
		}
		public static string ToHex(int value, int len)
		{
			return (len > 1 ? ToHex(value >> 4, len - 4) : null) + "0123456789ABCDEF"[value & 0xF];
		}

		public static byte FromBin(string str)
		{
			return Convert.ToByte(str, 2);
		}
		public static byte FromHex(string str)
		{
			return Convert.ToByte(str, 16);
		}

		public static bool IsHexable(char chr)
		{
			return (chr >= '0' && chr <= '9') || (chr >= 'A' && chr <= 'F') || (chr >= 'a' && chr <= 'f');
		}
		public static bool IsHexable(string str)
		{
			foreach (char chr in str)
			{
				if (!IsHexable(chr)) return false;
			}
			return true;
		}
		public static bool IsBinable(char chr)
		{
			return (chr == '0' || chr == '1');
		}
		public static bool IsBinable(string str)
		{
			foreach (char chr in str)
			{
				if (!IsBinable(chr)) return false;
			}
			return true;
		}

		public enum errors
		{
			NoError,
			InvalidCharacter,
			Incomplete,
			NotProperCode
		};

		public static errors StringToData(string str, out byte[] result)
		{
			List<byte> mylist = new List<byte>();
			int i = 0;
			char lastchar = ' ';
			for (i = 0; i < str.Length; i++)
			{
				if (str[i] <= ' ') continue;

				if (!IsHexable(str[i]))
				{
					result = null;
					return errors.InvalidCharacter;
				}

				if (lastchar == ' ')
				{
					lastchar = str[i];
				}
				else
				{
					mylist.Add(Extra.FromHex(string.Concat(lastchar, str[i])));
					lastchar = ' ';
				}
			}
			result = mylist.ToArray();
			if (lastchar != ' ') return errors.Incomplete;
			if (mylist.Count % 2 != 0) return errors.NotProperCode; else return errors.NoError;
		}
	}
}
