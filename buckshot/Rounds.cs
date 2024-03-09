using System;
using System.Threading;

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
                            LogR1(players);
                        }
                        player1.Turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0 || player3.Lives == 0)
                        {
                            break;
                        }
                        if (testmode)
                        {
                            LogR1(players);
                        }
                        player2.Turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0 || player3.Lives == 0)
                        {
                            break;
                        }
                        if (testmode)
                        {
                            LogR1(players);
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
                            LogR1(players);
                        }
                        player1.Turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0)
                        {
                            break;
                        }
                        if (testmode)
                        {
                            LogR1(players);
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
                            LogR2(players);
                        }
                        player1.Turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0 || player3.Lives == 0)
                        {
                            break;
                        }
                        if (testmode)
                        {
                            LogR2(players);
                        }
                        player2.Turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0 || player3.Lives == 0)
                        {
                            break;
                        }
                        if (testmode)
                        {
                            LogR2(players);
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
                            LogR2(players);
                        }
                        player1.Turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0)
                        {
                            break;
                        }
                        if (testmode)
                        {
                            LogR2(players);
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
                            LogR3(players);
                        }
                        player1.Turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0 || player3.Lives == 0)
                        {
                            break;
                        }
                        if (testmode)
                        {
                            LogR3(players);
                        }
                        player2.Turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0 || player3.Lives == 0)
                        {
                            break;
                        }
                        if (testmode)
                        {
                            LogR3(players);
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
                            LogR3(players);
                        }
                        player1.Turn(shotgun);
                        Console.Clear();
                        if (player1.Lives == 0 || player2.Lives == 0)
                        {
                            break;
                        }
                        if (testmode)
                        {
                            LogR3(players);
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
        private static void LogR1(Player[] plrs)
        {
            Console.WriteLine("num | name | lives | wins");
            foreach (Player plr in plrs)
            {
                Console.WriteLine($"{plr.num} | {plr.name} | {plr.Lives} | {plr.Wins}");
            }
        }
        private static void LogR2(Player_R2[] plrs)
        {
            Console.WriteLine("num | name | lives | wins | inventory | cuffed state");
            foreach (Player_R2 plr in plrs)
            {
                Console.WriteLine($"{plr.num} | {plr.name} | {plr.Lives} | {plr.Wins} | {string.Join(", ", plr.Inv)} | {plr.Cuffed}");
            }
        }
        private static void LogR3(Player_R3[] plrs)
        {
            Console.WriteLine("num | name | lives | wins | inventory | cuffed state | lifelocked");
            foreach (Player_R3 plr in plrs)
            {
                Console.WriteLine($"{plr.num} | {plr.name} | {plr.Lives} | {plr.Wins} | {string.Join(", ", plr.Inv)} | {plr.Cuffed} | {plr.lifeLocked}");
            }
        }
    }
}
