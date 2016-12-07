namespace CUI
{
	public struct Vector
	{
		public int x;
		public int y;

		/// Constructors
		public Vector(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		/// Properties
		public float magnitude
		{
			get
			{
				return Math.Sqrt(this.x * this.x + this.y * this.y);
			}
		}
		public float sqrMagnitude
		{
			get
			{
				return this.x * this.x + this.y * this.y;
			}
		}

		/// Notable Vectors
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

		/// Methods
		public static Vector Scale(Vector a, Vector b)
		{
			return new Vector(a.x * b.x, a.y * b.y);
		}
		public void Scale(Vector other)
		{
			this.x *= other.x;
			this.y *= other.y;
		}

		public static Vector Reverse(Vector a)
		{
			return new Vector(a.x * -1, a.y * -1);
		}
		public void Reverse()
		{
			this.x *= -1;
			this.y *= -1;
		}
		public static Vector ReverseX(Vector a)
		{
			return new Vector(a.x * -1, a.y);
		}
		public void ReverseX()
		{
			this.x *= -1;
		}
		public static Vector ReverseY(Vector a)
		{
			return new Vector(a.x, a.y * -1);
		}
		public void ReverseY()
		{
			this.y *= -1;
		}

		public static Vector Min(Vector a, Vector b)
		{
			return new Vector(Math.Min(a.x, b.x), Math.Min(a.y, b.y));
		}
		public static Vector Max(Vector a, Vector b)
		{
			return new Vector(Math.Max(a.x, b.x), Math.Max(a.y, b.y));
		}

		public static float SqrMagnitude(Vector a)
		{
			return a.x * a.x + a.y * a.y;
		}

		public override bool Equals(object other)
		{
			if (other is Vector)
			{
				Vector vector = (Vector)other;
				return this.x == vector.x && this.y == vector.y;
			}
			return false;
		}
		public override string ToString()
		{
			return "(x:" + x + ", y:" + y + ")";
		}
		public override int GetHashCode()
		{
			return this.x.GetHashCode() ^ this.y.GetHashCode() << 2;
		}

		/// Operators
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
		public static Vector operator *(int d, Vector a)
		{
			return new Vector(d * a.x, d* a.y);
		}
		public static Vector operator /(Vector a, int d)
		{
			return new Vector(a.x / d, a.y / d);
		}
		public static bool operator ==(Vector a, Vector b)
		{
			return Vector.SqrMagnitude(a - b) < 9.99999944E-11f;
		}
		public static bool operator !=(Vector a, Vector b)
		{
			return Vector.SqrMagnitude(a - b) >= 9.99999944E-11f;
		}
	}
}
