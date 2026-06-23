using LoadingSpinnerControl;
using System.IO;
using System.Windows;

namespace Lesson7;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        Menu.Visibility = Visibility.Hidden;
        LoadingSpinner.IsLoading = true;

        var lines = await File.ReadAllLinesAsync("D:\\Users\\artem\\data.txt");

        LoadingSpinner.IsLoading = false;
        Menu.Visibility = Visibility.Visible;
    }
}