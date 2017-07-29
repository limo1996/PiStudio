using System;
using System.Linq;
using System.Collections.Generic;

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Graphics;
using Android.Provider;
using Android.Views;

using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;

using Toolbar = Android.Support.V7.Widget.Toolbar;
using SupportFragment = Android.Support.V4.App.Fragment;

using PiStudio.Shared;

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
		private FiltersFragment m_filtersFragment;
		private SupportFragment m_currentFragment;

		private NavigationView m_navigationView;
		private ImageEditor m_imageEditor;


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
			m_mainFragment = new MainFragment(this, m_imageEditor, OnImageChanged);
			m_filtersFragment = new FiltersFragment(this, m_imageEditor);

			//trans.Add(Resource.Id.pageViewer, m_filtersFragment, "FiltersFragment");
			trans.Add(Resource.Id.pageViewer, m_mainFragment, "MainFragment");
			m_currentFragment = m_mainFragment;

			trans.Commit();

			//initializes drawer menu
			m_drawerLayout = FindViewById<DrawerLayout>(Resource.Id.piDrawerLayout);
			m_navigationView = FindViewById<NavigationView>(Resource.Id.navigationMenu);

			m_navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;
			m_navigationView.SetCheckedItem(Resource.Id.nav_home);
			m_navigationView.SetCheckedItem(Resource.Id.nav_draw);

			m_drawerToggle = new PiActionBarDrawerToggle(this, m_drawerLayout, Resource.String.header, Resource.String.header);
			m_drawerLayout.SetDrawerListener(m_drawerToggle);
			SupportActionBar.SetHomeButtonEnabled(true);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);
			m_drawerToggle.SyncState();
		}

		//invokes when new image in main fragment is loaded.
		private void OnImageChanged(ImageEditor newEditor)
		{
			m_imageEditor = newEditor;
		}

		//show but do not destroy fragment
		private void ShowFragment(SupportFragment fragment)
		{
			if (fragment == m_currentFragment)
				return;
			
			var trans = SupportFragmentManager.BeginTransaction();

			trans.Hide(m_currentFragment);
			trans.Show(fragment);
			trans.AddToBackStack(null);

			m_currentFragment = fragment;

			trans.Commit();
		}

		//replace current fragment with fragment passed as parameter
		private void ReplaceFragment(SupportFragment fragment)
		{
			if (fragment.IsVisible)
				return;

			var trans = SupportFragmentManager.BeginTransaction();
			trans.Replace(Resource.Id.pageViewer, fragment);
			trans.AddToBackStack(null);

			trans.Commit();
			m_currentFragment = fragment;
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			System.Diagnostics.Debug.WriteLine(requestCode);
			if (requestCode == PICK_IMAGE && resultCode != Result.Canceled)
			{
				//provide data to main fragment if is active
				if (m_currentFragment == m_mainFragment)
				{
					Android.Net.Uri uri = data.Data;
					m_mainFragment.OnImagePicked(uri);
				}
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

			if (item.ItemId == Resource.Id.action_rotate && m_mainFragment == m_currentFragment)
			{
				m_mainFragment.RotateAsync();
				return true;
			}

			return base.OnOptionsItemSelected(item);
		}

		private void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
		{
			//navigate according to selected item
			switch (e.MenuItem.ItemId)
			{
				case Resource.Id.nav_home:
					m_mainFragment = new MainFragment(this, m_imageEditor, OnImageChanged);
					ReplaceFragment(m_mainFragment);
					break;
				case Resource.Id.nav_filters:
					m_filtersFragment = new FiltersFragment(this, m_imageEditor);
					ReplaceFragment(m_filtersFragment);
					break;
				case Resource.Id.nav_brightness:
					break;
				case Resource.Id.nav_draw:
					break;
				case Resource.Id.nav_save:
					break;
				case Resource.Id.nav_share:
					break;
				case Resource.Id.nav_speak:
					break;
				case Resource.Id.nav_settings:
					break;
				case Resource.Id.nav_about:
					break;
			}
		}
	}
}

