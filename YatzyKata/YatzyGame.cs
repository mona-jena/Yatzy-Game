using System;
using System.Collections.Generic;

namespace YatzyKata
{
    public class YatzyGame
    {
        public static void Main(string[] args)
        {
            YatzyGame player = new YatzyGame();
            //int result = player.RollDice(args);

            //List<int> rolledNum = dice.RollDice();
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
                sum += item;˚
            }
            Console.Write("Which numbers would you like to keep? Please write the index of number you want to keep eg 1,2,3 to keep first 3 index");
            string heldNumbers= Console.ReadLine();
            string[] eachNumToKeep = heldNumbers.Split(",");
            foreach (string i in eachNumToKeep)
            {
                var stringToNum = int.Parse(eachNumToKeep[i]);
            }
;           KeepNum(dices, eachIndexToKeep);
            return sum;
        }

        public int[] KeepNum(List<int> dices, int[] heldNumbers)
        {
            return;
        }
    }

    // public class RollDice()
    // {
    //     static Random rand = new Random();
    //     int rolledNumber = rand.Next(1,7);
    //     return rolledNumber;
}

   