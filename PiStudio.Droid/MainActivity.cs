using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Graphics;
using Android.Provider;

using PiStudio.Shared;
using System;
using Android.Support.V7.App;
using System.Collections.Generic;
using Android.Views;
using System.Linq;

using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.Widget;

namespace PiStudio.Droid
{
	[Activity(Label = "PiStudio.Droid", MainLauncher = true, Theme = "@style/PiStudioTheme")]
	public class MainActivity : AppCompatActivity
	{
		public static readonly int PICK_IMAGE = 123;
		private Toolbar m_toolbar;
		private DrawerLayout m_drawerLayout;
		private PiActionBarDrawerToggle m_drawerToggle;
		private MainFragment m_mainFragment;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.MainPage);

			//sets support action bar
			m_toolbar = FindViewById<Toolbar>(Resource.Id.PiStudioToolbar);
			SetSupportActionBar(m_toolbar);
			SupportActionBar.Title = "PiStudio";

			//loads home fragment
			var trans = SupportFragmentManager.BeginTransaction();
			m_mainFragment = new MainFragment(this);
			trans.Add(Resource.Id.pageViewer, m_mainFragment, "MainFragment");
			trans.Commit();

			//initializes drawer menu
			m_drawerLayout = FindViewById<DrawerLayout>(Resource.Id.piDrawerLayout);
			m_drawerToggle = new PiActionBarDrawerToggle(this, m_drawerLayout, Resource.String.header, Resource.String.header);
			m_drawerLayout.SetDrawerListener(m_drawerToggle);
			SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
			m_drawerToggle.SyncState();
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			System.Diagnostics.Debug.WriteLine(requestCode);
			if (requestCode == PICK_IMAGE && resultCode != Result.Canceled)
			{
				//provide data to main fragment if is active

				Android.Net.Uri uri = data.Data;
				m_mainFragment.OnImagePicked(uri);
			}
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.piMenu, menu);
			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			m_drawerToggle.OnOptionsItemSelected(item);

			if (item.ItemId == Resource.Id.action_rotate)
				m_mainFragment.RotateAsync();
			
			return true;
		}
	}
}

