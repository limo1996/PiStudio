using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Widget;

namespace PiStudio.Droid
{
	public class StartPointSeekBar : SeekBar
	{

		private Rect rect;
		private Paint paint;
		private int seekbar_height;

		public StartPointSeekBar(Context context) : base(context)
		{

		}

		public StartPointSeekBar(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			rect = new Rect();
			paint = new Paint();
			seekbar_height = 6;
			ForegroundColor = Color.Black;
			BackgroundColor = Color.Gray;
		}

		public StartPointSeekBar(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
		{
		}

		public Color ForegroundColor { get; set; }
		public Color BackgroundColor { get; set; }
		public Drawable Circle { get; set; }

		protected override void OnDraw(Canvas canvas)
		{
			rect.Set(0 + ThumbOffset,
					(Height / 2) - (seekbar_height / 2),
					Width - ThumbOffset,
					(Height / 2) + (seekbar_height / 2));

			paint.Color = BackgroundColor;
			canvas.DrawRect(rect, paint);
			paint.Color = ForegroundColor;

			if (this.Progress > 50)
			{
				rect.Set(Width / 2,
						(Height / 2) - (seekbar_height / 2),
						Width / 2 + (Width / 100) * (Progress - 50),
						Height / 2 + (seekbar_height / 2));

				canvas.DrawRect(rect, paint);
			}

			if (this.Progress < 50)
			{
				rect.Set(Width / 2 - ((Width / 100) * (50 - Progress)),
						(Height / 2) - (seekbar_height / 2),
						 Width / 2,
						 Height / 2 + (seekbar_height / 2));

				canvas.DrawRect(rect, paint);
			}

			//Circle.Draw(canvas);
			float position = (Width / 100) * Progress;
			canvas.DrawCircle(position + 2 * ThumbOffset, (Height / 2), ThumbOffset - 6, paint);
		}
	}
}