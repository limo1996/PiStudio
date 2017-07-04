using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Graphics;
using Android.Provider;

using PiStudio.Shared;

namespace PiStudio.Droid
{
	[Activity(Label = "PiStudio.Droid", MainLauncher = true)]
	public class HomeActivity : Activity
	{
		private static readonly int PICK_IMAGE = 123456;
		private Button m_openImage;
		private ImageView m_imageContent;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.HomePage);

			m_openImage = FindViewById<Button>(Resource.Id.OpenImage);
			m_imageContent = FindViewById<ImageView>(Resource.Id.ImageContent);

			m_openImage.Click += (sender, e) => OpenImage();
		}

		protected override async void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			System.Diagnostics.Debug.WriteLine(requestCode);
			if (requestCode == PICK_IMAGE && resultCode != Result.Canceled)
			{
				Android.Net.Uri uri = data.Data;
				Bitmap bitmap = MediaStore.Images.Media.GetBitmap(this.ContentResolver, uri);

				IBitmapDecoder decoder = new DroidBitmapDecoder(bitmap);
				var imageEditor = new ImageEditor(decoder, uri.Path);
				var bit2 = await imageEditor.RotateAsync();

				m_imageContent.SetImageBitmap(bit2);
			}
			base.OnActivityResult(requestCode, resultCode, data);
		}

		private void OpenImage()
		{
			Intent intent = new Intent();
			intent.SetType("image/*");
			intent.SetAction(Intent.ActionGetContent);
			StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), PICK_IMAGE);
		}
	}
}

