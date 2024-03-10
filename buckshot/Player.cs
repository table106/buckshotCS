using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace buckshot
{
    internal class Player
    {
        public int num;
        public string name;
        public List<Player> opponents = new List<Player>();
        protected int _lives;

        public int Lives
        {
            get { return _lives; }
            set {
                if (value > _lives)
                {
                    _lives = 1;
                } else
                {
                    _lives = value;
                }
            }
        }
        protected int _wins;
        public int Wins
        {
            get { return _wins; }
            set
            {
                if (value > 2)
                {
                    _wins = 1;
                } else
                {
                    _wins = value;
                }
            }
        }


        public Player(int num, string name, int lives) { 
            this.num = num;
            this.name = name;
            _lives = lives;
            _wins = 0;
            opponents = new List<Player>();
        }
        public override string ToString()
        {
            if (_lives > 1)
            {
                return $@"{name}'s turn
you have {_lives} lives
type to use:
shoot - shotgun";
            }
            return $@"{name}'s turn
you have 1 life
type to use:
shoot - shotgun";
        }
        public void AddOpponent(Player p)
        {
            opponents.Add(p);
        }
        public void TakeDmg(int dmg=1)
        {
            _lives -= dmg;
        }
        public virtual void Turn(Shotgun shotgun)
        {
            Console.WriteLine(this);
            Console.WriteLine("type to use:\nshoot - shotgun\n>");
            string ans = Console.ReadLine();
            switch (ans)
            {
                case "shoot":
                    {
                        Console.WriteLine("shoot self or enemy?\n>");
                        string _ans = Console.ReadLine();
                        switch (_ans)
                        {
                            case "self":
                                {
                                    Thread.Sleep(4000);
                                    if (Utils.GetCurrentShell(shotgun) == "live")
                                    {
                                        Console.WriteLine("BANG");
                                        shotgun.Shoot();
                                        TakeDmg(1);
                                    } else if (Utils.GetCurrentShell(shotgun) == "blank")
                                    {
                                        Console.WriteLine("*click");
                                        shotgun.Shoot();
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        if (shotgun.Content.Count() != 0)
                                        {
                                            Turn(shotgun);
                                        }
                                    }
                                    break;
                                }
                            case "enemy":
                                {
                                    if (opponents.Count() > 1)
                                    {
                                        Console.WriteLine($"who will you shoot?\n{string.Join(", ",opponents)}\n>");
                                        string __ans = Console.ReadLine();
                                        Thread.Sleep(4000);
                                        if (Utils.GetCurrentShell(shotgun) == "live")
                                        {
                                            Console.WriteLine("BANG");
                                            shotgun.Shoot();
                                            foreach (Player p in opponents)
                                            {
                                                if (p.name == __ans)
                                                {
                                                    p.TakeDmg(1);
                                                }
                                            }
                                        } else if (Utils.GetCurrentShell(shotgun) == "blank")
                                        {
                                            Console.WriteLine("*click");
                                            shotgun.Shoot();
                                        }
                                    } else
                                    {
                                        Thread.Sleep(4000);
                                        if (Utils.GetCurrentShell(shotgun) == "live")
                                        {
                                            Console.WriteLine("BANG");
                                            shotgun.Shoot();
                                            opponents[0].TakeDmg(1);
                                        } else if (Utils.GetCurrentShell(shotgun) == "blank")
                                        {
                                            Console.WriteLine("*click");
                                            shotgun.Shoot();
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("failed to pick a target");
                                    break;
                                }
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("failed to pick an action");
                        break;
                    }
            }
            Thread.Sleep(2000);
            Console.Clear();
        }
    }
    internal class Player_R2 : Player
    {
        public new List<Player_R2> opponents = new List<Player_R2>();
        protected List<string> _inv;
        public List<string> Inv
        {
            get { return _inv; }
            set { _inv = value; }
        }
        protected int _cuffed;
        public int Cuffed
        {
            get { return _cuffed; }
            set { _cuffed = value; }
        }
        public int lifeCap;
        public Player_R2(int num, string name, int lives, int wins) : base(num,name,lives) {
            this.num = num;
            this.name = name;
            _lives = lives;
            _wins = wins;
            opponents = new List<Player_R2>();
            _inv = new List<string>();
            _cuffed = 0;
        }
        public override string ToString()
        {
            if (_lives > 1)
            {
                return $@"{name}'s turn
you have {_lives} lives
your items: {_inv}
type to use:
shoot - shotgun
item - item";
            }
            return $@"{name}'s turn
you have 1 life
your items: {_inv}
type to use:
shoot - shotgun
item - item";
        }
        public void Heal()
        {
            _lives += 1;
        }
        public void GetItem(int much)
        {
            string[] allItems = {"beer","knife","magnifying glass","cigarette","cuffs"};
            Random rnd = new Random();
            for (int i = much; i > 0; i--)
            {
                int id1 = rnd.Next(0,4);
                int id2 = rnd.Next(0,4);
                _inv.Add(allItems[id1]);
                _inv.Add(allItems[id2]);
                Console.WriteLine($"{name} got {allItems[id1]} and {allItems[id2]}");
                Thread.Sleep(2000);
            }
        }
        public void UseItem(string item, Shotgun shotgun=null, Player_R2 target=null)
        {
            switch (item)
            {
                case "beer":
                    {
                        Items.UseBeer(this, shotgun);
                        break;
                    }
                case "knife":
                    {
                        Items.UseKnife(this, shotgun);
                        break;
                    }
                case "magnifying glass":
                    {
                        Items.UseGlass(this, shotgun);
                        break;
                    }
                case "cigarette":
                    {
                        Items.UseCig(this);
                        break;
                    }
                case "cuffs":
                    {
                        Items.UseCuffs(this, target, shotgun);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("failed to pick an item");
                        break;
                    }
            }
        }
        public override void Turn(Shotgun shotgun)
        {
            Console.WriteLine(this);
            Console.WriteLine("type to use:\nshoot - shotgun\n>");
            string ans = Console.ReadLine();
            switch (ans)
            {
                case "shoot":
                    {
                        Console.WriteLine("shoot self or enemy?\n>");
                        string _ans = Console.ReadLine();
                        switch (_ans)
                        {
                            case "self":
                                {
                                    Thread.Sleep(4000);
                                    if (Utils.GetCurrentShell(shotgun) == "live")
                                    {
                                        Console.WriteLine("BANG");
                                        shotgun.Shoot();
                                        TakeDmg(1);
                                    }
                                    else if (Utils.GetCurrentShell(shotgun) == "blank")
                                    {
                                        Console.WriteLine("*click");
                                        shotgun.Shoot();
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        if (shotgun.Content.Count() != 0)
                                        {
                                            Turn(shotgun);
                                        }
                                    }
                                    break;
                                }
                            case "enemy":
                                {
                                    if (opponents.Count() > 1)
                                    {
                                        Console.WriteLine($"who will you shoot?\n{string.Join(", ", opponents)}\n>");
                                        string __ans = Console.ReadLine();
                                        Thread.Sleep(4000);
                                        if (Utils.GetCurrentShell(shotgun) == "live")
                                        {
                                            Console.WriteLine("BANG");
                                            shotgun.Shoot();
                                            foreach (Player p in opponents)
                                            {
                                                if (p.name == __ans)
                                                {
                                                    p.TakeDmg(1);
                                                }
                                            }
                                        }
                                        else if (Utils.GetCurrentShell(shotgun) == "blank")
                                        {
                                            Console.WriteLine("*click");
                                            shotgun.Shoot();
                                        }
                                    }
                                    else
                                    {
                                        Thread.Sleep(4000);
                                        if (Utils.GetCurrentShell(shotgun) == "live")
                                        {
                                            Console.WriteLine("BANG");
                                            shotgun.Shoot();
                                            opponents[0].TakeDmg(1);
                                        }
                                        else if (Utils.GetCurrentShell(shotgun) == "blank")
                                        {
                                            Console.WriteLine("*click");
                                            shotgun.Shoot();
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("failed to pick a target");
                                    break;
                                }
                        }
                        break;
                    }
                case "item":
                    {
                        Console.WriteLine($"pick an item\n{string.Join(", ",_inv)}");
                        string _ans = Utils.Input(">");
                        if (_ans == "cuffs" && opponents.Count() > 1)
                        {
                            Console.WriteLine($"who are you using them on?\n{string.Join(", ",opponents)}");
                            string __ans = Console.ReadLine();
                            foreach (Player_R2 op in opponents)
                            {
                                if (op.name == __ans)
                                {
                                    UseItem("cuffs", shotgun, op);
                                }
                            }
                        } else if (_ans == "cuffs")
                        {
                            UseItem("cuffs", shotgun, opponents[0]);
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("failed to pick an action");
                        break;
                    }
            }
            Thread.Sleep(2000);
            Console.Clear();
        }
    }
    internal class Player_R3 : Player_R2
    {
        public new List<Player_R3> opponents = new List<Player_R3>();
        public bool lifeLocked;
        public Player_R3(int num, string name, int lives, int wins) : base(num,name,lives,wins)
        {
            this.num = num;
            this.name = name;
            _lives = lives;
            _wins = wins;
            opponents = new List<Player_R3>();
            _inv = new List<string>();
            _cuffed = 0;
            lifeLocked = false;
        }
        public override string ToString()
        {
            if (_lives > 2)
            {
                return $@"{name}'s turn
you have {_lives} lives
your items: {_inv}
type to use:
shoot - shotgun
item - item";
            }
            lifeLocked = true;
            return $@"{name}'s turn
you have # lives
your items: {_inv}
type to use:
shoot - shotgun
item - item";
        }
    }
}
