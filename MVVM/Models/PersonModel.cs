using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM.Models
{
    public class PersonModel : INotifyPropertyChanged
    {
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;

        public string FirstName
        {
            get { return _firstName; }
            set 
            { 
                if (value == _firstName) { return; }
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName 
        { 
            get => _lastName;
            set 
            {
                if (value == _lastName) { return; }
                _lastName = value; 
                OnPropertyChanged(nameof(_lastName));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
