using ARMY_Editor.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ARMY_Editor.ViewModel
{
    class MainWindowViewModel : ObservableRecipient
    {
        //Camp
        public ObservableCollection<Trooper> Camp { get; set; }
        //War
        public ObservableCollection<Trooper> War { get; set; }

        public bool IsInDesigner
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
        {
            this.Camp = new ObservableCollection<Trooper>();
            this.War = new ObservableCollection<Trooper>();

        }
    }
}
