﻿using System;
using System.Collections.Generic;
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
        private static Mother ContractMother=new Mother();
        IBL bl = BLSingleton.GetBL;
        public AddContractWindow(Mother mother)
        {
            InitializeComponent();
            ContractMother = mother;
            ChooseChildComboBox.ItemsSource = bl.GetChildrenByMother(mother.ID);
        }

        private void ChooseChildComboBox_OnSelected(object sender, RoutedEventArgs e)
        {
            
        }

        private void ChooseChildComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var child =(Child) ChooseChildComboBox.SelectedItem;
            List<Nanny> nannyList=new List<Nanny>();
            new Thread((ThreadStart) delegate { nannyList = BL_Tool.MatchingNannies(child.ID).ToList();}).Start();

        }

       
    }
}
