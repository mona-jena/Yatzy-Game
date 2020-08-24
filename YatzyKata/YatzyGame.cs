using System;
using System.Collections.Generic;

namespace YatzyKata
{
    public static void Main(string[] args)
    {
    YatzyGame player = new YatzyGame(new ConsoleActions());
    //int result = player.RollDice(args);

    //List<int> rolledNum = dice.RollDice();
    }

    public class YatzyGame
    {
        IConsole newConsole; //IConsole is

        public YatzyGame(IConsole console)
        {
            newConsole = console;
        }

        public List<int> RollDice(List<int> args)
        {
            List<int> dices = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                Random rolledNumbers = new Random();
                int randomNum = rolledNumbers.Next(1, 7);
                dices.Add(randomNum);
            }

            CalculateSum(dices);
            foreach (int i in dices)
            {
                Console.Write(i);
            }

            return dices;
        }

        public int CalculateSum(List<int> dices)
        {
            int sum = 0;
            foreach (int item in dices)
            {
                sum += item;
            }

            // int[] heldNumbers = new int[] { }1, 2, 3, 4, 5};
            // int[] numbersKept = KeepNum(dices, heldNumbers);
            return sum;
        }

        


        public int[] KeepNum(List<int> dices)
        {
            Console.Write(
                "Which numbers would you like to keep? Please write the index of number you want to keep eg 1,2,3 to keep first 3 index");
            string heldNumbers = Console.ReadLine();
            string[] eachNumToKeep = heldNumbers.Split(",");

            int number;
            foreach (string i in eachNumToKeep)
            {
                bool stringToNum = TryParse(eachNumToKeep[i], out number); ///int.Parse(eachNumToKeep.IndexOf(i));
            }
        }


        // public class RollDice()
        // {
        //     static Random rand = new Random();
        //     int rolledNumber = rand.Next(1,7);
        //     return rolledNumber;
    }
    
    //Interfaces don't need a class
    public interface IConsole
    {
        public string ReadLine();

        public void Write(string message);
    }

    public class ConsoleActions : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}

   