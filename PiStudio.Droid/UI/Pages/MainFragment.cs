using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace PiStudio.Droid
{
	/// <summary>
	/// View for the main page that is able to load new image and rotate it.
	/// </summary>
	public class MainFragment : Android.Support.V4.App.Fragment
	{
		//private fields
		private FloatingActionButton m_openImage;
		private ImageView m_imageContent;
		private AppCompatActivity m_parentActivity;
		private ImageEditor m_imageEditor;
		private Action<ImageEditor> m_onImageChanged;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:PiStudio.Droid.MainFragment"/> class.
		/// </summary>
		/// <param name="parentActivity">Parent activity.</param>
		public MainFragment(AppCompatActivity parentActivity, ImageEditor editor, Action<ImageEditor> onImageChanged)
		{
			m_parentActivity = parentActivity;
			m_imageEditor = editor;
			m_onImageChanged = onImageChanged;
		}

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		//inflate layout and get reference to image and button.
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			var view = inflater.Inflate(Resource.Layout.MainFragment, container, false);

			m_openImage = view.FindViewById<FloatingActionButton>(Resource.Id.OpenImage);
			m_imageContent = view.FindViewById<ImageView>(Resource.Id.ImageContent1);

			if (m_imageEditor != null)
			{
				Task.Run(async () =>
				{
					m_imageContent.SetImageBitmap(await m_imageEditor.ApplyBrightnessAsync(0));
				});
			}
			m_openImage.Click += (sender, e) => OpenImage();
			return view;
		}

		//opens gallery where user can pick image...
		private void OpenImage()
		{
			Intent intent = new Intent();
			intent.SetType("image/*");
			intent.SetAction(Intent.ActionGetContent);
			m_parentActivity.StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), MainActivity.PICK_IMAGE);
		}

		/// <summary>
		/// This method shold be called when user picks image.
		/// </summary>
		/// <param name="uri">URI of image</param>
		public void OnImagePicked(Android.Net.Uri uri)
		{
			Bitmap bitmap = MediaStore.Images.Media.GetBitmap(m_parentActivity.ContentResolver, uri);

			var decoder = new DroidBitmapDecoder(bitmap);
			m_imageEditor = new ImageEditor(decoder, uri.Path);
			m_imageContent.SetImageBitmap(bitmap);
			m_onImageChanged(m_imageEditor);
		}

		/// <summary>
		/// Asynchronously rotates the image.
		/// </summary>
		public async void RotateAsync()
		{
			if (m_imageEditor != null)
			{
				m_imageContent.SetImageBitmap(await m_imageEditor.RotateAsync());
			}
		}
	}
}
