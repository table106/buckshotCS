﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace buckshot
{
    internal class Buckshot
    {
        public string input(string input)
        {
            Console.WriteLine(input);
            string val = Console.ReadLine();
            return val;
        }
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("well hello there! welcome to...");
            Thread.Sleep(3000);
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
            Console.Clear();
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
            else if (ans == "therealtable")
            {
                string[] keys = { "1", "2", "3", "3P" };
                Console.WriteLine("hello world!");
                string _ans;
                do
                {
                    Console.WriteLine("where to?\n>");
                    _ans = Console.ReadLine();
                    if (_ans == "1")
                    {
                        shotgun.empty();
                        Player plr1 = new Player(1, "plr1", 2);
                        Player plr2 = new Player(2, "plr2", 2);
                        Utils.initOpponents(plr1, plr2);
                        Player[] plrs = { plr1, plr2 };
                        Rounds.round1(shotgun, true, plrs);
                    }
                    else if (_ans == "2")
                    {
                        shotgun.empty();
                        Player_R2 plr1 = new Player_R2(1, "plr1", 4, 0);
                        Player_R2 plr2 = new Player_R2(2, "plr2", 4, 0);
                        Utils.initOpponents(plr1, plr2);
                        Player_R2[] plrs = { plr1, plr2 };
                        Rounds.round2(shotgun, true, plrs);
                    }
                    else if (_ans == "3")
                    {
                        shotgun.empty();
                        Player_R3 plr1 = new Player_R3(1, "plr1", 6, 0);
                        Player_R3 plr2 = new Player_R3(2, "plr2", 6, 0);
                        Utils.initOpponents(plr1, plr2);
                        Player_R3[] plrs = { plr1, plr2 };
                        Rounds.round3(shotgun, true, plrs);
                    }
                    else if (_ans == "3P")
                    {
                        string[] _keys = { "1", "2", "3" };
                        string __ans;
                        do
                        {
                            Console.WriteLine("where to? (3P mode)\n>");
                            __ans = Console.ReadLine();
                            if (__ans == "1")
                            {
                                shotgun.empty();
                                Player plr1 = new Player(1, "plr1", 2);
                                Player plr2 = new Player(2, "plr2", 2);
                                Player plr3 = new Player(3, "plr3", 2);
                                Utils.initOpponents(plr1, plr2, plr3);
                                Player[] plrs = { plr1, plr2, plr3 };
                                Rounds.round1(shotgun, true, plrs);
                            }
                            else if (__ans == "2")
                            {
                                shotgun.empty();
                                Player_R2 plr1 = new Player_R2(1, "plr1", 4, 0);
                                Player_R2 plr2 = new Player_R2(2, "plr2", 4, 0);
                                Player_R2 plr3 = new Player_R2(3, "plr3", 4, 0);
                                Utils.initOpponents(plr1, plr2, plr3);
                                Player_R2[] plrs = { plr1, plr2, plr3 };
                                Rounds.round2(shotgun, true, plrs);
                            }
                            else if (__ans == "3")
                            {
                                Player_R3 plr1 = new Player_R3(1, "plr1", 6, 0);
                                Player_R3 plr2 = new Player_R3(2, "plr2", 6, 0);
                                Player_R3 plr3 = new Player_R3(3, "plr3", 6, 0);
                                Utils.initOpponents(plr1, plr2, plr3);
                                Player_R3[] plrs = { plr1, plr2, plr3 };
                                Rounds.round3(shotgun, true, plrs);
                            }
                        } while (_keys.Contains(__ans));
                        break;
                    }
                } while (keys.Contains(_ans));
                Console.WriteLine("ending your testmode session");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
            else if (ans == "actuallytheres3")
            {
                Console.WriteLine("what does player 1 call themselves?\n>");
                Player player1 = new Player(1, Console.ReadLine(), 2);

                Console.WriteLine("what about player 2?\n>");
                Player player2 = new Player(2, Console.ReadLine(), 2);

                string[] names = { player1.name };
                while (!Utils.checkNames(player2.name, names))
                {
                    Console.WriteLine("pick another name.\n>");
                    player2 = new Player(2, Console.ReadLine(), 2);
                }

                Console.WriteLine("and player 3?");
                Player player3 = new Player(3, Console.ReadLine(), 2);

                string[] _names = { player1.name, player2.name };
                while (!Utils.checkNames(player3.name, _names))
                {
                    Console.WriteLine("pick another name.\n>");
                    player3 = new Player(3, Console.ReadLine(), 2);
                }

                Utils.initOpponents(player1, player2, player3);
                Player[] plrs = { player1, player2, player3 };

                Console.WriteLine("good luck.");
                Thread.Sleep(3000);

                Rounds.round1(shotgun, false, plrs);

                Console.WriteLine("all of you can now have items. (max 8)");
                Thread.Sleep(3000);

                Player_R2 _player1 = new Player_R2(1, player1.name, 4, player1.wins);
                Player_R2 _player2 = new Player_R2(2, player2.name, 4, player2.wins);
                Player_R2 _player3 = new Player_R2(3, player3.name, 4, player3.wins);
                Utils.initOpponents(player1, player2, player3);
                Player_R2[] _plrs = { _player1, _player2, _player3 };
                shotgun.empty();

                _player1.getItem(1);
                _player2.getItem(1);
                _player3.getItem(1);

                Rounds.round2(shotgun, false, _plrs);

                Console.Clear();
                Console.WriteLine("let's make this a little bit more interesting.");
                Thread.Sleep(2000);
                Console.WriteLine("now, when you reach less than 3 lives, your defibrillator will be cut.\nthe life display will glitch when that happens");
                Thread.Sleep(4000);

                Player_R3 __player1 = new Player_R3(1, player1.name, 6, _player1.wins);
                Player_R3 __player2 = new Player_R3(2, player2.name, 6, _player2.wins);
                Player_R3 __player3 = new Player_R3(3, player3.name, 6, _player3.wins);
                Utils.initOpponents(__player1, __player2, __player3);
                Player_R3[] __plrs = { __player1, __player2, __player3 };
                shotgun.empty();

                __player1.getItem(2);
                __player2.getItem(2);
                __player3.getItem(2);

                Rounds.round3(shotgun, false, __plrs);

                Console.Clear();
                Console.WriteLine("you finished the game!\nexiting in 5 seconds");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("what does player 1 call themselves?\n>");
                Player player1 = new Player(1, Console.ReadLine(), 2);

                Console.WriteLine("what about player 2?\n>");
                Player player2 = new Player(2, Console.ReadLine(), 2);

                Utils.initOpponents(player1, player2);
                Player[] plrs = { player1, player2 };

                Console.WriteLine("good luck.");
                Thread.Sleep(2000);

                Rounds.round1(shotgun, false, plrs);

                shotgun.empty();
                Player_R2 _player1 = new Player_R2(1, player1.name, 4, player1.wins);
                Player_R2 _player2 = new Player_R2(2, player2.name, 4, player2.wins);

                Utils.initOpponents(_player1, _player2);
                Player_R2[] _plrs = { _player1, _player2 };

                Rounds.round2(shotgun, false, _plrs);

                Console.Clear();
                Console.WriteLine("let's make this a little bit more interesting.");
                Thread.Sleep(2000);
                Console.WriteLine("now, when you reach less than 3 lives, your defibrillator will be cut.\nthe life display will glitch when that happens");
                Thread.Sleep(4000);

                shotgun.empty();
                Player_R3 __player1 = new Player_R3(1, player1.name, 6, _player1.wins);
                Player_R3 __player2 = new Player_R3(2, player2.name, 6, _player2.wins);

                Utils.initOpponents(__player1, __player2);
                Player_R3[] __plrs = { __player1, __player2 };

                Rounds.round3(shotgun, false, __plrs);

                Console.Clear();
                if (__player1.wins > __player2.wins)
                {
                    Console.WriteLine($"{__player1.name} wins with a score of {__player1.wins} to {__player2.wins}");
                }
                else if (__player2.wins > __player1.wins)
                {
                    Console.WriteLine($"{__player2.name} wins with a score of {__player2.wins} to {__player1.wins}");
                }
                Thread.Sleep(5000);
            }
            Console.Clear();
            Console.WriteLine("end");
            Thread.Sleep(2);
            Console.WriteLine("engage again?\nyes/no");
            string ans_ = Console.ReadLine();
            if (ans_ == "yes")
            {
                Main(args);
            } else
            {
                Environment.Exit(0);
            }
        }
    }
}
