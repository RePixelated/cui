using System.Collections.Generic;

namespace CUI
{
	public class Element
	{
		string name;
		protected List<Element> children;
		Element parent;

		protected Rect boundary;

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
		public Element Child(string name)
		{
			int i = 0;
			while (i < children.Count && children[i].Name != name)
				i++;

			if (i < children.Count)
				return children[i];
			return null;
		}

		public virtual string Props()
		{
			return "Not implemented";
		}
	}
}
