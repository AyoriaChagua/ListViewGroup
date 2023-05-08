using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Lab06ListView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewGroup : ContentPage
    {
        public ListViewGroup()
        {
            InitializeComponent();
            ObservableCollection<Contact> contacts = new ObservableCollection<Contact>
            {
                new Contact {Name="Ayoria", Number="999 999 999" },
                new Contact {Name="Curlie", Number="999 999 999" },
                new Contact {Name="Dayron", Number="999 777 999" },
                new Contact {Name="Albert", Number="999 999 999"},
                new Contact {Name="Brenda", Number="999 888 999"},
                new Contact {Name="Carlos", Number="999 666 788"},
                new Contact {Name="Diana", Number="999 777 999"}
            };

            var sortedAndGroupedList = contacts.OrderBy(x => x.Name)
                .GroupBy(x => x.Name[0].ToString())
                .ToDictionary(x => x.Key, x => x.ToList())
                .Select(x => new Grouping<string, Contact>(x.Key, x.Value));


            var ContactView = new ListView
            {
                IsGroupingEnabled = true,
                ItemsSource = sortedAndGroupedList
            };

            ContactView.ItemsSource = sortedAndGroupedList;
            ContactView.IsGroupingEnabled = true;
            ContactView.ItemTemplate = new DataTemplate(() =>
            {
                var nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");
                var numberLabel = new Label();
                numberLabel.SetBinding (Label.TextProperty, "Number");
                var stacklayout = new StackLayout {
                    Orientation = StackOrientation.Horizontal,
                    Children = { nameLabel, numberLabel }
                };
                return new ViewCell { View = stacklayout };
            });

            ContactView.GroupHeaderTemplate = new DataTemplate(() =>
            {
                var label = new Label();
                label.SetBinding(Label.TextProperty, "Key");
                return new ViewCell { View = label };
            });

            Content = ContactView;
        }
    }
}
public class Grouping<K, T> : ObservableCollection<T>
{
    public K Key { get; private set; }

    public Grouping(K key, IEnumerable<T> items)
    {
        Key = key;
        foreach (var item in items)
            Items.Add(item);
    }
}
