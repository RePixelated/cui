using System;
using System.Collections.Generic;

namespace CUI
{
	class Element
	{
		string name;
		List<Element> children;
		Element parent;

		Rect boundary;
		
		/// Constructors
		public Element(string name, Rect boundary)
		{
			this.name = name;
			children = new List<Element>();

			this.boundary = boundary;
		}
		public Element(string name, Vector position, Vector size)
		{
			this.name = name;
			children = new List<Element>();

			this.boundary = new Rect(position, size);
		}
		public Element(string name, int x, int y, int width, int height)
		{
			this.name = name;
			children = new List<Element>();

			this.boundary = new Rect(x, y, width, height);
		}

		/// Properties
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}
		public Element Parent
		{
			get
			{
				return parent;
			}
			set
			{
				parent = value;
			}
		}

		// Anchor Points
		// Top
		public Vector TopLeft
		{
			get
			{
				return boundary.TopLeft;
			}
		}
		public Vector TopCenter
		{
			get
			{
				return boundary.TopCenter;
			}
		}
		public Vector TopRight
		{
			get
			{
				return boundary.TopRight;
			}
		}
		// Center
		public Vector CenterLeft
		{
			get
			{
				return boundary.CenterLeft;
			}
		}
		public Vector Center
		{
			get
			{
				return boundary.Center;
			}
		}
		public Vector CenterRight
		{
			get
			{
				return boundary.CenterRight;
			}
		}
		// Bottom
		public Vector BottomLeft
		{
			get
			{
				return boundary.BottomRight;
			}
		}
		public Vector BottomCenter
		{
			get
			{
				return boundary.BottomCenter;
			}
		}
		public Vector BottomRight
		{
			get
			{
				return boundary.BottomRight;
			}
		}
	
		/// Methods
		public void AddChild(object child)
		{
			if (child is Element)
			{
				Element childElement = (Element)child;
				children.Add(childElement);
				childElement.Parent = this;
			}
		}
		public void RemoveChild(object child)
		{
			if (child != null)
				children.Remove(child as Element);
		}
		public void RemoveChild(string name)
		{
			int i = 0;
			while (i < children.Count && children[i].Name != name)
				i++;

			if (i < children.Count)
				children.RemoveAt(i);
		}
	}
}
