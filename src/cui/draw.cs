using System;
using CUI;

namespace CUIInternal
{
	public static class Drawing
	{
		/// Properties
		public static ConsoleColor ForegroundColor
		{
			get
			{
				return Console.ForegroundColor;
			}
			set
			{
				Console.ForegroundColor = value;
			}
		}
		public static ConsoleColor BackgroundColor
		{
			get
			{
				return Console.BackgroundColor;
			}
			set
			{
				Console.BackgroundColor = value;
			}
		}

		/// Methods
		public static void MoveCursor(Vector position)
		{
			Console.SetCursorPosition(position.x, position.y);
		}

		public static void SetColors(ConsoleColor fgColor, ConsoleColor bgColor)
		{
			Console.ForegroundColor = fgColor;
			Console.BackgroundColor = bgColor;
		}

		public static void WriteChar(char character, Vector position, ConsoleColor fgColor, ConsoleColor bgColor)
		{
			MoveCursor(position);
			SetColors(fgColor, bgColor);

			Console.Write(character);
		}
		public static void WriteText(string text, Vector position, ConsoleColor fgColor, ConsoleColor bgColor)
		{
			MoveCursor(position);
			SetColors(fgColor, bgColor);

			Console.Write(text);

		}
		public static void WriteArea(string text, Rect area, ConsoleColor fgColor, ConsoleColor bgColor, bool wordWrapping = true)
		{
			MoveCursor(area.TopLeft);
			SetColors(fgColor, bgColor);

			/// TODO:
			/// Implement word-wrapping
			Console.Write(text);
		}
	}
}
