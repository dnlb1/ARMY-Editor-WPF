using ARMY_Editor.Model;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMY_Editor.Logic
{
    class WarLogic : IWarLogic
    {
        IList<Trooper> War { get; set; }
        IMessenger msg;
        ITrooperCreatorOpen Tp;
        public WarLogic(IMessenger msg, ITrooperCreatorOpen Tp)
        {
            this.msg = msg;
            this.Tp = Tp;
        }
        public void SetupLogic(IList<Trooper> War)
        {
            this.War = War;
        }

        public double AvgSpeed
        {
            get
            {
                if (War.Count > 0 )
                {
                    return War.Average(t => t.Speed);
                }
                else
                {
                    return 0;
                }
            }
        }

        public double AvgPower
        {
            get
            {
                if (War.Count > 0)
                {
                    return War.Average(t => t.Power);
                }
                else
                {
                    return 0;
                }
            }
        }

        public void AddToWar(Trooper T)
        {
            War.Add(T.GetCopy());
            msg.Send("TrooperAdded", "AvgToken");
        }

        public void RemoveFromWar(Trooper T)
        {
            War.Remove(T);
            msg.Send("TrooperDeleted", "AvgToken");
        }

        public void CreateNewTrooper()
        {
            Tp.Create();
        }
    }
}
