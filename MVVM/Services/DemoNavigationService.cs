using System;
using CommunityToolkit.Mvvm.ComponentModel;
using MVVM.Enums;
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

    public void ChangeCurrentViewModel(ViewTypes requestedView)
    {
        switch (requestedView)
        {
            case ViewTypes.Demo:
                CurrentViewModel = _viewModelLocator.DemoViewModel;
                break;
            case ViewTypes.People:
                CurrentViewModel = _viewModelLocator.PeopleViewModel;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(requestedView), requestedView, null);
        }
    }

    private void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }

    public event Action CurrentViewModelChanged;

}