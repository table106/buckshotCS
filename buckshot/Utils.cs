using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace buckshot
{
    internal class Utils
    {
        public static void Clear()
        {
            Console.Clear();
        }
        public static bool checkNames(string nameToCheck, string[] names)
        {
            if (names.Contains(nameToCheck))
            {
                return false;
            }
            return true;
        }
        public static void initOpponents(Player plr1, Player plr2, Player plr3=null)
        {
            if (plr3 != null)
            {
                plr1.addOpponent(plr2);
                plr1.addOpponent(plr3);
                plr2.addOpponent(plr1);
                plr2.addOpponent(plr3);
                plr3.addOpponent(plr1);
                plr3.addOpponent(plr2);
            }
            else
            {
                plr1.addOpponent(plr2);
                plr2.addOpponent(plr1);
            }
        }
        public static string getCurrentShell(Shotgun shotgun)
        {
            return shotgun.content[0];
        }
    }
}
