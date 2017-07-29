using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace PiStudio.Droid
{
	/// <summary>
	/// Class that holds references to row view and its children.
	/// </summary>
	public class FilterHolder : RecyclerView.ViewHolder
	{
		/// <summary>
		/// Text view that displays name of the filter
		/// </summary>
		/// <value>The name of the filter.</value>
		public TextView FilterName { get; set; }

		/// <summary>
		/// Image view that displays image with applied filter.
		/// </summary>
		/// <value>The filter image.</value>
		public ImageView FilterImage { get; set; }

		/// <summary>
		/// Parent view. Container for Text and Image View.
		/// </summary>
		/// <value>The view.</value>
		public View View { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:PiStudio.Droid.FilterHolder"/> class.
		/// </summary>
		/// <param name="view">Parent view.</param>
		public FilterHolder(View view) : base(view)
		{
			FilterName = view.FindViewById<TextView>(Resource.Id.filterNameText);
			FilterImage = view.FindViewById<ImageView>(Resource.Id.filterImage);
			View = view;
		}
	}
}
