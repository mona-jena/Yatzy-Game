using System;
using System.Collections.Generic;
using System.Diagnostics;

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

            List<int> diceList = player.GenerateFiveNumbers();
            PrintList(diceList);

            // List<int> indexesNotRolled = new List<int>();
            // List<int> reRolledNumbers = new List<int>();
            List<int> keepIndexes = new List<int>();
            int totalScore = 0;
            int noOfTimesReRolled = 0;
            while (noOfTimesReRolled < 3)
            {
                Console.WriteLine("Would you like to re-roll (Y/N)?");
                string userOption = Console.ReadLine();
                if (userOption == "Y")
                {
                     string[] userSpecifiedIndexes = player.GetIndexesUserWantsToKeep();
                     keepIndexes = player.ConvertUserStringToInt(userSpecifiedIndexes);
                     diceList = player.Reroll(diceList, keepIndexes);
                     // diceList = player.KeepIndexesSpecifiedByUser(keepIndexes, diceList);
                     // PrintList(diceList);
                     // indexesNotRolled = player.DetermineIndexesNotKept(diceList);
                     // reRolledNumbers = player.RollDice(diceList, indexesNotRolled);
                     // List<int> afterRerolled = player.AfterReRoll(diceList, reRolledNumbers);
                      PrintList(diceList);
                      noOfTimesReRolled++;
                }
                else if (userOption == "N")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("I think you mistyped, please enter again.");
                }
            }
            totalScore = player.CalculateSum(diceList);
            Console.WriteLine("Your Score: " + totalScore);
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
                "Which indexes would you like to keep between 1-5? To keep first three numbers/indexes, please write 1,2,3. ");
            string heldNumbers = _newConsole.ReadLine();
            string[] eachNumToKeep = {heldNumbers};
            //if more than 1 index to keep:
            if (heldNumbers.Contains(","))
            {
                eachNumToKeep = heldNumbers.Split(",");
            }
            return eachNumToKeep;
        }

        public List<int> ConvertUserStringToInt(string[] eachNumToKeep)
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

        public List<int> Reroll(List<int> diceList, List<int> keepIndexes)
        {
            for (int i = 1; i <= diceList.Count; i++)             //dice rolls start at 1
            {
                //int j = i - 1;
                if (!keepIndexes.Contains(i))
                {
                    diceList[i-1] = DiceRoll();                  
                }
            }

            return diceList;
        }

        private int DiceRoll()
        {
            return _randomNumberGenerator.Next();
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

        private static void PrintList(List<int> listToPrint)
        {
            Console.Write("Current List: (");
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
        
        
        
        
        
        
        /*public List<int> AfterReRoll(List<int> newList, List<int> reRolledNumbers)
        {
            List<int> afterRerolled = new List<int>() {0,0,0,0,0};
            for (int i = 0; i < afterRerolled.Count; i++)
            {
                if (newList[i] != 0)
                {
                    afterRerolled[i] = newList[i];
                }

                if (reRolledNumbers[i] != 0)
                {
                    afterRerolled[i] = reRolledNumbers[i];
                }
            }

            return afterRerolled;
        }
        */

        /*public List<int> KeepIndexesSpecifiedByUser(List<int> userInputToInt, List<int> fiveNumbers)
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
        }*/
    }


//Interfaces don't need to be in a class
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