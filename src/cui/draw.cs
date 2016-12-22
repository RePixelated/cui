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
		public static void WriteArea(string text, Rect area, ConsoleColor fgColor, ConsoleColor bgColor, TextAlignment textAlign = TextAlignment.Left, bool wordWrapping = true)
		{
			MoveCursor(area.TopLeft);
			SetColors(fgColor, bgColor);

			if (wordWrapping)
			{
				string[] words = text.Split(' ');

				int wordNum = 0;
				int lineNum = 0;
				string line = "";
				bool outOfBounds = false;
				// There are words to be written and the current line isn't out of bounds yet
				while (wordNum < words.Length && !outOfBounds)
				{
					// Not currently on the first character space
					if (line.Length > 0 &&
							// The next word would either fit completely on the current line
							(words[wordNum].Length + line.Length + 1 <= area.Width ||
							// or it wouldn't fit in a line of it's own and thus has to flow
							words[wordNum].Length > area.Width))
					{
						// Add a space to the current line
						line += " ";
					}

					// The word would fit in one line
					if (words[wordNum].Length <= area.Width)
					{
						// The word wouldn't fit in the currently available space
						if (words[wordNum].Length + line.Length + 1 > area.Width)
						{
							// Format the current line
							if (textAlign == TextAlignment.Center)
							{
								line = line.PadLeft((area.Width - line.Length) / 2 + line.Length);
								line = line.PadRight(area.Width);
							}
							else if (textAlign == TextAlignment.Right)
								line = line.PadLeft(area.Width);

							// Write out the current line
							Console.Write(line);

							// Jump a line
							lineNum++;
							MoveCursor(area.TopLeft + new Vector(0, lineNum));
							line = "";
						}

						// The word wouldn't be out of bounds
						if (lineNum <= area.Height - 1)
						{
							// Add the word to the current line
							line += words[wordNum];
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
						while (charsIn < words[wordNum].Length && !outOfBounds)
						{
							// Calculate the maximum possible segment length in the current line
							segmentLength = words[wordNum].Length - charsIn;
							segmentLength = segmentLength > area.Width - line.Length ? area.Width - line.Length : segmentLength;

							// Add the segment to the current line
							line += words[wordNum].Substring(charsIn, segmentLength);
							charsIn += segmentLength;

							// There are still segments to be written
							if (charsIn < words[wordNum].Length)
							{
								// The segment wouldn't be out of bounds
								if (lineNum + 1 <= area.Height - 1)
								{
									// Format the current line
									if (textAlign == TextAlignment.Center)
									{
										line = line.PadLeft((area.Width - line.Length) / 2 + line.Length);
										line = line.PadRight(area.Width);
									}
									
									if (textAlign == TextAlignment.Right)
										line = line.PadLeft(area.Width);

									// Write out the current line
									Console.Write(line);

									// Jump a line
									lineNum++;
									MoveCursor(area.TopLeft + new Vector(0, lineNum));
									line = "";
								}
								// The segment would be out of bounds
								else
									outOfBounds = true;
							}
						}
					}

					// Go to the next word
					wordNum++;
				}

				// There is a line that hasn't reached the end of the line and thus hasn't been written out yet
				if (line.Length > 0)
				{
					// Format the current line
					if (textAlign == TextAlignment.Center)
					{
						line = line.PadLeft((area.Width - line.Length) / 2 + line.Length);
						line = line.PadRight(area.Width);
					}

					if (textAlign == TextAlignment.Right)
						line = line.PadLeft(area.Width);

					// Write out line
					Console.Write(line);
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
