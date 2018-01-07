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
        private  Mother ContractMother=new Mother();
        private Contract GlobalContract;
        private Child GlobalChild;
        IBL bl = BLSingleton.GetBL;
        public AddContractWindow(Mother mother)
        {
            InitializeComponent();
            ContractMother = mother;
            ChooseChildComboBox.ItemsSource = bl.GetChildrenByMother(mother.ID);
            
        }

        private void ChooseChildComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GlobalChild=new Child();
            GlobalChild =(Child) ChooseChildComboBox.SelectedItem;
            
            List<Nanny> nannyList=new List<Nanny>();
            new Thread((ThreadStart) delegate { nannyList = NannyList(GlobalChild);}).Start();
            
        }

        private List<Nanny> NannyList(Child child)
        {
            List<Nanny> nannyList;
            nannyList = BL_Tool.MatchingNannies(child.ID).ToList();
            var boolArray =
                BL.BL_Tool.MotherRequirements(bl.GetNanny(nannyList[0].ID), child, bl.GetMother(child.MotherID)).Any(n=>n==false);

            this.Dispatcher.Invoke(new Action(() => { nannyDataGrid.ItemsSource = nannyList;
                    nannyDataGrid.RowBackground = boolArray ? new SolidColorBrush(Colors.Yellow) : new SolidColorBrush(Colors.Green);
            }));
            return nannyList;
        }

       

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NewContract_OnClick(object sender, RoutedEventArgs e)
        {
            Nanny nanny=(Nanny)nannyDataGrid.SelectedItem;
            GlobalContract = new Contract()
            {
                ChildId = GlobalChild.ID,
                MotherId = ContractMother.ID,
                NannyId = nanny.ID,
                HourlyWage = nanny.HourlyWage,
                MonthlyWage = nanny.MonthlyWage,
                Rate = ContractMother.MonthlyOrHourly,
                Salary = BL_Tool.CalculateSalary(nanny, ContractMother),


            };
          new newContractWindow(GlobalContract).ShowDialog();
            

        }
    }
}
