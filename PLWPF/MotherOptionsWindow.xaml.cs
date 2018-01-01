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
    /// Interaction logic for MotherOptionsWindow.xaml
    /// </summary>
    public partial class MotherOptionsWindow : Window
    {
        public static Mother motherOption;
        private IBL bl = BLSingleton.GetBL;
        public MotherOptionsWindow(Mother mother)
        {
            this.SizeChanged += OnWindowSizeChanged;
            motherOption = mother;
            InitializeComponent();
            MotherWelcomeBanner.Content = $"Welcome {motherOption.FirstName} {motherOption.LastName}";
        }

        private void OnWindowSizeChanged(Object sender, SizeChangedEventArgs e)
        {
            var ChangeRatio = (e.PreviousSize.Width == 0 || e.PreviousSize.Height == 0) ? 1 : (e.NewSize.Height + e.NewSize.Width) /
                                                                                              (e.PreviousSize.Height + e.PreviousSize.Width);
            ChangeTextSize.RecurseChangeRatio(MotherOptionsGrid, ChangeRatio);
        }

        private void RemoveMotherBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddChildBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddContractBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateMotherBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateChildBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateContractBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GetContractMotherBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveChildBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveContractBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MotherOptionsBackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
