using System.Windows.Input;
using MVVM.Commands;
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

    private string myTextReversed;

    public string MyTextReversed    
    {
        get { return myTextReversed; }
        set
        {
            myTextReversed = value;
            OnPropertyChanged();
        }
    }

    public ICommand UpdateTextReveredCommand { get; }

    public DemoViewModel(DemoModel demoModel)
    {
        _demoModel = demoModel;

        UpdateTextReveredCommand = new DemoCommand(demoModel, this);
    }
}