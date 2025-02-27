using System.Windows;

namespace WixMix
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Create and show the Welcome window
            Welcome welcomeWindow = new Welcome();
            welcomeWindow.Show();

            // Create and show the Main window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
