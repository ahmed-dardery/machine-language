using System;
using System.Collections.Generic;
using System.Text;

namespace MachineLanguage
{
	public class FloatingNotation
	{
		private byte bits;

		public FloatingNotation() { this.bits = 0; }
		public FloatingNotation(byte bits) { this.bits = bits; }
		public FloatingNotation(float number) { this.bits = FloatToBits(number); }

		public float ToFloat() { return BitsToFloat(bits); }
		public byte ToBits() { return bits; }

		public static FloatingNotation fromBits(byte bits) { return new FloatingNotation(bits); }
		public static FloatingNotation fromFloat(float number) { return new FloatingNotation(number); }

		public static byte FloatToBits(float number)
		{
			bool neg = number < 0;
			if (neg) number = -number;
			if (number >= 7.5) return (byte)(neg ? 0xFF : 0x7F);			//7.5 is the maximum value that can be stored.
			if (number < 0.03125) return 0;					//0.03125 is the minimum non-zero value that can be stored.

			int integer = (int)(number * 256);

			int exp = 0;
			while (integer > 16)
			{
				integer = integer >> 1;
				exp++;
			}

			return (byte)((neg ? 0x80 : 0x00) + (exp << 4) + integer);

		}
		public static float BitsToFloat(byte b)
		{
			return (((b & 0x80) == 0x80) ? -1 : 1) * (b & 0xF) * (float)Math.Pow(2, ((b >> 4) & 7) - 8);
		}


		public static FloatingNotation operator +(FloatingNotation x, FloatingNotation y)
		{
			return new FloatingNotation(x.ToFloat() + y.ToFloat());
		}
		public static FloatingNotation operator -(FloatingNotation x, FloatingNotation y)
		{
			return new FloatingNotation(x.ToFloat() - y.ToFloat());
		}
		public static FloatingNotation operator *(FloatingNotation x, FloatingNotation y)
		{
			return new FloatingNotation(x.ToFloat() * y.ToFloat());
		}
		public static FloatingNotation operator /(FloatingNotation x, FloatingNotation y)
		{
			return new FloatingNotation(x.ToFloat() / y.ToFloat());
		}

	}
}
