
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace PiStudio.Droid
{
	/// <summary>
	/// View for the brightness page that applies brightness to image.
	/// </summary>
	public class BrightnessFragment : Android.Support.V4.App.Fragment
	{
		private AppCompatActivity m_parentActivity;
		private ImageEditor m_imageEditor;
		private ImageView m_imageContent;
		private StartPointSeekBar m_seekBar;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:PiStudio.Droid.BrightnessFragment"/> class.
		/// </summary>
		/// <param name="parentActivity">Parent activity.</param>
		public BrightnessFragment(AppCompatActivity parentActivity, ImageEditor editor)
		{
			m_parentActivity = parentActivity;
			m_imageEditor = editor;
		}

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		//inflate layout and get reference to image and seek bar.
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.BrightnessFragment, container, false);
			m_imageContent = view.FindViewById<ImageView>(Resource.Id.ImageContent3);
			m_seekBar = view.FindViewById<StartPointSeekBar>(Resource.Id.brightnessSlider);
			System.Diagnostics.Debug.WriteLine("Created");
			if (m_imageEditor != null)
			{
				m_imageContent.SetImageBitmap(m_imageEditor.WorkingImage);
				m_seekBar.Progress = (100 - m_imageEditor.Brightness) / 2;
			}

			m_seekBar.ProgressChanged += M_SeekBar_ProgressChanged;
			return view;
		}

		//invoked when user change the value of seekbar.
		private void M_SeekBar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
		{
			if (m_imageEditor != null)
			{
				Task.Run(async() =>
				{
					m_imageContent.SetImageBitmap(await m_imageEditor.ApplyBrightnessAsync(100 - (e.Progress * 2)));
				});
			}
		}
	}
}
