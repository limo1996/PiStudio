using System.ComponentModel;
using Android.Graphics;

namespace PiStudio.Droid
{
	/// <summary>
	/// Data class that contains style of the application. In other words application theme.
	/// </summary>
	public class Theme : INotifyPropertyChanged
	{
		private Color m_foreground;
		private Color m_background;
		private Color m_panelBackground;
		private Color m_borders;
		private Color m_panelForeground;
		private Color m_panelItemFocused;
		private Color m_clickableForeground;
		private Color m_upperPanelBackground;

		/// <summary>
		/// Text color in apps content.
		/// </summary>
		public Color Foreground
		{
			get
			{
				return m_foreground;
			}
			set
			{
				m_foreground = value;
				OnPropertyChanged("Foreground");
			}
		}

		/// <summary>
		/// Background color of apps content.
		/// </summary>
		public Color Background
		{
			get
			{
				return m_background;
			}

			set
			{
				m_background = value;
				OnPropertyChanged("Background");
			}
		}

		/// <summary>
		/// Background of the left hamburger menu. (left panel)
		/// </summary>
		public Color PanelBackground
		{
			get
			{
				return m_panelBackground;
			}
			set
			{
				m_panelBackground = value;
				OnPropertyChanged("LeftPanel");
			}
		}

		/// <summary>
		/// Border color.
		/// </summary>
		public Color Borders
		{
			get
			{
				return m_borders;
			}
			set
			{
				m_borders = value;
				OnPropertyChanged("Borders");
			}
		}

		/// <summary>
		/// Text and icons color that are in the left panel.
		/// </summary>
		public Color PanelForeground
		{
			get
			{
				return m_panelForeground;
			}
			set
			{
				m_panelForeground = value;
				OnPropertyChanged("PanelForeground");
			}
		}

		/// <summary>
		/// Application's most dominant color. Selected menu icon is indicated by this color as well as some controls and headers.
		/// </summary>
		public Color PanelItemFocused
		{
			get
			{
				return m_panelItemFocused;
			}
			set
			{
				m_panelItemFocused = value;
				OnPropertyChanged("PanelItemFocused");
			}
		}

		/// <summary>
		/// Foreground of the clickable elements.
		/// </summary>
		public Color ClickableForeground
		{
			get
			{
				return m_clickableForeground;
			}
			set
			{
				m_clickableForeground = value;
				OnPropertyChanged("ClickableForeground");
			}
		}

		/// <summary>
		/// Background color of the upper panel background.
		/// </summary>
		public Color UpperPanelBackground
		{
			get
			{
				return m_upperPanelBackground;
			}
			set
			{
				m_upperPanelBackground = value;
				OnPropertyChanged("UpperPanelBackground");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public void CopyTo(Theme theme)
		{
			theme.Background = this.Background;
			theme.Foreground = this.Foreground;
			theme.Borders = this.Borders;
			theme.PanelBackground = this.PanelBackground;
			theme.PanelItemFocused = this.PanelItemFocused;
			theme.PanelForeground = this.PanelForeground;
			theme.ClickableForeground = this.ClickableForeground;
			theme.UpperPanelBackground = this.UpperPanelBackground;
		}
	}
}
