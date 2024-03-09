using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buckshot
{
    internal class Items
    {
        public static void useBeer(Player_R2 p, Shotgun shotgun)
        {
            Console.WriteLine($"you unloaded a {Utils.getCurrentShell(shotgun)} shell");
            shotgun.shoot();
            p.Inv.Remove("beer");
        }
        public static void useKnife(Player_R2 p, Shotgun shotgun)
        {
            Console.WriteLine("the next shot will deal 2 damage");
            shotgun.dmg = 2;
            p.Inv.Remove("knife");
        }
        public static void useGlass(Player_R2 p, Shotgun shotgun)
        {
            Console.WriteLine($"the shell in the chamber is {Utils.getCurrentShell(shotgun)}");
            p.Inv.Remove("magnifying glass");
        }
        public static void useCig(Player_R2 p)
        {
            if (p.Lives == p.lifeCap)
            {
                Console.WriteLine("you already have max lives. (item consumed)");
            } else
            {
                p.heal();
            }
            p.Inv.Remove("cigarette");
        }
        public static void useCuffs(Player_R2 user, Player_R2 target)
        {
            if (target.Cuffed > 0)
            {
                Console.WriteLine("they're already cuffed. (item not consumed)");
            } else
            {
                target.Cuffed = 1;
                user.Inv.Remove("cuffs");
            }
        }
    }
}
