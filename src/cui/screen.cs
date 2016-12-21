using System;
using System.Collections.Generic;

namespace CUI
{
	public class Screen
	{
		List<Element> objects;

		/// Properties
		public int ObjectCount
		{
			get
			{
				return objects.Count;
			}
		}

		// Anchor Points
		// Top
		public Vector TopLeft
		{
			get
			{
				return new Vector(0, 0);
			}
		}
		public Vector TopCenter
		{
			get
			{
				return new Vector((Width - 1) / 2, 0);
			}
		}
		public Vector TopRight
		{
			get
			{
				return new Vector(Width - 1, 0);
			}
		}
		// Center
		public Vector CenterLeft
		{
			get
			{
				return new Vector(0, (Height - 1) / 2);
			}
		}
		public Vector Center
		{
			get
			{
				return new Vector((Width - 1) / 2, (Height - 1) / 2);
			}
		}
		public Vector CenterRight
		{
			get
			{
				return new Vector(Width - 1, (Height - 1) / 2);
			}
		}
		// Bottom
		public Vector BottomLeft
		{
			get
			{
				return new Vector(0, Height - 1);
			}
		}
		public Vector BottomCenter
		{
			get
			{
				return new Vector((Width - 1) / 2, Height - 1);
			}
		}
		public Vector BottomRight
		{
			get
			{
				return new Vector(Width - 1, Height - 1);
			}
		}

		public int Width
		{
			get
			{
				return Console.WindowWidth;
			}
		}
		public int Height
		{
			get
			{
				return Console.WindowHeight;
			}
		}
	}
}
