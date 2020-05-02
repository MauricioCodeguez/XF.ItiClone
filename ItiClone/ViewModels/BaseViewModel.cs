using ItiClone.Services.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ItiClone.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public static CultureInfo culture = new CultureInfo("pt-BR");

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected void SetProperty<T>(ref T storage, T value, Action onChanged = null, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return;

            storage = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
        }

        public virtual Task InitializeAsync(object[] args) => Task.FromResult(true);

        protected NavigationService Navigation => NavigationService.Current;

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set => SetProperty(ref isBusy, value, () => MyChangeCanExecute());

        }

        protected virtual void MyChangeCanExecute() { }

        public bool IsBusyStatus() => !IsBusy;


        private string title;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

    }
}