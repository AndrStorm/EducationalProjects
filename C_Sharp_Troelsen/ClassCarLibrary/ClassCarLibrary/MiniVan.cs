using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClassCarLibrary
{
    public class MiniVan:Car
    {
        public MiniVan() { }
        public MiniVan(string name, int maxSp, int currSp)
        : base(name, maxSp, currSp) { }
        public override void TurboBoost()
        {
            // Минивэны имеют плохие возможности ускорения'
            egnState = EngineState.engineDead;
            MessageBox.Show("Eek!", "Your engine block exploded!");
        }
    }
}
