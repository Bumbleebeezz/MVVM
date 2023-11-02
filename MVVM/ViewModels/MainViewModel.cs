using CommunityToolkit.Mvvm.ComponentModel;

namespace MVVM.ViewModels;

public class MainViewModel
{
    public ObservableObject DemoViewModel { get; }
    public ObservableObject PeopleViewModel { get; }



    public MainViewModel(ObservableObject demoViewModel, ObservableObject peopleViewModel)
    {
        DemoViewModel = demoViewModel;
        PeopleViewModel = peopleViewModel;
    }
}