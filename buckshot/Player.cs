using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buckshot
{
    internal class Player
    {
        public int num;
        public string name;
        public int lives;
        public int wins;
        public int lifeCap;
        public List<Player> opponents = new List<Player>();
        public Player(int num, string name, int lives) { 
            this.num = num;
            this.name = name;
            this.lives = lives;
            wins = 0;
            lifeCap = this.lives;
            opponents = new List<Player>();
        }
        public override string ToString()
        {
            if (lives > 1)
            {
                return $@"{name}'s turn
                    you have {lives} lives
                    type to use:
                    shoot - shotgun";
            }
            return $@"{name}'s turn
                you have 1 life
                type to use:
                shoot - shotgun";
        }
        public void addOpponent(Player p)
        {
            opponents.Add(p);
        }
        public void takeDmg(int dmg=1)
        {
            lives -= dmg;
        }
        public virtual void turn(Shotgun shotgun)
        {
            Console.WriteLine(this);
            Console.WriteLine("type to use:\nshoot - shotgun\n>"); // you finished here!
            string ans = Console.ReadLine();
        }
    }
}
