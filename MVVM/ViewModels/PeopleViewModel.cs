using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModels
{
    public class PeopleViewModel : ObservableObject
    {
        #region Props
        public ObservableCollection<PersonModel> PeopleList { get; set; } = new();

        private PersonModel _selectedPerson;

        public PersonModel? SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                if (_selectedPerson == value) { return; }
                _selectedPerson = value;
                if (value is null) 
                { 
                    EditFirstName = string.Empty;
                    EditLastName = string.Empty;
                }
                else 
                { 
                    EditFirstName = _selectedPerson.FirstName;
                    EditLastName = _selectedPerson.LastName;
                }
                UpdateSelectedPersonCommand.NotifyCanExecuteChanged();
                RemoveSelectedPersonCommand.NotifyCanExecuteChanged();
                OnPropertyChanged();
            }
        }

        private string _editFirstName;

        public string EditFirstName
        {
            get { return _editFirstName; }
            set 
            { 
                _editFirstName = value; 
                OnPropertyChanged();
                AddNewPersonCommand.NotifyCanExecuteChanged();
            }
        }

        private string _editLastName;

        public string EditLastName
        {
            get { return _editLastName; }
            set 
            { 
                _editLastName = value; 
                OnPropertyChanged();
                AddNewPersonCommand.NotifyCanExecuteChanged();
            }
        }
        #endregion

        #region Commands

        public IRelayCommand UpdateSelectedPersonCommand { get; }
        public IRelayCommand RemoveSelectedPersonCommand { get; }
        public IRelayCommand AddNewPersonCommand { get; }


        #endregion

        public PeopleViewModel() 
        {
            PeopleList.Add(new PersonModel() { FirstName = "Maria", LastName = "Edström" });
            PeopleList.Add(new PersonModel() { FirstName = "Eva", LastName = "Edström" });
            PeopleList.Add(new PersonModel() { FirstName = "Bengt", LastName = "Edström" });

            UpdateSelectedPersonCommand = new RelayCommand(UpdateSelectedPersonCommandExecute, UpdateSelectedPersonCommandCanExecute);
            RemoveSelectedPersonCommand = new RelayCommand(RemoveSelectedPersonCommandExecute, RemoveSelectedPersonCanExecute);
            AddNewPersonCommand = new RelayCommand(AddNewPersonCommandExecute, AddNewPersonCommandCanExecute);
        }

        private bool AddNewPersonCommandCanExecute() 
        { 
            return !string.IsNullOrEmpty(EditFirstName) && !string.IsNullOrEmpty(EditLastName);
        }

        private void AddNewPersonCommandExecute() 
        {
            var newPerson = new PersonModel();
            newPerson.FirstName = EditFirstName;
            newPerson.LastName = EditLastName;
            PeopleList.Add(newPerson);
        }

        private bool RemoveSelectedPersonCanExecute() 
        { 
            return _selectedPerson is not null;
        }

        private void RemoveSelectedPersonCommandExecute() 
        { 
            PeopleList.Remove(SelectedPerson);
        }

        private bool UpdateSelectedPersonCommandCanExecute() 
        {
            return _selectedPerson is not null;
        }

        private void UpdateSelectedPersonCommandExecute() 
        { 
            _selectedPerson.FirstName = EditFirstName;
            _selectedPerson.LastName = EditLastName;

        }
    }
}
