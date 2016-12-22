using System.Collections.Generic;

namespace CUI
{
	public class Element
	{
		string name;
		protected List<Element> children = new List<Element>();
		Element parent;

		Rect boundary;

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
		public int ChildCount
		{
			get
			{
				return children.Count;
			}
		}

		public Rect Boundary
		{
			get
			{
				return LocalBoundary;
			}
			set
			{
				LocalBoundary = value;
			}
		}
		public Rect LocalBoundary
		{
			get
			{
				return boundary;
			}
			set
			{
				boundary = value;
			}
		}
		public Rect GlobalBoundary
		{
			get
			{
				if (Parent == null)
					return LocalBoundary;
				return new Rect(Parent.GlobalBoundary.TopLeft, LocalBoundary.BottomRight);
			}
			set
			{
				if (Parent == null)
					LocalBoundary = value;
				LocalBoundary = new Rect(Parent.GlobalBoundary.TopLeft - value.TopLeft, value.BottomRight);
			}
		}

		// Anchor Points
		// Top
		public Vector TopLeft
		{
			get
			{
				return Boundary.TopLeft;
			}
		}
		public Vector TopCenter
		{
			get
			{
				return Boundary.TopCenter;
			}
		}
		public Vector TopRight
		{
			get
			{
				return Boundary.TopRight;
			}
		}
		// Center
		public Vector CenterLeft
		{
			get
			{
				return Boundary.CenterLeft;
			}
		}
		public Vector Center
		{
			get
			{
				return Boundary.Center;
			}
		}
		public Vector CenterRight
		{
			get
			{
				return Boundary.CenterRight;
			}
		}
		// Bottom
		public Vector BottomLeft
		{
			get
			{
				return Boundary.BottomRight;
			}
		}
		public Vector BottomCenter
		{
			get
			{
				return Boundary.BottomCenter;
			}
		}
		public Vector BottomRight
		{
			get
			{
				return Boundary.BottomRight;
			}
		}

		public int Width
		{
			get
			{
				return Boundary.Width;
			}
			set
			{
				Boundary = new Rect(Boundary.TopLeft, value, Boundary.Height);
			}
		}
		public int Height
		{
			get
			{
				return Boundary.Height;
			}
			set
			{
				Boundary = new Rect(Boundary.TopLeft, Boundary.Width, value);
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

		public virtual void Draw() {}
	}
}
