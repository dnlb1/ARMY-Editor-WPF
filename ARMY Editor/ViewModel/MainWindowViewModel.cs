using ARMY_Editor.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMY_Editor.ViewModel
{
    class MainWindowViewModel : ObservableRecipient
    {
        //Camp
        ObservableCollection<Trooper> Camp { get; set; }
        //War
        ObservableCollection<Trooper> War { get; set; }
    }
}
