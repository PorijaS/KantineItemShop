using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kantine.Model;
using Kantine.Services;
using System.Collections.ObjectModel;

namespace Kantine.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        ObservableCollection<Candy> _candies;
        ObservableCollection<VM> _vms;

        public MenuViewModel()
        {
            LoadData();
        }

        public ObservableCollection<Candy> Candies
        {
            get { return _candies; }
            set
            {
                _candies = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<VM> Vms
        {
            get { return _vms; }
            set
            {
                _vms = value;
                OnPropertyChanged();
            }
        }

        void LoadData()
        {
            Candies = new ObservableCollection<Candy>(CandyService.instance.GetCandies());
            Vms = new ObservableCollection<VM>(VMService.instance.GetVMS());
        }
    }
}
