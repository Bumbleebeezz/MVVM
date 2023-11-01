using MVVM.Models;
using MVVM.ViewModels;
using MVVM.Views;

namespace MVVM.Commands;

public class DemoCommand : CommandBase
{
    private readonly DemoModel _demoModel;
    private readonly DemoViewModel _demoViewModel;

    // Dependency injection
    public DemoCommand(DemoModel demoModel, DemoViewModel demoViewModel)
    {
        _demoModel = demoModel;
        _demoViewModel = demoViewModel;
    }

    public override void Execute(object? parameter)
    {
        var textReversed = _demoModel.ReverseMyText();
        _demoViewModel.MyTextReversed = textReversed;
    }
}