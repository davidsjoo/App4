using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace App4
{
    class FileHandler
    {
        FontFamily font = new FontFamily("Consolas");
        String fileName = @"tasks.txt";

        public void writeToFile(String text)
        {
            Task.Run(() =>
            {

                using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(text);
                }
            });
        }

        public void deleteFromFile(ListViewItem item)
        {
            string temp = item.Content.ToString();
            File.WriteAllLines(fileName,
                File.ReadLines(fileName).Where(l => l != temp).ToList());
            
        }

        public void writeToList(ListView listView, ListViewItem itm)
        {
            foreach (var line in File.ReadLines(fileName))
            {
                
                itm = new ListViewItem();
                itm.FontFamily = font;
                itm.Content = line;
                listView.Items.Add(itm);
            }
        }
    }
}
