using System;
using System.Windows.Input;
namespace WpfBasic;

public class MyCommand : ICommand
{
    private readonly Action _action;//委托类型
    public event EventHandler? CanExecuteChanged;
    public MyCommand(Action action)
    {
        _action = action;
    }
    public bool CanExecute(object? parameter)
    {
        return true;
    }
    public void Execute(object? parameter)
    {
        _action();
    }
}