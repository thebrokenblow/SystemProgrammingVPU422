using System.Windows;

namespace Lesson5.Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private CancellationTokenSource? _cancellationTokenSource;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void SumButton_Click(object sender, RoutedEventArgs e)
    {
        ulong number = ulong.Parse(Number.Text);
        _cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = _cancellationTokenSource.Token;

        ChangeStatusControlElements();
        ThreadPool.QueueUserWorkItem(_ => CalculateSum(number, cancellationToken));
    }

    private void CalculateSum(ulong number, CancellationToken cancellationToken)
    {
        try
        {
            ulong sum = 0;
            for (ulong i = 1; i <= number; i++)
            {
                sum += i;
                cancellationToken.ThrowIfCancellationRequested();
            }

            Application.Current.Dispatcher.Invoke(() =>
            {
                Result.Text = sum.ToString();
            });
        }
        catch (OperationCanceledException)
        {
            MessageBox.Show("Операция успешно отменена");
        }
        finally
        {
            Application.Current.Dispatcher.Invoke(ChangeStatusControlElements);
        }
    }

    private void ChangeStatusControlElements()
    {
        Number.IsEnabled = !Number.IsEnabled;
        SumButton.IsEnabled = !SumButton.IsEnabled;
        CancellationSumButton.IsEnabled = !CancellationSumButton.IsEnabled;
    }

    private void CancellationSumButton_Click(object sender, RoutedEventArgs e)
    {
        _cancellationTokenSource?.Cancel();
    }
}