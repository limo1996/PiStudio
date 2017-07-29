using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using PiStudio.Shared.Data;

namespace PiStudio.Droid
{
	/// <summary>
	/// Bridge between filter data and filter view.
	/// </summary>
	public class FilterAdapter : RecyclerView.Adapter
	{
		private List<FilterItem> m_filterItems;
		private Action<FilterItem> m_itemClicked;
		private RecyclerView m_recyclerView;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:PiStudio.Droid.FilterAdapter"/> class.
		/// </summary>
		/// <param name="recyclerView">Recycler (filter) view.</param>
		/// <param name="itemClicked">Delegate that should be invoked when filter is selected.</param>
		public FilterAdapter(RecyclerView recyclerView, Action<FilterItem> itemClicked)
		{
			m_filterItems = new List<FilterItem>();
			m_itemClicked = itemClicked;
			m_recyclerView = recyclerView;
		}

		/// <summary>
		/// Gets the filters count.
		/// </summary>
		public override int ItemCount
		{
			get
			{
				return m_filterItems.Count;
			}
		}

		/// <summary>
		/// Adds new filter to view.
		/// </summary>
		/// <param name="item">Item.</param>
		public void AddItem(FilterItem item)
		{
			m_filterItems.Add(item);
			NotifyItemInserted(m_filterItems.Count - 1);
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			var filterHolder = (FilterHolder)holder;
			filterHolder.FilterImage.SetImageBitmap((Bitmap)m_filterItems[position].Source);
			filterHolder.FilterName.Text = m_filterItems[position].Text;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.filter_item, parent, false);
			view.LayoutParameters = new ViewGroup.LayoutParams(150, 250);
			var holder = new FilterHolder(view);
			holder.View.Click += View_Click;
        	return holder;
		}

		//get data of clicked filter and invoke itemClicked delegate.
		private void View_Click(object sender, EventArgs e)
		{
			int position = m_recyclerView.GetChildLayoutPosition((View)sender);
			m_itemClicked(m_filterItems[position]);
		}
	}
}
