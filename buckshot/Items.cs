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
            p.inv.Remove("beer");
        }
        public static void useKnife(Player_R2 p, Shotgun shotgun)
        {
            Console.WriteLine("the next shot will deal 2 damage");
            shotgun.dmg = 2;
            p.inv.Remove("knife");
        }
        public static void useGlass(Player_R2 p, Shotgun shotgun)
        {
            Console.WriteLine($"the shell in the chamber is {Utils.getCurrentShell(shotgun)}");
            p.inv.Remove("magnifying glass");
        }
        public static void useCig(Player_R2 p)
        {
            if (p.lives == p.lifeCap)
            {
                Console.WriteLine("you already have max lives. (item consumed)");
            } else
            {
                p.heal();
            }
            p.inv.Remove("cigarette");
        }
        public static void useCuffs(Player_R2 user, Player_R2 target)
        {
            if (target.cuffed > 0)
            {
                Console.WriteLine("they're already cuffed. (item not consumed)");
            } else
            {
                target.cuffed = 1;
                user.inv.Remove("cuffs");
            }
        }
    }
}
