using System.Diagnostics;
using System.Net.Http;
using System.Windows;

namespace Lesson2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Process? _childProcess;
    public MainWindow()
    {
        InitializeComponent();


        //Stream = Поток
        //Thread = Нить
        //Process -> Набор нитей
    }

    private void StartProcess_Button_Click(object sender, RoutedEventArgs e)
    {
        _childProcess = Process.Start("D:\\projects\\source\\repos\\SystemProgrammingVPU422\\Lesson2.ChildProcess\\bin\\Debug\\net10.0-windows\\Lesson2.ChildProcess.exe");
    }

    private void KillProcess_Button_Click(object sender, RoutedEventArgs e)
    {
        if (_childProcess != null)
        {
            _childProcess.Kill();
            _childProcess = null;
        }
    }
}