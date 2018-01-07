using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for newContractWindow.xaml
    /// </summary>
    public partial class newContractWindow : Window
    {
        private IBL bl = BLSingleton.GetBL;
        private Contract CurrentContract;
        public newContractWindow(Contract contract)
        {
            InitializeComponent();
            CurrentContract = contract;
            DataContext = contract;
            startDateDatePicker.SelectedDate = DateTime.Now;

        }


        private void AddBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var btnresult= MessageBox.Show("Add Contract?", "Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Information);
           if(btnresult == MessageBoxResult.OK)
                bl.AddContract(CurrentContract);
         
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void EndDateDatePicker_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
