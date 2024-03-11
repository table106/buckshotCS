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
        public List<Player> opponents;
        protected int _lives;

        public int Lives
        {
            get { return _lives; }
            set {
                if (value > _lives+1)
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
                if (value > 3)
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
            string ans = Utils.Input();
            switch (ans)
            {
                case "shoot":
                    {
                        string _ans = Utils.Input("shoot self or enemy?");
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
                                        string __ans = Utils.Input($"who will you shoot?\n{string.Join(", ", opponents)}");
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
        public new List<Player_R2> opponents;
        public List<string> inv;
        protected int _cuffed;
        public int Cuffed
        {
            get { return _cuffed; }
            set
            {
                if (value > 2)
                {
                    _cuffed = 0;
                } else
                {
                    _cuffed = value;
                }
            }
        }
        protected int _lifeCap;
        public int LifeCap
        {
            get { return _lifeCap; }
            set
            {
                if (value > _lives)
                {
                    _lifeCap = 1;
                } else
                {
                    _lifeCap = value;
                }
            }
        }
        public Player_R2(int num, string name, int lives, int wins) : base(num,name,lives) {
            this.num = num;
            this.name = name;
            _lives = lives;
            _wins = wins;
            opponents = new List<Player_R2>();
            inv = new List<string>();
            _cuffed = 0;
            _lifeCap = _lives;
        }
        public override string ToString()
        {
            if (_lives > 1)
            {
                return $@"{name}'s turn
you have {_lives} lives
your items: {string.Join(", ", inv)}
type to use:
shoot - shotgun
item - item";
            }
            return $@"{name}'s turn
you have 1 life
your items: {string.Join(", ", inv)}
type to use:
shoot - shotgun
item - item";
        }
        public void AddOpponent(Player_R2 p)
        {
            opponents.Add(p);
        }
        public void Heal()
        {
            _lives += 1;
        }
        public void GetItem(int much)
        {
            string[] allItems = {"beer","knife","magnifying glass","cigarette","cuffs"};
            Random rnd = new Random();
            for (int i = 0; i < much; i++)
            {
                int id1 = rnd.Next(0,4);
                int id2 = rnd.Next(0,4);
                inv.Add(allItems[id1]);
                inv.Add(allItems[id2]);
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
            string ans = Utils.Input();
            switch (ans)
            {
                case "shoot":
                    {
                        string _ans = Utils.Input("shoot self or enemy?");
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
                                        string __ans = Utils.Input($"who will you shoot?\n{string.Join(", ", opponents)}");
                                        Thread.Sleep(4000);
                                        if (Utils.GetCurrentShell(shotgun) == "live")
                                        {
                                            Console.WriteLine("BANG");
                                            shotgun.Shoot();
                                            foreach (Player_R2 p in opponents)
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
                        string _ans = Utils.Input($"pick an item\n{string.Join(", ", inv)}");
                        if (_ans == "cuffs" && opponents.Count() > 1)
                        {
                            string __ans = Utils.Input($"who are you using them on?\n{string.Join(", ", opponents)}");
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
        public new List<Player_R3> opponents;
        public bool lifeLocked;
        public Player_R3(int num, string name, int lives, int wins) : base(num,name,lives,wins)
        {
            this.num = num;
            this.name = name;
            _lives = lives;
            _wins = wins;
            opponents = new List<Player_R3>();
            inv = new List<string>();
            _cuffed = 0;
            lifeLocked = false;
        }
        public override string ToString()
        {
            if (_lives > 2)
            {
                return $@"{name}'s turn
you have {_lives} lives
your items: {string.Join(", ", inv)}
type to use:
shoot - shotgun
item - item";
            }
            lifeLocked = true;
            return $@"{name}'s turn
you have # lives
your items: {string.Join(", ", inv)}
type to use:
shoot - shotgun
item - item";
        }
        public void AddOpponent(Player_R3 p)
        {
            opponents.Add(p);
        }
        public void UseItem(string item, Shotgun shotgun = null, Player_R3 target = null)
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
                        if (lifeLocked)
                        {
                            Console.WriteLine("you smoke one... nothing happens.");
                            inv.Remove("cigarette");
                            break;
                        }
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
            string ans = Utils.Input();
            switch (ans)
            {
                case "shoot":
                    {
                        string _ans = Utils.Input("shoot self or enemy?");
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
                                        string __ans = Utils.Input($"who will you shoot?\n{string.Join(", ", opponents)}");
                                        Thread.Sleep(4000);
                                        if (Utils.GetCurrentShell(shotgun) == "live")
                                        {
                                            Console.WriteLine("BANG");
                                            shotgun.Shoot();
                                            foreach (Player_R3 p in opponents)
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
                        string _ans = Utils.Input($"pick an item\n{string.Join(", ", inv)}");
                        if (_ans == "cuffs" && opponents.Count() > 1)
                        {
                            string __ans = Utils.Input($"who are you using them on?\n{string.Join(", ", opponents)}");
                            foreach (Player_R3 op in opponents)
                            {
                                if (op.name == __ans)
                                {
                                    UseItem("cuffs", shotgun, op);
                                }
                            }
                        }
                        else if (_ans == "cuffs")
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
}
