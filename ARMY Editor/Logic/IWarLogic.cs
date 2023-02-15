using ARMY_Editor.Model;
using System.Collections.Generic;

namespace ARMY_Editor.Logic
{
    interface IWarLogic
    {
        double AvgPower { get; }
        double AvgSpeed { get; }

        void AddToWar(Trooper T);
        void CreateNewTrooper();
        void RemoveFromWar(Trooper T);
        void SetupLogic(IList<Trooper> War);
    }
}