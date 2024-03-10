using System;

namespace buckshot
{
    internal class Items
    {
        public static void UseBeer(Player_R2 p, Shotgun shotgun)
        {
            Console.WriteLine($"you unloaded a {Utils.GetCurrentShell(shotgun)} shell");
            shotgun.Shoot();
            p.Inv.Remove("beer");
        }
        public static void UseKnife(Player_R2 p, Shotgun shotgun)
        {
            Console.WriteLine("the next shot will deal 2 damage");
            shotgun.dmg = 2;
            p.Inv.Remove("knife");
        }
        public static void UseGlass(Player_R2 p, Shotgun shotgun)
        {
            Console.WriteLine($"the shell in the chamber is {Utils.GetCurrentShell(shotgun)}");
            p.Inv.Remove("magnifying glass");
        }
        public static void UseCig(Player_R2 p)
        {
            if (p.Lives == p.lifeCap)
            {
                Console.WriteLine("you already have max lives. (item consumed)");
            } else
            {
                p.Heal();
            }
            p.Inv.Remove("cigarette");
        }
        public static void UseCuffs(Player_R2 user, Player_R2 target, Shotgun shotgun)
        {
            if (target.Cuffed > 0)
            {
                Console.WriteLine("they're already cuffed. (item not consumed)");
                user.Turn(shotgun);
            } else
            {
                target.Cuffed = 1;
                user.Inv.Remove("cuffs");
            }
        }
    }
}
