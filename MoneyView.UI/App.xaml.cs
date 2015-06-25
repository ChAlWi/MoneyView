using System.Windows;
using Autofac;
using MoneyView.Model;
using MoneyView.UI.Views;
using MoneyView.Components;

namespace MoneyView.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AccountComparer>().AsImplementedInterfaces();
            builder.RegisterType<AccountEntryComparer>().AsImplementedInterfaces();
            builder.RegisterType<AccountEntryProvider>().AsImplementedInterfaces();

            builder.RegisterType<MainWindowView>().AsImplementedInterfaces();
            builder.RegisterType<MainWindow>().AsSelf();
            var container = builder.Build();

            var window = container.Resolve<MainWindow>();
            window.Show();
        }
    }
}
