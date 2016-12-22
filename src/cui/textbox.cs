using System;
using CUIInternal;

namespace CUI
{
	public class TextBox : Element
	{
		string text;
		TextAlignment textAlign;
		bool wordWrapping;

		ConsoleColor fgColor;
		ConsoleColor bgColor;

		/// Constructors
		public TextBox(string name, Rect boundary, string text, ConsoleColor fgColor, ConsoleColor bgColor, TextAlignment textAlign = TextAlignment.Left, bool wordWrapping = true)
		{
			Name = name;

			LocalBoundary = boundary;

			this.text = text;
			this.textAlign = textAlign;
			this.wordWrapping = wordWrapping;

			this.fgColor = fgColor;
			this.bgColor = bgColor;
		}

		/// Methods
		public override void Draw()
		{
			for (int i = 0; i < GlobalBoundary.Height; i++)
				for (int j = 0; j < GlobalBoundary.Width; j++)
					Drawing.WriteBlock(GlobalBoundary.TopLeft + new Vector(j, i), bgColor);

			Drawing.WriteArea(text, GlobalBoundary, fgColor, bgColor, textAlign, wordWrapping);
		}
	}
}
