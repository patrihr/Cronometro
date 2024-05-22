using Services.Interfaces;
using Services;
using System.Windows;
using Cronometro.Services;

namespace Cronometro;

public partial class MainWindow : Window
{
    ICronometroTimer cronometro;

    public MainWindow()
    {
        InitializeComponent();
        cronometro = CronometroTimer.Create(RefrescarCronometro!);
    }

    private void btnStart_Click(object sender, RoutedEventArgs e)
    {
        cronometro.Start();
    }

    private void btnPause_Click(object sender, RoutedEventArgs e)
    {
        cronometro.Pause();
    }

    private void btnStopReset_Click(object sender, RoutedEventArgs e)
    {
        cronometro.Stop();
        TimeLabel.Content = cronometro.Value;
    }

    private void RefrescarCronometro(object sender, EventArgs e)
    {
        cronometro.AddSecond();
        TimeLabel.Content = cronometro.Value;
    }
}