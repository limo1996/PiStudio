using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

using Android.Support.V17.Leanback.Widget;
using Android.Support.V7.App;
using System.Threading.Tasks;
using System.Threading;
using PiStudio.Shared.Data;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Graphics.Drawables;

namespace PiStudio.Droid
{
	/// <summary>
	/// View for the filters page that applies filters to image.
	/// </summary>
	public class FiltersFragment : Android.Support.V4.App.Fragment
	{
		private ImageView m_imageContent;
		private RecyclerView m_filtersView;
		private AppCompatActivity m_parentActivity;
		private ImageEditor m_editor;
		private FilterAdapter m_adapter;
		private ProgressBar m_bar;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:PiStudio.Droid.FiltersFragment"/> class.
		/// </summary>
		/// <param name="parentActivity">Parent activity.</param>
		/// <param name="editor">Editor.</param>
		public FiltersFragment(AppCompatActivity parentActivity, ImageEditor editor)
		{
			m_parentActivity = parentActivity;
			m_editor = editor;
		}

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		//inflate layout and get reference to image and filters list.
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.FiltersFragment, container, false);

			//get references
			m_filtersView = view.FindViewById<RecyclerView>(Resource.Id.cardView);
			m_imageContent = view.FindViewById<ImageView>(Resource.Id.ImageContent2);
			m_bar = view.FindViewById<ProgressBar>(Resource.Id.progressFiltersBar);

			//set orientation of recycle view to horizontal
			m_filtersView.HasFixedSize = true;
			LinearLayoutManager layoutManager = new LinearLayoutManager(m_parentActivity);
			layoutManager.Orientation = LinearLayoutManager.Horizontal;

			m_adapter = new FilterAdapter(m_filtersView, FilterSelected);
			m_filtersView.SetAdapter(m_adapter);
			m_filtersView.SetLayoutManager(layoutManager);

			if (m_editor == null)
			{
				m_bar.Visibility = ViewStates.Gone;
				return view;
			}

			//set main image
			m_imageContent.SetImageBitmap(m_editor.WorkingImage);

			return view;
		}

		//starts applying filters and displays them
		public override void OnViewCreated(View view, Bundle savedInstanceState)
		{
			int i = 0;
			m_bar.IndeterminateDrawable.SetColorFilter(DroidAppResources.Instance.ApplicationTheme.PanelItemFocused, PorterDuff.Mode.SrcIn);
			
			//apply all filters and display them in filters view
			foreach (var filter in DroidAppResources.Instance.Filters)
			{
				i++;
				System.Diagnostics.Debug.WriteLine(filter.Filter.Name);
				AddItem(filter, DroidAppResources.Instance.Filters.Count == i);		
			}
				
			base.OnViewCreated(view, savedInstanceState);
		}

		/// <summary>
		/// Invoked when one of the filters is selected (clicked).
		/// </summary>
		/// <param name="item">Selected filter item.</param>
		private void FilterSelected(FilterItem item)
		{
			m_imageContent.Post(
				() =>
			{
				m_imageContent.SetImageBitmap((Bitmap)item.Source);
			});
			var filter = DroidAppResources.Instance.Filters.First(i => i.Filter.Name == item.Text);
			if (filter != null)
			{
				Task.Run(async () => await m_editor.ApplyFilterAsync(filter.Filter));
			}
		}

		//applies provided filter to image and adds it to filters view.
		private void AddItem(FilterSettings filter, bool last)
		{
			Task.Run(() =>
			{
				var item = new FilterItem();
				item.Text = filter.Filter.Name;
				var result = ImageEditor.ApplyFilterThreadSafeAsync(m_editor, filter.Filter);
				item.Source = m_editor.CreateBitmapFromByteArrayAsync(result, (int)m_editor.PixelWidth, (int)m_editor.PixelHeight);

				m_filtersView.Post(() =>
				{
					m_adapter.AddItem(item);
					System.Diagnostics.Debug.WriteLine("View added");
				});

				System.Diagnostics.Debug.WriteLine(Task.CurrentId);
				if (last)
				{
					m_bar.Visibility = ViewStates.Gone;
				}

				System.Diagnostics.Debug.WriteLine(filter.FilterName + " job done");
			});
		}
	}
}
