using ARMY_Editor.Model;
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

        public void SetupLogic(IList<Trooper> War)
        {
            this.War = War;
        }

        public void AddToWar(Trooper T)
        {
            War.Add(T);
        }

        public void RemoveFromWar(Trooper T)
        {
            War.Remove(T);
        }

        public void CreateNewTrooper()
        {

        }
    }
}
