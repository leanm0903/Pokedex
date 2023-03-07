using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pokedex.ViewModels.Base
{
	public class BaseViewModel  : ExtendedBindableObject
	{
		public int Limit => 50;
		public int OffSet { get; set; }
		public int PageNumber { get; set; }

		public Page Page { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		private string title;
		private bool isBusy;

		protected INavigation Navigation => this.Page.Navigation;
		
		public string Title
		{
			get { return title; }
			set
			{
				title = value;
				RaisePropertyChanged(() => Title);
			}
		}

		public bool IsBusy
		{
			get { return isBusy; }
			set
			{
				isBusy = value;
				RaisePropertyChanged(() => IsBusy);
			}
		}
		
		
		protected virtual void OnPropertyChanged(string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public virtual Task InitializeAsync(object navigationData)
		{
			return Task.FromResult(false);
		}

		public virtual Task InitializeAsync(object navigationData, object navigationData2)
		{
			return Task.FromResult(false);
		}
		public virtual Task InitializeAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
		{
			return await this.Page.DisplayActionSheet(title, cancel, destruction, buttons);
		}

		public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
		{
			return await this.Page.DisplayAlert(title, message, accept, cancel);
		}
	}
}


