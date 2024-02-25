using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace buckshot
{
    internal class Buckshot
    {
        static void Main(string[] args)
        {
            Utils.Clear();
            Console.WriteLine("well hello there! welcome to...");
            Thread.Sleep(300);
            Console.WriteLine("=======================");
            Console.WriteLine("|| BUCKSHOT ROULETTE ||");
            Console.WriteLine("|| (console version) ||");
            Console.WriteLine("=======================");
            Console.WriteLine("version c0.1-beta");
            Console.WriteLine(@"press enter to start
                or type 'how' for instructions");
            Shotgun shotgun = new Shotgun();
            string ans = Console.ReadLine();
            Console.Beep();
            Utils.Clear();
            if (ans == "how")
            {
                Console.WriteLine(@"alright, so
there's a shotgun
every time it is empty we load some shells in
they can be blank, or live, and will be in a random sequence
you only get the numbers though!
every turn, you use the shotgun
you point it either at yourself, or your enemy
if you shoot yourself with a blank you get to go again!
              
ITEMS(from round 2 onwards)
    - beer:
you eject a round from the shotgun, if its the last one we reload the shotgun
                    
    - knife:
you saw the shotgun, next shot will deal 2 damage
                    
    - magnifying glass:
you look into the chamber, revealing the shell inside only to you
                    
    - cigarette:
you regain a life(not how it works irl)
                    
    - cuffs:
you cuff your enemy skipping their next turn");
                Console.WriteLine("when you finish reading, press any key");
                Console.ReadKey();
            }
        }
    }
}
