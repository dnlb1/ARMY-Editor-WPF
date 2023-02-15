using ARMY_Editor.Model;
using ARMY_Editor.ViewModel;
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

namespace ARMY_Editor
{
    /// <summary>
    /// Interaction logic for TrooperCreator.xaml
    /// </summary>
    public partial class TrooperCreator : Window
    {
        bool Saved;
        public TrooperCreator(Trooper x)
        {
            InitializeComponent();
            var vm = new TrooperCreatorViewModel();
            vm.Setup(x);
            this.DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in mygrid.Children)
            {
                if (item is TextBox t)
                {
                    t.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
            }
            Saved = true;
            this.DialogResult = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Saved)
            {
                this.DialogResult = false;
            }
        }
    }
}
