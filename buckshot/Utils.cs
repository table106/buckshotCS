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
        public static string Input(string input="")
        {
            if (input == "" || input.Length == 0)
            {
                Console.Write(">");
            }
            else
            {
                Console.Write(input + "\n>");
            }
            return Console.ReadLine();
        }
        public static bool CheckNames(string nameToCheck, string[] names)
        {
            if (names.Contains(nameToCheck))
            {
                return false;
            }
            return true;
        }
        public static void InitOpponents(Player plr1, Player plr2, Player plr3=null)
        {
            if (plr3 != null)
            {
                plr1.AddOpponent(plr2);
                plr1.AddOpponent(plr3);
                plr2.AddOpponent(plr1);
                plr2.AddOpponent(plr3);
                plr3.AddOpponent(plr1);
                plr3.AddOpponent(plr2);
            }
            else
            {
                plr1.AddOpponent(plr2);
                plr2.AddOpponent(plr1);
            }
        }
        public static void InitOpponents(Player_R2 plr1, Player_R2 plr2, Player_R2 plr3=null)
        {
            if (plr3 != null)
            {
                plr1.AddOpponent(plr2);
                plr1.AddOpponent(plr3);
                plr2.AddOpponent(plr1);
                plr2.AddOpponent(plr3);
                plr3.AddOpponent(plr1);
                plr3.AddOpponent(plr2);
            }
            else
            {
                plr1.AddOpponent(plr2);
                plr2.AddOpponent(plr1);
            }
        }
        public static void InitOpponents(Player_R3 plr1, Player_R3 plr2, Player_R3 plr3=null)
        {
            if (plr3 != null)
            {
                plr1.AddOpponent(plr2);
                plr1.AddOpponent(plr3);
                plr2.AddOpponent(plr1);
                plr2.AddOpponent(plr3);
                plr3.AddOpponent(plr1);
                plr3.AddOpponent(plr2);
            }
            else
            {
                plr1.AddOpponent(plr2);
                plr2.AddOpponent(plr1);
            }
        }
        public static string GetCurrentShell(Shotgun shotgun)
        {
            return shotgun.Content[0];
        }
    }
}
