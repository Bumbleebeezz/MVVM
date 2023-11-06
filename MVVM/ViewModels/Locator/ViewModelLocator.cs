using System;
using CommunityToolkit.Mvvm.ComponentModel;
using MVVM.Models;

namespace MVVM.ViewModels.Locator;

public class ViewModelLocator
{
    public ObservableObject DemoViewModel { get; set; } = new DemoViewModel(new DemoModel());
    public ObservableObject PeopleViewModel { get; set; } = new PeopleViewModel();

}