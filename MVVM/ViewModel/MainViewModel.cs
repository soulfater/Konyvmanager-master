using konyvManeger.Core;
using System;

namespace konyvManeger.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommands HomeViewCommand { get; set; }

        public RelayCommands ManageBooksViewCommand { get; set; }

        public RelayCommands ManageViewCommand { get; set; }
        public RelayCommands ManageCustomerViewCommand { get; }
        public RelayCommands ManageCustomerCommand { get; set; }



        public HomeViewModel HomeVM { get; set; }


        public ManageBooksViewModel ManageBooksVM { get; set; }

        public ManageCustomerViewModel ManageCustomerVM { get; set; }



        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }

            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            ManageBooksVM = new ManageBooksViewModel();
            ManageCustomerVM = new ManageCustomerViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommands(o =>
            {
                CurrentView = HomeVM;
            });

            ManageBooksViewCommand = new RelayCommands(o =>
            {
                CurrentView = ManageBooksVM;
            });

            ManageCustomerViewCommand = new RelayCommands(o =>
            {
                CurrentView = ManageCustomerVM;
            });

        }
    }
}
