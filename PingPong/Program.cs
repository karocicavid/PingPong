using System;
namespace PINPONG
{
    public delegate void Delegate(string mes);
    class Ping
    {
        public event Delegate Pingevent;
        public int Pingpoints;
        public string Ping_turn()
        {
            Pingevent?.Invoke("Pong received Ping");
            Pingevent?.Invoke("Press S for shoot,E for exit :");
            string s = Console.ReadLine();
            if (s == "s" || s == "S") { Pingpoints += 10; return s; }
            else if (s == "e" || s == "E") { return s; }
            else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Wrong input,press E or S !");Console.ResetColor();return Ping_turn(); }
        }
    }

    class Pong
    {
        public event Delegate Pongevent;
        public int Pongpoints;
        public string Pong_turn()
        {
            Pongevent?.Invoke("Ping received Pong");
            Pongevent?.Invoke("Press S for shoot E for exit : ");
            string s = Console.ReadLine();
            if (s == "s" || s == "S") { Pongpoints += 10; return s; }
            else if (s == "e" || s == "E") { return s; }
            else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Wrong input,press E or S !"); Console.ResetColor(); return Pong_turn(); }
        }
    }

    class Program
    {
        static void Main()
        {
            Ping player1 = new Ping();
            Pong player2 = new Pong();
            player1.Pingevent += ShowMessage;
            player2.Pongevent += ShowMessage;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Game started!");
            Console.ResetColor();
            bool check = true;
            string presskey;
            do
            {
                presskey = player1.Ping_turn();
                bool check1 = true;
                do
                {
                    switch (presskey)
                    {
                        case "S":
                            {
                                presskey = player2.Pong_turn();
                                if (presskey == "e" || presskey == "E") { goto case "E"; }
                                else { check1 = false; check = true; }
                                break;
                            }
                        case "s":
                            {
                                presskey = player2.Pong_turn();
                                if (presskey == "e" || presskey == "E") { goto case "E"; }
                                else { check1 = false; check = true; }
                                break;
                            }
                        case "E":
                            {
                                check = false;
                                check1 = false;
                                break;
                            }
                        case "e":
                            {
                                check = false;
                                check1 = false;
                                break;
                            }
                    }
                } while (check1 == true);
            } while (check == true);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Game Over \n Ping points - {player1.Pingpoints} , Pong points - {player2.Pongpoints}");
            Console.Read();
        }
        public static void ShowMessage(string mes)
        {
            Console.WriteLine(mes);
        }
    }
}
