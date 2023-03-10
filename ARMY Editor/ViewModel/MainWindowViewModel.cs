using ARMY_Editor.Logic;
using ARMY_Editor.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
                (RemoveTrooper as RelayCommand).NotifyCanExecuteChanged();
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

        private double avgspeed;
        public double AvgSpeed
        {
            get
            {
                return logic.AvgSpeed;
            }
            set { SetProperty(ref avgspeed, value); }
        }
        
        private double avgpower;
        public double AvgPower
        {
            get
            {
                return logic.AvgPower;
            }
            set { SetProperty(ref avgpower, value); }
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
        public ICommand RemoveTrooper { get; set; }

        public MainWindowViewModel(): this(IsInDesigner ? null : Ioc.Default.GetService<IWarLogic>())
        {
        }
        public MainWindowViewModel(IWarLogic logic)
        {
            this.logic = logic;
            if (File.Exists("TrooperCamp.json"))
            {
                string jsonString = File.ReadAllText("TrooperCamp.json");
                Camp = JsonConvert.DeserializeObject<ObservableCollection<Trooper>>(jsonString);
            }
            else
            {
                this.Camp = new ObservableCollection<Trooper>();
            }

            if (File.Exists("TrooperWar.json"))
            {
                string jsonString = File.ReadAllText("TrooperWar.json");
                War = JsonConvert.DeserializeObject<ObservableCollection<Trooper>>(jsonString);
            }
            else
            {
                this.War = new ObservableCollection<Trooper>();
            }

            logic.SetupLogic(War,Camp);

            this.AddToWar = new RelayCommand(() =>
            {
                logic.AddToWar(SelecterCamp);
            },
            () =>
            {
                return SelecterCamp != null;
            });

            this.CallBackFromWar = new RelayCommand(() =>
            {
                logic.RemoveFromWar(SelectedWar);
            },
            () =>
            {
                return SelectedWar != null;
            });


            this.CreateNewTrooper = new RelayCommand(() =>
            {
                logic.CreateNewTrooper();
            },
            () =>
            {
                return true;
            });

            this.RemoveTrooper = new RelayCommand(() =>
            {
                logic.RemoveTrooper(selectedcamp);
            },
            () =>
            {
                return SelecterCamp != null;
            });

            Messenger.Register<MainWindowViewModel, string, string>(this, "AvgToken", (recipient, msg) =>
            {
                OnPropertyChanged("AvgSpeed");
                OnPropertyChanged("AvgPower");
            });

        }

        public void SaveJson()
        {
            string JsonCamp = JsonConvert.SerializeObject(Camp);
            string JsonWar = JsonConvert.SerializeObject(War);
            File.WriteAllText("TrooperCamp.json", JsonCamp);
            File.WriteAllText("TrooperWar.json", JsonWar);

        }
    }
}
