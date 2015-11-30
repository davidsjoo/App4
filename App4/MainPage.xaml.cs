using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App4
{
    public sealed partial class MainPage : Page
    {
        FontFamily font = new FontFamily("Consolas");
        ListViewItem itm;
        FileHandler fh = new FileHandler();
        string text;
        string empty = "";

        public MainPage()
        {
            this.InitializeComponent();
            fh.writeToList(listView, itm);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {            
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                text = textBox.Text;
                itm = new ListViewItem();
                itm.FontFamily = font;
                itm.Content = text;
                listView.Items.Add(itm);
                fh.writeToFile(text);
                textBox.Text = empty;
            }
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (item.IsSelected)
                {
                    fh.deleteFromFile(item);
                }
            }

            while (listView.SelectedItems.Count > 0)
            {
                listView.Items.Remove(listView.SelectedItems[0]);
                
            }
        }

        private void on_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
                button_Click(this, new RoutedEventArgs());
        }
    }

}
