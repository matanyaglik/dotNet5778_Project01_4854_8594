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
        public static Child ChildOption;
        private List<Child> ChildrenList=new List<Child>();
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
            new AddChildWindow(motherOption).ShowDialog();
        }

        private void AddContractBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateMotherBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateChildBtn_Click(object sender, RoutedEventArgs e)
        {
            ChildrenList = bl.GetChildrenByMother(motherOption.ID).ToList();
            ChooseChildDataGrid.ItemsSource = ChildrenList;
            ChooseChildDataGrid.Visibility = Visibility.Visible;
            ChildSelectedBackButton.Visibility = Visibility.Visible;
            ChildSelectedOKButton.Visibility = Visibility.Visible;
            MotherOptionsBackButton.Visibility = Visibility.Collapsed;
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

        
        private void OnUpdateChildWindowClosed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ChildSelectedBackButton_OnClick(object sender, RoutedEventArgs e)
        {
            ChooseChildDataGrid.Visibility = Visibility.Collapsed;
            ChildSelectedBackButton.Visibility = Visibility.Collapsed;
            ChildSelectedOKButton.Visibility = Visibility.Collapsed;
            MotherOptionsBackButton.Visibility = Visibility.Visible;
        }

        private void ChildSelectedOKButton_OnClick(object sender, RoutedEventArgs e)
        {
            new UpdateChildWindow((Child) ChooseChildDataGrid.SelectedItem).ShowDialog();
            ChooseChildDataGrid.Visibility = Visibility.Collapsed;
            ChildSelectedBackButton.Visibility = Visibility.Collapsed;
            ChildSelectedOKButton.Visibility = Visibility.Collapsed;
            MotherOptionsBackButton.Visibility = Visibility.Visible;
        }
    }
}
