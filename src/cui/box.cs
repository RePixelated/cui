using System;
using System.Collections.Generic;

namespace CUI
{
	public class Box : Element
	{
		ConsoleColor color;

		/// Constructors
		public Box(string name, Rect boundary, ConsoleColor color)
		{
			Name = name;
			children = new List<Element>();
			
			// Used temporarly to stop problems when trying to access the parent of the root element
			Parent = new Element();

			this.boundary = boundary;

			this.color = color;
		}

		/// Methods
		public override string Props()
		{
			return
				"name: " + Name +
				" | child of: " + Parent.Name +
				" | rect: " +  boundary.ToString() +
				" | color: " + color.ToString();
		}
	}
}
