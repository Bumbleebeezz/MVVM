using MVVM.Models;

namespace MVVM.ViewModels;

public class DemoViewModel : ViewModelBase
{
    private readonly DemoModel _demoModel;

    private string _myText;

    public string MyText
    {
        get { return _demoModel.MyText; }
        set
        {
            _demoModel.MyText = value;
            OnPropertyChanged();
        }
    }
    public DemoViewModel(DemoModel demoModel)
    {
        _demoModel = demoModel;
    }
}