using System.Collections.ObjectModel;
using BusinessExpenseTracker.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BusinessExpenseTracker.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty] private string expenseName = string.Empty;
    [ObservableProperty] private string amount = string.Empty;
    [ObservableProperty] private string category = string.Empty;

    public ObservableCollection<Expense> Expenses { get; } = new();

    [RelayCommand]
    private void AddExpense()
    {
        if (string.IsNullOrWhiteSpace(ExpenseName) ||
            string.IsNullOrWhiteSpace(Category) ||
            !decimal.TryParse(Amount, out var value) || value <= 0)
            return;

        Expenses.Add(new Expense
        {
            Name = ExpenseName.Trim(),
            Amount = value,
            Category = Category.Trim(),
            Date = DateTime.Now
        });

        ExpenseName = string.Empty;
        Amount = string.Empty;
        Category = string.Empty;
    }
}
