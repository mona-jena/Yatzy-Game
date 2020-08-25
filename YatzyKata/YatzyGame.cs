using System;
using System.Collections.Generic;

namespace YatzyKata
{

    public class YatzyGame
    {
        public static void Main(string[] args)
        {
            YatzyGame player = new YatzyGame(new ConsoleActions());
        }

        
        IConsole _newConsole; //IConsole is the interface- contract and ConsoleActions() is the implementation of the interface- which has the methods

        public YatzyGame(IConsole console)
        {
            _newConsole = console;
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

        public string[] KeepNum(List<int> dices)
        {
            _newConsole.Write(
                "Which numbers would you like to keep? Please write the index of number you want to keep eg 1,2,3 to keep first 3 index");
            string heldNumbers = _newConsole.ReadLine();
            // handle no commas
            string[] eachNumToKeep = heldNumbers.Split(",");
            return eachNumToKeep;
        }

        public int[] GetIndexesToKeep(string[] eachNumToKeep){
            int[] userInputToInt = {};
            int number = 0;
            for(int i = 0; i < eachNumToKeep.Length; i++)
            {
                bool stringToNum = Int32.TryParse(eachNumToKeep[i], out number);
                if (stringToNum)
                {
                    userInputToInt[i] = number;
                }
            }
            return userInputToInt;
        }
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