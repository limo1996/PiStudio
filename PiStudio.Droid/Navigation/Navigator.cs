using System;
using System.Threading.Tasks;
using PiStudio.Shared;
using PiStudio.Shared.Data;

namespace PiStudio.Droid
{
	public class Navigator : INavigator
	{
		public Navigator()
		{
		}

		public async Task GetStartedButtonClick()
		{
			await Task.Delay(1000);
		}

		public Task LoadNewImageWithUIAsync()
		{
			throw new NotImplementedException();
		}

		public Task<bool> NavigateTo(Type pageType, NavigationParameter args)
		{
			throw new NotImplementedException();
		}

		public void Share()
		{
			throw new NotImplementedException();
		}
	}
}
