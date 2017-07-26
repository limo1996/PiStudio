using System;
using Android.Support.V4.Widget;
using Android.Support.V7.App;

namespace PiStudio.Droid
{
	public class PiActionBarDrawerToggle : Android.Support.V7.App.ActionBarDrawerToggle
	{
		private AppCompatActivity m_activity;
		private int m_openedResource;
		private int m_closedResource;

		public PiActionBarDrawerToggle(AppCompatActivity activity, DrawerLayout drawerLayout, int openedResource, int closedResource) 
			: base(activity, drawerLayout, openedResource, closedResource)
		{
			m_activity = activity;
			m_openedResource = openedResource;
			m_closedResource = closedResource;
		}

		public override void OnDrawerOpened(Android.Views.View drawerView)
		{
			base.OnDrawerOpened(drawerView);
		}

		public override void OnDrawerClosed(Android.Views.View drawerView)
		{
			base.OnDrawerClosed(drawerView);
		}

		public override void OnDrawerSlide(Android.Views.View drawerView, float slideOffset)
		{
			base.OnDrawerSlide(drawerView, slideOffset);
		}
	}
}
