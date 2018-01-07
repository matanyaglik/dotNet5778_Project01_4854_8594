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
        private static Contract GlobalContract;
        private static Child GlobalChild;
        private static Nanny GlobalNanny;
        private static Mother ContractMother=new Mother();
        IBL bl = BLSingleton.GetBL;
        public AddContractWindow(Mother mother)
        {
            InitializeComponent();
            GlobalChild=new Child();
            GlobalContract=new Contract();
            ContractMother = mother;
            ChooseChildComboBox.ItemsSource = bl.GetChildrenByMother(mother.ID);
            
        }

        private void ChooseChildComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var child =(Child) ChooseChildComboBox.SelectedItem;
            GlobalChild = child;
            List<Nanny> nannyList=new List<Nanny>();
            new Thread((ThreadStart) delegate { nannyList = NannyList(child);}).Start();
            
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


        private void AddContractCancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddContratChooseNannyBtn_OnClick(object sender, RoutedEventArgs e)
        {
            GlobalNanny =(Nanny) nannyDataGrid.SelectedItem;
            GlobalContract = new Contract()
            {
                ChildId = GlobalChild.ID,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                HourlyWage = GlobalNanny.HourlyWage,
                MonthlyWage = GlobalNanny.MonthlyWage,
                MotherId = ContractMother.ID,
                Rate = ContractMother.MonthlyOrHourly,
                Salary = BL_Tool.CalculateSalary(GlobalNanny, ContractMother),
                NannyId = GlobalNanny.ID
            };

        }
    }
}
