using System;
using Kantine.Model;
using Kantine.Services;
using System.Collections.ObjectModel;

namespace Kantine.ViewModel
{
    public class ProfilViewModel : ViewModelBase
    {
        ObservableCollection<Order> _orders;
        ObservableCollection<User> _users;

        public ProfilViewModel()
        {
            LoadData();
        }

        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        void LoadData()
        {
            Orders = new ObservableCollection<Order>(OrderService.instance.GetOrders());
            Users = new ObservableCollection<User>(UserService.instance.GetUsers());
        }
    }
}

