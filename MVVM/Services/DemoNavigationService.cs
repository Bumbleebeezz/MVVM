using System;
using CommunityToolkit.Mvvm.ComponentModel;
using MVVM.ViewModels.Locator;

namespace MVVM.Services;

public class DemoNavigationService
{
    private readonly ViewModelLocator _viewModelLocator;

	private ObservableObject _currentviewModel;	

	public ObservableObject CurrentViewModel
	{
        get
        {
            return _currentviewModel;
        }
        set
        {
            _currentviewModel = value;
            OnCurrentViewModelChanged();
        }
	}

    public DemoNavigationService()
    {
        _viewModelLocator = new ViewModelLocator();
        CurrentViewModel = _viewModelLocator.DemoViewModel;
    }

    private void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }

    public event Action CurrentViewModelChanged;

}