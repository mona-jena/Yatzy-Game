using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace YatzyKata
{

    public class YatzyGame
    {
        IConsole _newConsole; //IConsole is the interface- contract and ConsoleActions() is the implementation of the interface- which has the methods
        private IRandom _randomNumberGenerator;
        
        public static int Main(string[] args)
        {
            //YatzyGame player = new YatzyGame(new ConsoleActions());
            IConsole consoleActions = new ConsoleActions();
            IRandom random = new Rng();
            YatzyGame player = new YatzyGame(consoleActions, random);

            List<int> fiveNumbers = player.GenerateFiveNumbers();
            PrintList(fiveNumbers);
            string[] userSpecifiedIndexes = player.GetIndexesUserWantsToKeep();
            List<int> keepIndexes = player.IndexesToKeepAsInt(userSpecifiedIndexes);
            List<int> newList = player.KeepIndexesSpecifiedByUser(keepIndexes, fiveNumbers);
            PrintList(newList);
            //CHECK IF USER HAS CALLED THIS ^^ METHOD 3 TIMES ONLY
            Console.WriteLine("Would you like to re-roll (Y/N)?");
            string userOption = Console.ReadLine();
            List<int> indexesNotRolled = new List<int>();
            //List<int> rerolledList = new List<int>();
            int totalScore = 0;
            if (userOption == "Y")
            {
                indexesNotRolled = player.DetermineIndexesNotKept(newList);
                newList = player.RollDice(newList, indexesNotRolled);
            }
            
            else
            {
                totalScore = player.CalculateSum(newList);
            }

            return totalScore;
            //     Determine which indexes not selected
            //     Go to RollDice(specific index, newList);
            // else:
            //     Go to CalculateSum(newList);

        }

        private static void PrintList(List<int> listToPrint)
        {
            Console.Write("(");
            for(int i=0; i < listToPrint.Count ; i++)
            {
                Console.Write(listToPrint[i]);
                if (i != listToPrint.Count-1)
                {
                    Console.Write(",");
                }
            }
            Console.WriteLine(")");
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
                int newNum = _randomNumberGenerator.Next();
                dices.Add(newNum);
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
            return userInputToInt;
        }
        
        public List<int> KeepIndexesSpecifiedByUser(List<int> userInputToInt, List<int> fiveNumbers)
        {
            List<int> userPreferredList = new List<int>() {0,0,0,0,0};
            foreach (int i in userInputToInt)
            {
                userPreferredList[i-1] = fiveNumbers[i-1];
            }
            return userPreferredList;
        }

        public List<int> DetermineIndexesNotKept(List<int> newList)
        {
            List<int> indexesNotUsed = new List<int>();
            for(int i = 0; i < newList.Count; i++)
            {
                if (newList[i] == 0)
                {
                    indexesNotUsed.Add(i);
                }
            }
            return indexesNotUsed;
        }
        
        
        public List<int> RollDice(List<int> newList, List<int> indexesNotRolled)
        {
            List<int> rerolledList = newList;
            foreach (int i in indexesNotRolled)
            {
                int newNum = _randomNumberGenerator.Next();
                newList[i] = newNum;
            }
            return rerolledList;
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
        public int Next();
    }

    public class Rng : IRandom
    {
        private Random _randomNumberGenerator; //Random class needs an object - declared here so that Next() can access it too 
        public Rng(){ 
            _randomNumberGenerator = new Random();
        }
        public int Next()
        {
            return _randomNumberGenerator.Next(1, 7);
        }
    }
    
}