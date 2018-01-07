using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddContractWindow.xaml
    /// </summary>
    public partial class AddContractWindow : Window
    {
        private Mother contractMother=new Mother();
        private IBL bl=BLSingleton.GetBL;
        public AddContractWindow(Mother mother)
        {
            InitializeComponent();
            contractMother = mother;
            ChooseChildComboBox.ItemsSource = bl.GetChildrenByMother(mother.ID);
            //BackgroundWorker worker = new BackgroundWorker();
            //worker.RunWorkerAsync(BL_Tool.MatchingNannies(child.ID));
        }

        private void ChooseChildComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var child = (Child) ChooseChildComboBox.SelectedItem;
            var nannyList=new List<Nanny>();
            new Thread((ThreadStart)delegate { nannyList = BL_Tool.MatchingNannies(child.ID).ToList(); }).Start();
           


        }

      
    }
}
