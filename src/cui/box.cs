using System;
using CUIInternal;

namespace CUI
{
	public class Box : Element
	{
		ConsoleColor color;

		/// Constructors
		public Box(string name, Rect boundary, ConsoleColor color)
		{
			Name = name;

			LocalBoundary = boundary;

			this.color = color;
		}

		/// Methods
		public override void Draw()
		{
			for (int i = 0; i < GlobalBoundary.Height; i++)
				for (int j = 0; j < GlobalBoundary.Width; j++)
					Drawing.WriteBlock(GlobalBoundary.TopLeft + new Vector(j, i), color);
		}
	}
}
