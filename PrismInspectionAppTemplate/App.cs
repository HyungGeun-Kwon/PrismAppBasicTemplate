using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CvsService.Prism.Services;
using Prism.Ioc;
using PrismInspectionAppTemplate.Views;

namespace PrismInspectionAppTemplate
{
    public class App : PrismApplicationHelper
    {
        protected override Window CreateShell()
        {
            RunSplash();
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry) { }

        protected override void OnStartup(StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            CheckApplicationIsRunning(e, Assembly.GetExecutingAssembly().ManifestModule.Name);
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string title = "UnHandled Exception!";
            string msg = e.ExceptionObject.ToString();
            _ = MessageBox.Show(title + Environment.NewLine + msg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            AppDomain.CurrentDomain.UnhandledException -= CurrentDomain_UnhandledException;
            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
