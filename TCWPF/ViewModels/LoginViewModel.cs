using System;
using System.ComponentModel;
using BuisnesLogicLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCWPF.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            private get;
            set;
        }

        private readonly IAuthManager _security;

        public LoginViewModel(IAuthManager security)
        {
            _security = security;
        }

        public bool Login()
        {
            return _security.Login(Username, Password);
        }
    }
}
