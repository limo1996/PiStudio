namespace PiStudio.Shared
{
	public struct Rectangle
	{
		public Rectangle(float x, float y, float width, float height)
		{
			this.X = x;
			this.Y = y;
			this.Width = width;
			this.Height = height;
		}

		public float X { get; set; }
		public float Y { get; set; }
		public float Width { get; set; }
		public float Height { get; set; }

		public float Top { get { return Y; } }
		public float Bottom { get { return Y + Height; } }
		public float Left { get { return X; } }
		public float Right { get { return X + Width; } }
	}
}