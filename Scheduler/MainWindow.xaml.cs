using Microsoft.EntityFrameworkCore;
using Scheduler.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Scheduler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DataContext _context = new DataContext();

        private CollectionViewSource employeesViewSource;

        public MainWindow()
        {
            InitializeComponent();
            employeesViewSource = (CollectionViewSource)FindResource(nameof(employeesViewSource));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // this is for demo purposes only, to make it easier
            // to get up and running
            _context.Database.EnsureCreated();

            // load the entities into EF Core
            _context.Employees.Load();

            // bind to the source
            employeesViewSource.Source =
                _context.Employees.Local.ToObservableCollection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // all changes are automatically tracked, including
            // deletes!
            _context.Employees.Add(new Models.Employee { Name = "One", Surname = "Two", BirthDate = new DateTime(1999, 01, 01) });
            _context.SaveChanges();

            // this forces the grid to refresh to latest values
            employeesDataGrid.Items.Refresh();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // clean up database connections
            _context.Dispose();
            base.OnClosing(e);
        }
    }
}
