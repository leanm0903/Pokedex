using Pokedex.Models;
using Pokedex.ViewModels.Base;

namespace Pokedex.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private About about { get; set; }


        public About About
        {
            get { return about; }
            set { 
                    about = value;
                    RaisePropertyChanged(() => About);
                }
        }

        public AboutViewModel()
        {
        }
    }
}
