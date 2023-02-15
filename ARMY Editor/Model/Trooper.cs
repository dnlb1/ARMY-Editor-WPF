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
    class Trooper
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int power;

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        private double speed;

        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        private Side side;

        public Side Side
        {
            get { return side; }
            set { side = value; }
        }


    }
}
