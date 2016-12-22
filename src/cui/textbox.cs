using System;
using System.Collections.Generic;
using CUIInternal;

namespace CUI
{
	public class TextBox : Element
	{
		string text;
		bool wordWrapping;

		ConsoleColor fgColor;
		ConsoleColor bgColor;

		/// Constructors
		public TextBox(string name, Rect boundary, string text, ConsoleColor fgColor, ConsoleColor bgColor, bool wordWrapping = true)
		{
			Name = name;

			LocalBoundary = boundary;

			this.text = text;
			this.wordWrapping = wordWrapping;

			this.fgColor = fgColor;
			this.bgColor = bgColor;
		}

		/// Methods
		public override void Draw()
		{
			for (int i = 0; i < GlobalBoundary.Height; i++)
				for (int j = 0; j < GlobalBoundary.Width; j++)
					Drawing.WriteChar(
							' ',
							GlobalBoundary.TopLeft + new Vector(j, i),
							fgColor, bgColor);

			Drawing.WriteArea(text, GlobalBoundary, fgColor, bgColor, wordWrapping);
		}
	}
}
