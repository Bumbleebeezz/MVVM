using System;
using System.Windows.Input;

namespace MVVM.Commands;

public abstract class CommandBase : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public abstract void Execute(object? parameter);

    public event EventHandler? CanExecuteChanged;

    protected void OnCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, new EventArgs());
    }
}