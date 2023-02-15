using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMY_Editor.Logic
{
    class TrooperCreatorOpen : ITrooperCreatorOpen
    {
        public void Create()
        {
            new TrooperCreator().ShowDialog();
        }
    }
}
