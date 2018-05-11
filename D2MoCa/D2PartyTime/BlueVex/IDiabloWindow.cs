using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D2PartyTime
{
    interface IDiabloWindow
    {
        event KeyEventHandler KeyDown;
        event KeyEventHandler KeyUp;
        //string KeyOwner { get; }
        bool IsActive();
        void Click(int x, int y);
        //void CreateGame(string gameName, string password, string difficulty);
        //void JoinGame(string gameName, string password);
        //void ExitGame();
        //void QuitFromChat();
        //void LoginToBattleNet(string defaultAccount);
        //void ShowPanel(D2Panel panel);
    }
}
