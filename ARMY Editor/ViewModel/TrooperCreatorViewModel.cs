using ARMY_Editor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMY_Editor.ViewModel
{
    class TrooperCreatorViewModel
    {
        public Trooper Actual { get; set; }
        public void Setup(Trooper trooper)
        {
            this.Actual = trooper;
        }
        public TrooperCreatorViewModel()
        {

        }
    }
}
