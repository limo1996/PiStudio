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
using Android.Content.Res;
using Java.IO;
using Android.Media;
using Android;
using Android.Support.V4.App;
using Android.Content.PM;

namespace PiStudio.Droid
{
	[Activity(Label = "PiStudio.Droid", MainLauncher = true, Theme = "@style/PiStudioTheme")]
	public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
	{
		public static readonly int PICK_IMAGE = 123;
		public static readonly int REQUEST_WRITE_EXTERNAL_STORAGE = 1234;
		private Toolbar m_toolbar;
		private DrawerLayout m_drawerLayout;
		private PiActionBarDrawerToggle m_drawerToggle;

		private MainFragment m_mainFragment;
		private FiltersFragment m_filtersFragment;
		private BrightnessFragment m_brightnessFragment;
		private SupportFragment m_currentFragment;

		private NavigationView m_navigationView;
		private IMenuItem m_previousItem;
		private ImageEditor m_imageEditor;
		private bool m_isDarkTheme = true;

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

			m_navigationView.SetNavigationItemSelectedListener(this);
			m_navigationView.SetCheckedItem(Resource.Id.nav_home);

			m_drawerToggle = new PiActionBarDrawerToggle(this, m_drawerLayout, Resource.String.header, Resource.String.header);
			m_drawerLayout.SetDrawerListener(m_drawerToggle);
			SupportActionBar.SetHomeButtonEnabled(true);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);
			m_drawerToggle.SyncState();
            SetCurrentTheme();
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
			m_currentFragment.Dispose();
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

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions)
		{
			if(requestCode == REQUEST_WRITE_EXTERNAL_STORAGE)
			{
				if(permissions.Length > 0 && permissions[0] == Manifest.Permission.WriteExternalStorage)
                    Save(m_imageEditor, DroidAppResources.Instance.LoadedFile, false);
			}

			base.OnRequestPermissionsResult(requestCode, permissions);
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.piMenu, menu);
			return base.OnCreateOptionsMenu(menu);
		}

		private void CreateMenuItems(string actionItemText, int iconId, string[] otherItems)
		{
			
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			m_drawerToggle.OnOptionsItemSelected(item);

			if (item.ItemId == Resource.Id.action_rotate && m_mainFragment == m_currentFragment)
			{
				item.Icon.SetColorFilter(DroidAppResources.Instance.ApplicationTheme.PanelForeground, PorterDuff.Mode.SrcAtop);
				m_mainFragment.RotateAsync();
				return true;
			}
			else if (item.ItemId == Resource.Id.action_add)
			{
				DroidAppResources.Instance.SetTheme(m_isDarkTheme);
				m_isDarkTheme = !m_isDarkTheme;
				SetCurrentTheme();
			}

			return base.OnOptionsItemSelected(item);
		}

		public bool OnNavigationItemSelected(IMenuItem menuItem)
		{
			System.Diagnostics.Debug.WriteLine(menuItem.ItemId);
			menuItem.SetCheckable(true);
			if (m_previousItem == menuItem)
				return true;

			menuItem.SetChecked(true);

			if (m_previousItem != null) {
				m_previousItem.SetChecked(false);
			}
			//m_navigationView.SetCheckedItem(menuItem.ItemId);
			m_drawerLayout.CloseDrawers();
			m_previousItem = menuItem;

			//navigate according to selected item
			switch (menuItem.ItemId)
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
					m_brightnessFragment = new BrightnessFragment(this, m_imageEditor);
					ReplaceFragment(m_brightnessFragment);
					break;
				case Resource.Id.nav_draw:
					break;
				case Resource.Id.nav_save:
					Save(m_imageEditor, DroidAppResources.Instance.LoadedFile);
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
			return true;
		}

		//sets current application theme to all application components except fragments
		private void SetCurrentTheme()
		{
			m_navigationView.SetBackgroundColor(DroidAppResources.Instance.ApplicationTheme.PanelBackground);
			m_toolbar.SetBackgroundColor(DroidAppResources.Instance.ApplicationTheme.UpperPanelBackground);
			int[][] states = new int[][] {
				new int[] { Android.Resource.Attribute.StateEnabled }, // enabled
				new int[] { -Android.Resource.Attribute.StateEnabled }, // disabled
				new int[] { Android.Resource.Attribute.StatePressed}, // unchecked
    			new int[] { Android.Resource.Attribute.StatePressed}  // pressed
				};

			int[] colors = new int[] {
					DroidAppResources.Instance.ApplicationTheme.PanelForeground,
					Color.Gray,
					DroidAppResources.Instance.ApplicationTheme.PanelItemFocused,
					DroidAppResources.Instance.ApplicationTheme.PanelForeground
				};
			m_navigationView.ItemTextColor = new ColorStateList(states, colors);
			m_navigationView.ItemIconTintList = new ColorStateList(states, colors);

			m_toolbar.SetTitleTextColor(DroidAppResources.Instance.ApplicationTheme.PanelForeground);
			m_toolbar.NavigationIcon.SetColorFilter(DroidAppResources.Instance.ApplicationTheme.PanelForeground, PorterDuff.Mode.SrcAtop);
			m_toolbar.OverflowIcon.SetColorFilter(DroidAppResources.Instance.ApplicationTheme.PanelForeground, PorterDuff.Mode.SrcAtop);

			if (m_toolbar.Menu.Size() > 0)
			{
				var icon = m_toolbar.Menu.FindItem(Resource.Id.action_rotate).Icon;
				icon.SetColorFilter(DroidAppResources.Instance.ApplicationTheme.PanelForeground, PorterDuff.Mode.SrcAtop);
				m_toolbar.Menu.FindItem(Resource.Id.action_rotate).SetIcon(icon);
			}

			Window.SetStatusBarColor(DroidAppResources.Instance.ApplicationTheme.UpperPanelBackground);
		}

		//saves currently edited image and asks for permissions if are not granted
		private async void Save(ISaveable obj, string filename, bool check = true)
		{
			if (check && Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
			{
				if (Permission.Granted != ActivityCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage))
				{
					ActivityCompat.RequestPermissions(this, new string[]{Manifest.Permission.WriteExternalStorage},
                            REQUEST_WRITE_EXTERNAL_STORAGE);
					return;
				}
			}

			System.Diagnostics.Debug.WriteLine("Savingggg");
			var index = filename.LastIndexOf(".", StringComparison.CurrentCultureIgnoreCase);
			var suffix = ".jpg";
            if (index > -1)
                suffix = filename.Substring(index);

			//Create Path to save Image
			File path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures /*+ "/PiStudio"*/); //Creates app specific folder
			path.Mkdirs();

			filename = Guid.NewGuid().ToString() + suffix;
			
			File imageFile = new File(path, filename); // Imagename.png
			var outputStream = new System.IO.FileStream(imageFile.AbsolutePath, System.IO.FileMode.CreateNew);
			try{
				await obj.Save(outputStream, suffix);
				outputStream.Flush();
				outputStream.Close();

				// Tell the media scanner about the new file so that it is
				// immediately available to the user.
				MediaScannerConnection.ScanFile(this, new string[] { imageFile.AbsolutePath }, null, null);
				Toast.MakeText(this, "Image saved", ToastLength.Short).Show();
			} catch(Exception e) {
				Toast.MakeText(this, e.Message, ToastLength.Long).Show();
			}
		}
	}
}