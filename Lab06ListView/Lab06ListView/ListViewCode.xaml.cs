using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab06ListView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewCode : ContentPage
    {
        public ListViewCode()
        {
            InitializeComponent();
        }

        private void ShowListBtn_Clicked(object sender, EventArgs e)
        {
            listView.ItemsSource = new string[]
                {
                    "mono",
                    "monodroid",
                    "monotouch",
                    "monorail",
                    "monodevelop",
                    "monotone",
                    "monopoly",
                    "monomodal",
                    "mononucleosis"
                };
        }
    }
}