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

namespace Test_Hyperlinks
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Hyperlinks dynamisch erzeugen
            string[] anf = { "A", "B", "G" , "X", "Y", "Z"};


            foreach (var item in anf)
            {
                var run1 = new Run(item);
                var hyp = new Hyperlink(run1);
                hyp.Click += Hyp_Click; //+= und tabtab -> neuer eventhandler wird erstellt
                hyp.Tag = item; //der buchstabe auf den man geklickt hat, wird in Tag gespeichert

                //in den logischen elementenbaum einhängen
                this.placeholder.Inlines.Add(hyp);
            }
        }

        private void Hyp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"geklickt wurde {(sender as Hyperlink).Tag}");
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e) //in e steht die Uri die im WPF steht
        {
            Process.Start(e.Uri.AbsoluteUri); //Startet den Prozess, es soll die absolute Uri übergeben werden -> startet Standartbrowser
            e.Handled = true; //event als handeled erklären (event ist abgearbeitet)
        }
    }
}
