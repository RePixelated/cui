namespace CUI
{
	public struct Rect
	{
		private Vector min;
		private Vector max;

		/// Constructors
		public Rect(int x, int y, int width, int height)
		{
			min = new Vector(x, y);
			max = min + new Vector(width, height);
		}
		public Rect(Vector position, int width, int height)
		{
			min = position;
			max = min + new Vector(width, height);
		}
		public Rect(Vector position, Vector size)
		{
			min = position;
			max = position + size;
		}
		public Rect(Rect other)
		{
			this.min = other.Position;
			this.max = other.Position + other.Size;
		}

		/// Properties
		public Vector Position
		{
			get
			{
				return min;
			}
			set
			{
				max = max + (value - min);
				min = value;
			}
		}
		public Vector Size
		{
			get
			{
				return max - min;
			}
			set
			{
				max = value;
			}
		}
		public int Width
		{
			get
			{
				return max.x - min.x;
			}
			set
			{
				max = new Vector(value, max.y);
			}
		}
		public int Height
		{
			get
			{
				return max.y - min.y;
			}
			set
			{
				max = new Vector(max.x, value);
			}
		}

		public int xMin
		{
			get
			{
				return min.x;
			}
		}
		public int xMax
		{
			get
			{
				return max.x;
			}
		}
		public int yMin
		{
			get
			{
				return min.y;
			}
		}
		public int yMax
		{
			get
			{
				return max.y;
			}
		}

		// Anchor Points
		// Top
		public Vector TopLeft
		{
			get
			{
				return min;
			}
		}
		public Vector TopCenter
		{
			get
			{
				return new Vector(min.x + (max.x / 2), min.y);
			}
		}
		public Vector TopRight
		{
			get
			{
				return new Vector(max.x, min.x);
			}
		}
		// Middle
		public Vector CenterLeft
		{
			get
			{
				return new Vector(min.x, min.y + (max.y / 2));
			}
		}
		public Vector Center
		{
			get
			{
				return new Vector(min.x + (max.x / 2), min.y + (max.y / 2));
			}
		}
		public Vector CenterRight
		{
			get
			{
				return new Vector(max.x, min.y + (max.y / 2));
			}
		}
		// Right
		public Vector BottomLeft
		{
			get
			{
				return new Vector(min.x, max.y);
			}
		}
		public Vector BottomCenter
		{
			get
			{
				return new Vector(min.x + (max.x / 2), max.y);
			}
		}
		public Vector BottomRight
		{
			get
			{
				return max;
			}
		}

		/// Methods
		public bool Contains(Vector point)
		{
			return point.x >= this.min.x && point.x <= this.max.x &&
				point.y >= this.min.y && point.y <= this.max.y;
		}
		public bool Overlaps(Rect other)
		{
			return other.xMax > this.xMin && other.xMin < this.xMax &&
				other.yMax > this.yMin && other.yMin < this.xMax;
		}

		public override bool Equals(object other)
		{
			if (other is Rect)
			{
				Rect rect = (Rect)other;
				return this.xMin == rect.xMin && this.yMax == rect.yMax;
			}
			return false;
		}
		public override string ToString()
		{
			return "(x:" + this.xMin.ToString() + ", y:" + this.yMin.ToString() + 
				", width:" + this.Width.ToString() + ", height:" + this.Height.ToString() + ")";
		}
		public override int GetHashCode()
		{
			return this.xMin.GetHashCode() ^ this.xMax.GetHashCode() << 2 ^
				this.yMin.GetHashCode() >> 2 ^ this.yMax.GetHashCode() >> 1;
		}

		/// Operators
		public static bool operator ==(Rect a, Rect b)
		{
			return a.xMin == b.xMin && a.yMax == b.yMax;
		}
		public static bool operator !=(Rect a, Rect b)
		{
			return a.xMin != b.xMin || a.xMax != b.yMax;
		}
	}
}
