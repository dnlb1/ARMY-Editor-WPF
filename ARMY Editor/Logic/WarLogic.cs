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
        IList<Trooper> Camp { get; set; }
        IMessenger msg;
        ITrooperCreatorOpen Tp;
        public WarLogic(IMessenger msg, ITrooperCreatorOpen Tp)
        {
            this.msg = msg;
            this.Tp = Tp;
        }
        public void SetupLogic(IList<Trooper> War, IList<Trooper> Camp)
        {
            this.War = War;
            this.Camp = Camp;
        }

        public double AvgSpeed
        {
            get
            {
                if (War.Count > 0 )
                {
                    return Math.Round(War.Average(t => t.Speed),1);
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
                    return Math.Round(War.Average(t => t.Power), 1);
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
            Trooper created = Tp.Create();
            if (created != null)
            {
                Camp.Add(created);
                msg.Send("TrooperAdded", "AvgToken");
            }
        }
    }
}
