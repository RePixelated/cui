namespace CUI
{
	public struct Vector
	{
		public int x;
		public int y;

		public Vector(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public static Vector zero
		{
			get
			{
				return new Vector(0, 0);
			}
		}
		public static Vector up
		{
			get
			{
				return new Vector(0, -1);
			}
		}
		public static Vector down
		{
			get
			{
				return new Vector(0, 1);
			}
		}
		public static Vector left
		{
			get
			{
				return new Vector(-1, 0);
			}
		}
		public static Vector right
		{
			get
			{
				return new Vector(1, 0);
			}
		}

		public static Vector operator +(Vector a, Vector b)
		{
			return new Vector(a.x + b.x, a.y + b.y);
		}
		public static Vector operator -(Vector a, Vector b)
		{
			return new Vector(a.x - b.x, a.y - b.y);
		}
		public static Vector operator *(Vector a, int d)
		{
			return new Vector(a.x * d, a.y * d);
		}
		public static Vector operator /(Vector a, int d)
		{
			return new Vector(a.x / d, a.y / d);
		}
	}
}
