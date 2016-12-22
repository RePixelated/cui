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
		public static void WriteBlock(Vector position, ConsoleColor color)
		{
			MoveCursor(position);
			SetColors(ForegroundColor, color);

			Console.Write(" ");
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

			if (wordWrapping)
			{
				string[] words = text.Split(' ');

				int i = 0;
				int lineNum = 0;
				int inlinePos = 0;
				bool outOfBounds = false;
				// There are words to be written and the current line isn't out of bounds yet
				while (i < words.Length && !outOfBounds)
				{
					// Not currently on the first character space
					if (inlinePos > 0 &&
							// The next word would either fit completely on the current line
							(words[i].Length + inlinePos + 1 <= area.Width ||
							// or it wouldn't fit in a line of it's own and thus has to flow
							words[i].Length > area.Width))
					{
						// Draw a space
						Console.Write(" ");
						inlinePos++;
					}

					// The word would fit in one line
					if (words[i].Length <= area.Width)
					{
						// The word wouldn't fit in the currently available space
						if (words[i].Length + inlinePos + 1 > area.Width)
						{
							// Jump a line
							lineNum++;
							inlinePos = 0;
							MoveCursor(area.TopLeft + new Vector(0, lineNum));
						}

						// The word wouldn't be out of bounds
						if (lineNum <= area.Height - 1)
						{
							// Write out the word
							Console.Write(words[i]);
							inlinePos += words[i].Length;
						}
						// The word would be out of bounds
						else
							outOfBounds = true;
					}
					// The word wouldn't fit in one line
					else
					{
						int charsIn = 0;
						int segmentLength = 0;
						// There are segments to be written and the current line isn't out of bounds yet
						while (charsIn < words[i].Length && !outOfBounds)
						{
							// Calculate the maximum possible segment length in the current line
							segmentLength = words[i].Length - charsIn;
							segmentLength = segmentLength > area.Width - inlinePos ? area.Width - inlinePos : segmentLength;

							// Write out the segment
							Console.Write(words[i].Substring(charsIn, segmentLength));
							charsIn += segmentLength;

							// There are still segments to be written
							if (charsIn < words[i].Length)
							{
								// The segment wouldn't be out of bounds
								if (lineNum + 1 <= area.Height - 1)
								{
									// Jump a line
									lineNum++;
									inlinePos = 0;
									MoveCursor(area.TopLeft + new Vector(0, lineNum));
								}
								// The segment would be out of bounds
								else
									outOfBounds = true;
							}
						}
						// Set the inline position counter after the last written segment
						inlinePos = segmentLength;
					}

					// Go to the next word
					i++;
				}
			}
			else
			{
				int lineNum = 0;
				int charsIn = 0;
				bool outOfBounds = false;
				// There are segments to be written and the current line isn't out of bounds yet
				while (charsIn < text.Length && !outOfBounds)
				{
					// Calculate the maximum possible segment length in the current line
					int segmentLength = text.Length - charsIn;
					segmentLength = segmentLength > area.Width ? area.Width : segmentLength;

					// Write out the segment
					Console.Write(text.Substring(charsIn, segmentLength));
					charsIn += segmentLength;

					// There are still segments to be written
					if (charsIn < text.Length)
					{
						// The segment wouldn't be out of bounds
						if (lineNum + 1 <= area.Height - 1)
						{
							// Jump a line
							lineNum++;
							MoveCursor(area.TopLeft + new Vector(0, lineNum));
						}
						// The segment would be out of bounds
						else
							outOfBounds = true;
					}
				}
			}
		}
	}
}
