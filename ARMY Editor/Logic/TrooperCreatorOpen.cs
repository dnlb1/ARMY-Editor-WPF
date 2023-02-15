using ARMY_Editor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMY_Editor.Logic
{
    class TrooperCreatorOpen : ITrooperCreatorOpen
    {
        public Trooper Create()
        {
            Trooper x = new Trooper();
            new TrooperCreator(x).ShowDialog();
            return x;
        }
    }
}
