using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMY_Editor.Model
{
    public enum Side
    {
        Good,
        Evil,
        Neutral
    }
    class Trooper : ObservableObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name , value); }
        }

        private int power;

        public int Power
        {
            get { return power; }
            set { SetProperty(ref power, value); }
        }

        private double speed;

        public double Speed
        {
            get { return speed; }
            set {SetProperty(ref speed , value); }
        }

        private Side side;

        public Side Side
        {
            get { return side; }
            set { SetProperty(ref side, value); }
        }

        //DeepCopy - GOF 

        public Trooper GetCopy()
        {
            return new Trooper()
            {
                Name = this.name,
                Side = this.side,
                Speed = this.speed,
                Power = this.power
            };
        }
    }
}
