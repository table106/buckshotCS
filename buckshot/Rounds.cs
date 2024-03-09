using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace buckshot
{
    internal class Rounds
    {
        public static void Round1(Shotgun shotgun, bool testmode, Player[] players)
        {
            Player player1 = players[0];
            Player player2 = players[1];
            Random rnd = new Random();
            if (players.Length > 2)
            {
                Player player3 = players[2];
                while (player1.Lives > 0 && player2.Lives > 0 && player3.Lives > 0)
                {
                    int lives = rnd.Next(1, 5);
                    int blanks = rnd.Next(1, 5);
                    shotgun.InsertShells(lives, blanks);
                    Console.Clear();
                    Console.WriteLine($"LOADED SHELLS: {lives} LIVE, {blanks} BLANK");
                    Thread.Sleep(5000);
                    Console.Clear();
                    while (player1.Lives > 0 && player2.Lives > 0 && player3.Lives > 0 && shotgun.content.Count != 0)
                    {
                        Console.Clear();
                        if (testmode)
                        {
                            Console.WriteLine("num | name | lives | wins");
                            foreach (Player plr in players)
                            {
                                Console.WriteLine($"{plr.num} | {plr.name} | {plr.Lives} | {plr.Wins}");
                            }
                        }
                        player1.Turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0 || player3.Lives == 0)
                        {
                            break;
                        }
                        if (testmode)
                        {
                            Console.WriteLine("num | name | lives | wins");
                            foreach (Player plr in players)
                            {
                                Console.WriteLine($"{plr.num} | {plr.name} | {plr.Lives} | {plr.Wins}");
                            }
                        }
                        player2.Turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0 || player3.Lives == 0)
                        {
                            break;
                        }
                        if (testmode)
                        {
                            Console.WriteLine("num | name | lives | wins");
                            foreach (Player plr in players)
                            {
                                Console.WriteLine($"{plr.num} | {plr.name} | {plr.Lives} | {plr.Wins}");
                            }
                        }
                        player3.Turn(shotgun);
                        Console.Clear();
                    }
                }
                if (player1.Lives == 0)
                {
                    Console.WriteLine($"{player2.name} and {player3.name} both get a win. end of round 1");
                    player2.Wins++;
                    player3.Wins++;
                } else if (player2.Lives == 0)
                {
                    Console.WriteLine($"{player1.name} and {player3.name} both get a win. end of round 1");
                    player1.Wins++;
                    player3.Wins++;
                } else if (player3.Lives == 0)
                {
                    Console.WriteLine($"{player1.name} and {player2.name} both get a win. end of round 1");
                    player1.Wins++;
                    player2.Wins++;
                }
            } else
            {
                while (player1.Lives > 0 && player2.Lives > 0)
                {
                    int lives = rnd.Next(1, 5);
                    int blanks = rnd.Next(1, 5);
                    shotgun.InsertShells(lives, blanks);
                    Console.Clear();
                    Console.WriteLine($"LOADED SHELLS: {lives} LIVE, {blanks} BLANK");
                    Thread.Sleep(5000);
                    Console.Clear();
                    while (player1.Lives > 0 && player2.Lives > 0 && shotgun.content.Count != 0)
                    {
                        Console.Clear();
                        if (testmode)
                        {
                            Console.WriteLine("num | name | lives | wins");
                            foreach (Player plr in players)
                            {
                                Console.WriteLine($"{plr.num} | {plr.name} | {plr.Lives} | {plr.Wins}");
                            }
                        }
                        player1.Turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0)
                        {
                            break;
                        }
                        if (testmode)
                        {
                            Console.WriteLine("num | name | lives | wins");
                            foreach (Player plr in players)
                            {
                                Console.WriteLine($"{plr.num} | {plr.name} | {plr.Lives} | {plr.Wins}");
                            }
                        }
                        player2.Turn(shotgun);
                        Console.Clear();
                    }
                }
                if (player1.Lives == 0)
                {
                    Console.WriteLine($"{player2.name} wins. end of round 1");
                    player2.Wins++;
                } else if (player2.Lives == 0)
                {
                    Console.WriteLine($"{player1.name} wins. end of round 1");
                    player1.Wins++;
                }
            }
            Thread.Sleep(5000);
        }
        public static void Round2(Shotgun shotgun, bool testmode, Player_R2[] players) {
            Player_R2 player1 = players[0];
            Player_R2 player2 = players[1];
            Random rnd = new Random();
            if (players.Length > 2)
            {
                Player_R2 player3 = players[2];
                while (player1.Lives > 0 && player2.Lives > 0 && player3.Lives > 0)
                {
                    int lives = rnd.Next(1, 5);
                    int blanks = rnd.Next(1, 5);
                    shotgun.InsertShells(lives, blanks);
                    Console.Clear();
                    Console.WriteLine($"LOADED SHELLS: {lives} LIVE, {blanks} BLANK");
                    Thread.Sleep(5000);
                    Console.Clear();
                    while (player1.Lives > 0 && player2.Lives > 0 && player3.Lives > 0 && shotgun.content.Count != 0)
                    {
                        Console.Clear();
                        if (testmode)
                        {
                            Console.WriteLine("num | name | lives | wins | inventory | cuffed state");
                            foreach (Player_R2 plr in players)
                            {
                                Console.WriteLine($"{plr.num} | {plr.name} | {plr.Lives} | {plr.Wins} | {string.Join(", ", plr.Inv)} | {plr.Cuffed}");
                            }
                        }
                        player1.Turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0 || player3.Lives == 0)
                        {
                            break;
                        }
                        if (testmode)
                        {
                            Console.WriteLine("num | name | lives | wins | inventory | cuffed state");
                            foreach (Player_R2 plr in players)
                            {
                                Console.WriteLine($"{plr.num} | {plr.name} | {plr.Lives} | {plr.Wins} | {string.Join(", ", plr.Inv)} | {plr.Cuffed}");
                            }
                        }
                        player2.Turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0 || player3.Lives == 0)
                        {
                            break;
                        }
                        if (testmode)
                        {
                            Console.WriteLine("num | name | lives | wins | inventory | cuffed state");
                            foreach (Player_R2 plr in players)
                            {
                                Console.WriteLine($"{plr.num} | {plr.name} | {plr.Lives} | {plr.Wins} | {string.Join(", ", plr.Inv)} | {plr.Cuffed}");
                            }
                        }
                        player3.Turn(shotgun);
                        Console.Clear();
                    }
                }
                if (player1.Lives == 0)
                {
                    Console.WriteLine($"{player2.name} and {player3.name} both get a win. end of round 2");
                    player2.Wins++;
                    player3.Wins++;
                }
                else if (player2.Lives == 0)
                {
                    Console.WriteLine($"{player1.name} and {player3.name} both get a win. end of round 2");
                    player1.Wins++;
                    player3.Wins++;
                }
                else if (player3.Lives == 0)
                {
                    Console.WriteLine($"{player1.name} and {player2.name} both get a win. end of round 2");
                    player1.Wins++;
                    player2.Wins++;
                }
            }
            else
            {
                while (player1.Lives > 0 && player2.Lives > 0)
                {
                    int lives = rnd.Next(1, 5);
                    int blanks = rnd.Next(1, 5);
                    shotgun.InsertShells(lives, blanks);
                    Console.Clear();
                    Console.WriteLine($"LOADED SHELLS: {lives} LIVE, {blanks} BLANK");
                    Thread.Sleep(5000);
                    Console.Clear();
                    while (player1.Lives > 0 && player2.Lives > 0 && shotgun.content.Count != 0)
                    {
                        Console.Clear();
                        if (testmode)
                        {
                            Console.WriteLine("num | name | lives | wins | inventory | cuffed state");
                            foreach (Player_R2 plr in players)
                            {
                                Console.WriteLine($"{plr.num} | {plr.name} | {plr.Lives} | {plr.Wins} | {string.Join(", ", plr.Inv)} | {plr.Cuffed}");
                            }
                        }
                        player1.Turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0)
                        {
                            break;
                        }
                        if (testmode)
                        {
                            Console.WriteLine("num | name | lives | wins | inventory | cuffed state");
                            foreach (Player_R2 plr in players)
                            {
                                Console.WriteLine($"{plr.num} | {plr.name} | {plr.Lives} | {plr.Wins} | {string.Join(", ", plr.Inv)} | {plr.Cuffed}");
                            }
                        }
                        player2.Turn(shotgun);
                        Console.Clear();
                    }
                }
                if (player1.Lives == 0)
                {
                    Console.WriteLine($"{player2.name} wins. end of round 2");
                    player2.Wins++;
                }
                else if (player2.Lives == 0)
                {
                    Console.WriteLine($"{player1.name} wins. end of round 2");
                    player1.Wins++;
                }
            }
            Thread.Sleep(5000);
        }
        public static void Round3(Shotgun shotgun, bool testmode, Player_R3[] players)
        {
            Player_R3 player1 = players[0];
            Player_R3 player2 = players[1];
            Random rnd = new Random();
            if (players.Length > 2)
            {
                Player_R3 player3 = players[2];
                while (player1.Lives > 0 && player2.Lives > 0 && player3.Lives > 0)
                {
                    int lives = rnd.Next(1, 5);
                    int blanks = rnd.Next(1, 5);
                    shotgun.InsertShells(lives, blanks);
                    Console.Clear();
                    Console.WriteLine($"LOADED SHELLS: {lives} LIVE, {blanks} BLANK");
                    Thread.Sleep(5000);
                    Console.Clear();
                    while (player1.Lives > 0 && player2.Lives > 0 && player3.Lives > 0 && shotgun.content.Count != 0)
                    {
                        Console.Clear();
                        if (testmode)
                        {
                            Console.WriteLine("num | name | lives | wins | inventory | cuffed state | lifelocked");
                            foreach (Player_R3 plr in players)
                            {
                                Console.WriteLine($"{plr.num} | {plr.name} | {plr.Lives} | {plr.Wins} | {string.Join(", ", plr.Inv)} | {plr.Cuffed} | {plr.lifeLocked}");
                            }
                        }
                        player1.Turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0 || player3.Lives == 0)
                        {
                            break;
                        }
                        if (testmode)
                        {
                            Console.WriteLine("num | name | lives | wins | inventory | cuffed state | lifelocked");
                            foreach (Player_R3 plr in players)
                            {
                                Console.WriteLine($"{plr.num} | {plr.name} | {plr.Lives} | {plr.Wins} | {string.Join(", ", plr.Inv)} | {plr.Cuffed} | {plr.lifeLocked}");
                            }
                        }
                        player2.Turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0 || player3.Lives == 0)
                        {
                            break;
                        }
                        if (testmode)
                        {
                            Console.WriteLine("num | name | lives | wins | inventory | cuffed state | lifelocked");
                            foreach (Player_R3 plr in players)
                            {
                                Console.WriteLine($"{plr.num} | {plr.name} | {plr.Lives} | {plr.Wins} | {string.Join(", ", plr.Inv)} | {plr.Cuffed} | {plr.lifeLocked}");
                            }
                        }
                        player3.Turn(shotgun);
                        Console.Clear();
                    }
                }
                if (player1.Lives == 0)
                {
                    Console.WriteLine($"{player2.name} and {player3.name} both get a win. end of round 2");
                    player2.Wins++;
                    player3.Wins++;
                }
                else if (player2.Lives == 0)
                {
                    Console.WriteLine($"{player1.name} and {player3.name} both get a win. end of round 3");
                    player1.Wins++;
                    player3.Wins++;
                }
                else if (player3.Lives == 0)
                {
                    Console.WriteLine($"{player1.name} and {player2.name} both get a win. end of round 3");
                    player1.Wins++;
                    player2.Wins++;
                }
            }
            else
            {
                while (player1.Lives > 0 && player2.Lives > 0)
                {
                    int lives = rnd.Next(1, 5);
                    int blanks = rnd.Next(1, 5);
                    shotgun.InsertShells(lives, blanks);
                    Console.Clear();
                    Console.WriteLine($"LOADED SHELLS: {lives} LIVE, {blanks} BLANK");
                    Thread.Sleep(5000);
                    Console.Clear();
                    while (player1.Lives > 0 && player2.Lives > 0 && shotgun.content.Count != 0)
                    {
                        Console.Clear();
                        if (testmode)
                        {
                            Console.WriteLine("num | name | lives | wins | inventory | cuffed state | lifelocked");
                            foreach (Player_R3 plr in players)
                            {
                                Console.WriteLine($"{plr.num} | {plr.name} | {plr.Lives} | {plr.Wins} | {string.Join(", ", plr.Inv)} | {plr.Cuffed} | {plr.lifeLocked}");
                            }
                        }
                        player1.Turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0)
                        {
                            break;
                        }
                        if (testmode)
                        {
                            Console.WriteLine("num | name | lives | wins | inventory | cuffed state | lifelocked");
                            foreach (Player_R3 plr in players)
                            {
                                Console.WriteLine($"{plr.num} | {plr.name} | {plr.Lives} | {plr.Wins} | {string.Join(", ", plr.Inv)} | {plr.Cuffed} | {plr.lifeLocked}");
                            }
                        }
                        player2.Turn(shotgun);
                        Console.Clear();
                    }
                }
                if (player1.Lives == 0)
                {
                    Console.WriteLine($"{player2.name} wins. end of round 3");
                    player2.Wins++;
                }
                else if (player2.Lives == 0)
                {
                    Console.WriteLine($"{player1.name} wins. end of round 3");
                    player1.Wins++;
                }
            }
            Thread.Sleep(5000);
        }
    }
}
