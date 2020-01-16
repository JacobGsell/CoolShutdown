using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Diagnostics;

namespace CoolShutdown
{
  /// <summary>
  /// Interaktionslogik für MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    int totalTime()
    {
      int hoursToSeconds = int.Parse(HourCount.Text) * 3600;
      int minutesToSeconds = int.Parse(MinuteCount.Text) * 60;
      int seconds = int.Parse(SecondCount.Text);

      return seconds + minutesToSeconds + hoursToSeconds;
    }

    /// <summary>
    /// Shuts pc down
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Shutdown(object sender, RoutedEventArgs e)
    {
      Process.Start("Shutdown", "/s /t " + totalTime());
    }

    /// <summary>
    /// Logs user out
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Logout(object sender, RoutedEventArgs e)
    {
      Process.Start("Shutdown", "/l /t " + totalTime());
    }

    /// <summary>
    /// Restarts pc
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Restart(object sender, RoutedEventArgs e)
    {
      Process.Start("Shutdown", "/r /t " + totalTime());
    }

    /// <summary>
    /// Aborts recent command
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Abort(object sender, RoutedEventArgs e)
    {
      Process.Start("Shutdown", "/a");
    }

    private void Button_MouseEnter(object sender, MouseEventArgs e)
    {
      (sender as Button).Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFFFF"));
      (sender as Button).Foreground = Brushes.Black;
    }

    private void Button_MouseLeave(object sender, MouseEventArgs e)
    {
      (sender as Button).Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000053"));
      (sender as Button).Foreground = Brushes.White;
    }
  }
}
