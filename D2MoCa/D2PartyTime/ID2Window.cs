using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace D2PartyTime
{
    interface ID2Window
    {
        event KeyEventHandler KeyDown;
        event KeyEventHandler KeyUp;
        bool IsActive();
        void Click(int x, int y);
        //void ShowPanel(D2Panel panel);
    }
}
