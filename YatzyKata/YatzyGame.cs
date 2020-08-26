﻿using System;
using System.Collections.Generic;

namespace YatzyKata
{

    public class YatzyGame
    {
        IConsole _newConsole; //IConsole is the interface- contract and ConsoleActions() is the implementation of the interface- which has the methods
        private IRandom _randomNumberGenerator;
        
        public static void Main(string[] args)
        {
            //YatzyGame player = new YatzyGame(new ConsoleActions());
            IConsole consoleActions = new ConsoleActions();
            IRandom random = new Rng();
            YatzyGame player = new YatzyGame(consoleActions, random);

            List<int> firstFiveNumbers = player.GenerateFiveNumbers();
            string[] userSpecifiedIndexes = player.GetIndexesUserWantsToKeep();
            List<int> keepIndexed = player.IndexesToKeepAsInt(userSpecifiedIndexes);
        }

        
        public YatzyGame(IConsole console, IRandom randomNumberGenerator) {
            _randomNumberGenerator = randomNumberGenerator;
            _newConsole = console;
        }

        public List<int> GenerateFiveNumbers()
        {
            List<int> dices = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                int newNum = _randomNumberGenerator.Next(1, 7);
                dices.Add(newNum);
            }
            foreach (int i in dices)
            {
                Console.WriteLine(i); 
            }
            return dices;
        }

        public string[] GetIndexesUserWantsToKeep()
        {
            _newConsole.Write(
                "Which numbers would you like to keep? Please write the index of number you want to keep eg 1,2,3 to keep first 3 index");
            string heldNumbers = _newConsole.ReadLine();
            // handle no commas
            string[] eachNumToKeep = heldNumbers.Split(",");
            // GetIndexesToKeep(eachNumToKeep);
            return eachNumToKeep;
        }

        public List<int> IndexesToKeepAsInt(string[] eachNumToKeep)
        {
            List<int> userInputToInt = new List<int>();;
            int number = 0;
            for (int i = 0; i < eachNumToKeep.Length; i++)
            {
                bool stringToNum = Int32.TryParse(eachNumToKeep[i], out number);
                if (stringToNum)
                {
                    userInputToInt.Add(number);
                }
            }
            // KeepIndexesSpecifiedByUser(userInputToInt);
            return userInputToInt;
        }
        
        public void KeepIndexesSpecifiedByUser(List<int> userInputToInt)
        {
            foreach (int i in userInputToInt)
            {
                
            }
        }
        
        
        
        
        
        public List<int> RollDice(List<int> args)
        {
            List<int> dices = new List<int>();
            Random rolledNumbers = new Random();
            int randomNum = rolledNumbers.Next(1, 7);
            dices.Add(randomNum);
            return dices;
        }

        public int CalculateSum(List<int> dices)
        {
            int sum = 0;
            foreach (int item in dices)
            {
                sum += item;
            }
            return sum;
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
    
    
    public interface IRandom
    {
        public int Next(int min, int max);
    }

    public class Rng : IRandom
    {
        private Random _randomNumberGenerator; //Random class needs an object
        public Rng(){ 
            _randomNumberGenerator = new Random();
        }
        public int Next(int min, int max)
        {
            return _randomNumberGenerator.Next(min, max);
        }
    }
    
}