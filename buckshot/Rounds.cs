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
        public static void round1(Shotgun shotgun, bool testmode, Player[] players)
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
                    shotgun.insertShells(lives, blanks);
                    Console.Clear();
                    Console.WriteLine($"LOADED SHELLS: {lives} LIVE, {blanks} BLANK");
                    Thread.Sleep(5000);
                    Console.Clear();
                    while (player1.Lives > 0 && player2.Lives > 0 && player3.Lives > 0 && shotgun.content.Count != 0)
                    {
                        Console.Clear();
                        player1.turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0 || player3.Lives == 0)
                        {
                            break;
                        }
                        player2.turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0 || player3.Lives == 0)
                        {
                            break;
                        }
                        player3.turn(shotgun);
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
                    shotgun.insertShells(lives, blanks);
                    Console.Clear();
                    Console.WriteLine($"LOADED SHELLS: {lives} LIVE, {blanks} BLANK");
                    Thread.Sleep(5000);
                    Console.Clear();
                    while (player1.Lives > 0 && player2.Lives > 0 && shotgun.content.Count != 0)
                    {
                        Console.Clear();
                        player1.turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0)
                        {
                            break;
                        }
                        player2.turn(shotgun);
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
        public static void round2(Shotgun shotgun, bool testmode, Player_R2[] players) {
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
                    shotgun.insertShells(lives, blanks);
                    Console.Clear();
                    Console.WriteLine($"LOADED SHELLS: {lives} LIVE, {blanks} BLANK");
                    Thread.Sleep(5000);
                    Console.Clear();
                    while (player1.Lives > 0 && player2.Lives > 0 && player3.Lives > 0 && shotgun.content.Count != 0)
                    {
                        Console.Clear();
                        player1.turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0 || player3.Lives == 0)
                        {
                            break;
                        }
                        player2.turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0 || player3.Lives == 0)
                        {
                            break;
                        }
                        player3.turn(shotgun);
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
                    shotgun.insertShells(lives, blanks);
                    Console.Clear();
                    Console.WriteLine($"LOADED SHELLS: {lives} LIVE, {blanks} BLANK");
                    Thread.Sleep(5000);
                    Console.Clear();
                    while (player1.Lives > 0 && player2.Lives > 0 && shotgun.content.Count != 0)
                    {
                        Console.Clear();
                        player1.turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0)
                        {
                            break;
                        }
                        player2.turn(shotgun);
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
        public static void round3(Shotgun shotgun, bool testmode, Player_R3[] players)
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
                    shotgun.insertShells(lives, blanks);
                    Console.Clear();
                    Console.WriteLine($"LOADED SHELLS: {lives} LIVE, {blanks} BLANK");
                    Thread.Sleep(5000);
                    Console.Clear();
                    while (player1.Lives > 0 && player2.Lives > 0 && player3.Lives > 0 && shotgun.content.Count != 0)
                    {
                        Console.Clear();
                        player1.turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0 || player3.Lives == 0)
                        {
                            break;
                        }
                        player2.turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0 || player3.Lives == 0)
                        {
                            break;
                        }
                        player3.turn(shotgun);
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
                    shotgun.insertShells(lives, blanks);
                    Console.Clear();
                    Console.WriteLine($"LOADED SHELLS: {lives} LIVE, {blanks} BLANK");
                    Thread.Sleep(5000);
                    Console.Clear();
                    while (player1.Lives > 0 && player2.Lives > 0 && shotgun.content.Count != 0)
                    {
                        Console.Clear();
                        player1.turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0)
                        {
                            break;
                        }
                        player2.turn(shotgun);
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
