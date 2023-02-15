using ARMY_Editor.Logic;
using ARMY_Editor.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ARMY_Editor.ViewModel
{
    class MainWindowViewModel : ObservableRecipient
    {
        //Camp
        public ObservableCollection<Trooper> Camp { get; set; }
        private Trooper selectedcamp;
        public Trooper SelecterCamp
        {
            get { return selectedcamp; }
            set 
            {
                SetProperty(ref selectedcamp , value);
                (AddToWar as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        //War
        public ObservableCollection<Trooper> War { get; set; }
        private Trooper selectedwar;

        public Trooper SelectedWar
        {
            get { return selectedwar; }
            set 
            { 
                SetProperty(ref selectedwar , value);
                (CallBackFromWar as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        IWarLogic logic;

        public static bool IsInDesigner
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ICommand AddToWar { get; set; }
        public ICommand CallBackFromWar { get; set; }
        public ICommand CreateNewTrooper { get; set; }

        public MainWindowViewModel(): this(IsInDesigner ? null : Ioc.Default.GetService<IWarLogic>())
        {
        }


        public MainWindowViewModel(IWarLogic logic)
        {
            this.logic = logic;
            this.Camp = new ObservableCollection<Trooper>();
            this.Camp.Add(new Trooper() { Side = Side.Neutral, Speed = 2, Name = "Bela", Power = 4});
            this.War = new ObservableCollection<Trooper>();
            this.War.Add(new Trooper() { Side = Side.Evil, Speed = 2, Name = "Bela", Power = 4 });

            this.AddToWar = new RelayCommand(() =>
            {

            },
            () =>
            {
                return SelecterCamp != null;
            });

            this.CallBackFromWar = new RelayCommand(() =>
            {

            },
            () =>
            {
                return SelectedWar != null;
            });


            this.AddToWar = new RelayCommand(() =>
            {

            },
            () =>
            {
                return true;
            });



        }
    }
}
