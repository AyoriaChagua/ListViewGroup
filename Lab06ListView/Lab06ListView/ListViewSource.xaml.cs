using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab06ListView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewSource : ContentPage
    {
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        public ListViewSource()
        {
            InitializeComponent();
            EmployeeView.ItemsSource = employees;
            employees.Add(new Employee { DisplayName = "Rob Finnerty " });
            employees.Add(new Employee { DisplayName = "Bill Wrestler " });
            employees.Add(new Employee { DisplayName = "Dr. Geri-Beth Hooper" });
            employees.Add(new Employee { DisplayName = "Dr. Keith Joyce-Purdy" });
            employees.Add(new Employee { DisplayName = "Sheri Spruce" });
            employees.Add(new Employee { DisplayName = "Burt Indybrick" });
        }
    }
}