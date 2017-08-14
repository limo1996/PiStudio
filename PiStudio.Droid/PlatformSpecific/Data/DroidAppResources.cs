using System;
using Android.Graphics;
using Java.IO;
using PiStudio.Shared;

namespace PiStudio.Droid
{
	/// <summary>
	/// Class that has only one instance. Contains all resources that app needs during running.
	/// </summary>
	public class DroidAppResources : AppResourcesBase
	{
		//dark theme
		private Theme m_darkTheme = new Theme()
		{
			PanelBackground = new Color(0, 0, 0, 210),
			PanelItemFocused = new Color(209, 52, 56, 255),
			PanelForeground = new Color(255, 255, 255, 255),
			Background = new Color(0, 0, 0, 255),
			Foreground = new Color(255, 255, 255, 255),
			Borders = new Color(31, 31, 31, 255),
			ClickableForeground = new Color(122, 122, 122, 255),
			UpperPanelBackground = new Color(31, 31, 31, 255)
		};

		//light theme
		private Theme m_lightTheme = new Theme()
		{
			Foreground = new Color(0, 0, 0, 255),
			Background = new Color(255, 255, 255, 255),
			PanelForeground = new Color(0, 0, 0, 255),
			PanelBackground = new Color(173, 173, 180, 220),
			PanelItemFocused = new Color(209, 52, 56, 255),
			Borders = new Color(31, 31, 31, 255),
			ClickableForeground = new Color(122, 122, 122, 255),
			UpperPanelBackground = new Color(242, 242, 242, 255)
		};

		private DroidAppResources() : base()
		{
			ApplicationTheme = m_darkTheme;
			FinalStorage = null;
		}

		private static DroidAppResources m_instance;

		/// <summary>
		/// Only instance of <see cref="WinAppResources"/> class.
		/// </summary>
		public static DroidAppResources Instance
		{
			get
			{
				if (m_instance == null)
					m_instance = new DroidAppResources();
				return m_instance;
			}
		}

		/// <summary>
		/// Returns full path of given file name.
		/// </summary>
		public override string GetStoragePath(string file)
		{
			return file;
		}

		private static uint ColorToUint(Color c)
		{
			return unchecked((uint)c.ToArgb());
		}

		private static Color UintToColor(uint c)
		{
			var a = (byte)(c >> 24);
			var r = (byte)(c >> 16);
			var g = (byte)(c >> 8);
			var b = (byte)(c >> 0);
			return new Color(r, g, b, a);
		}

		/// <summary>
		/// Copies application state saved in instance of this class into serializable and cross-platform <see cref="AppSettings"/>
		/// </summary>
		/// <param name="settings">Single instance of <see cref="AppSettings"/>.</param>
		public override void CopyTo(AppSettings settings)
		{
			if (settings == null)
				throw new ArgumentNullException();

			settings.AppLanguage = this.ApplicationLanguage.Language;
			settings.Background = ColorToUint(this.ApplicationTheme.Background);
			settings.Borders = ColorToUint(this.ApplicationTheme.Borders);
			settings.ClickableForeground = ColorToUint(this.ApplicationTheme.ClickableForeground);
			settings.Foreground = ColorToUint(this.ApplicationTheme.Foreground);
			settings.PanelBackground = ColorToUint(this.ApplicationTheme.PanelBackground);
			settings.PanelForeground = ColorToUint(this.ApplicationTheme.PanelForeground);
			settings.PanelItemFocused = ColorToUint(this.ApplicationTheme.PanelItemFocused);
			settings.UpperPanelBackground = ColorToUint(this.ApplicationTheme.UpperPanelBackground);
		}

		/// <summary>
		/// Loads all necessary properties from <see cref="AppSettings"/> instance.
		/// </summary>
		/// <param name="settings"></param>
		public override void LoadFrom(AppSettings settings)
		{
			this.SetLanguage(settings.AppLanguage);
			if (settings.IsPredefinedTheme)
				SetTheme(settings.IsDarkTheme);
			else
			{
				this.ApplicationTheme.Background = UintToColor(settings.Background);
				this.ApplicationTheme.Borders = UintToColor(settings.Borders);
				this.ApplicationTheme.ClickableForeground = UintToColor(settings.ClickableForeground);
				this.ApplicationTheme.Foreground = UintToColor(settings.Foreground);
				this.ApplicationTheme.PanelBackground = UintToColor(settings.PanelBackground);
				this.ApplicationTheme.PanelForeground = UintToColor(settings.PanelForeground);
				this.ApplicationTheme.PanelItemFocused = UintToColor(settings.PanelItemFocused);
				this.ApplicationTheme.UpperPanelBackground = UintToColor(settings.UpperPanelBackground);
			}
		}

		/// <summary>
		/// Gets or sets the application theme.
		/// </summary>
		/// <value>The application theme.</value>
		public Theme ApplicationTheme { get; set; }

		/// <summary>
		/// Location where is and will be final image stored.
		/// </summary>
		public File FinalStorage { get; set; }

		/// <summary>
		/// Sets dark or light theme.
		/// </summary>
		/// <param name="isDarkTheme">Whether to set dark theme. If not then light theme is set.</param>
		public void SetTheme(bool isDarkTheme)
		{
			if (isDarkTheme)
                ApplicationTheme = m_darkTheme;
            else
                ApplicationTheme = m_lightTheme;
            AppSettings.Instance.IsDarkTheme = isDarkTheme;
		}
	}
}
