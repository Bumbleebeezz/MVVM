using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVM.Enums;
using MVVM.Models;
using MVVM.Services;

namespace MVVM.ViewModels;

public class MainViewModel : ObservableObject
{
    private readonly DemoNavigationService _navigationService;

    public ObservableObject CurrentViewModel => _navigationService.CurrentViewModel;

    public IRelayCommand NavigateDemoCommand { get; }
    public IRelayCommand NavigatePeopleCommand { get; }

    public MainViewModel(DemoNavigationService navigationService)
    {
        _navigationService = navigationService;

        NavigateDemoCommand = new RelayCommand(NavigateDemoCommandExecute);
        NavigatePeopleCommand = new RelayCommand(NavigatePeopleCommandExecute);

        _navigationService.CurrentViewModelChanged += NavigationServiceOnCurrentViewModelChanged;
    }

    private void NavigatePeopleCommandExecute()
    {
        _navigationService.ChangeCurrentViewModel(ViewTypes.People);
    }

    private void NavigateDemoCommandExecute()
    {
        _navigationService.ChangeCurrentViewModel(ViewTypes.Demo);
    }

    private void NavigationServiceOnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}