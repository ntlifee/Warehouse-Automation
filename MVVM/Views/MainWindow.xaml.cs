using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WarehouseAutomation.MVVM.Models;

namespace WarehouseAutomation
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Manager();
        }

        private void WindowMove(object sender, MouseButtonEventArgs e) { if (Mouse.LeftButton == MouseButtonState.Pressed) DragMove(); }
        private void ButtonClose_Click(object sender, RoutedEventArgs e) => Process.GetCurrentProcess().Kill();
        private void ButtonCollapse_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private void ButtonStartSimul_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}