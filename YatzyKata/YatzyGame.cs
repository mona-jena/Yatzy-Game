using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace YatzyKata
{

    public class YatzyGame
    {
        IConsole _newConsole; //IConsole is the interface- contract and ConsoleActions() is the implementation of the interface- which has the methods
        private static IRandom _randomNumberGenerator;
        private List<int> _diceList1;
        private List<int> _diceList2;

        public static void Main(string[] args)
        {
            //YatzyGame player = new YatzyGame(new ConsoleActions());
            
            IConsole consoleActions = new ConsoleActions();
            IRandom random = new Rng();
            Player player1 = new Player();
            List<int> player1DiceList = player1.GenerateFiveNumbers(random);
            PrintList(player1DiceList);
            
            Player player2 = new Player();
            List<int> player2DiceList = player2.GenerateFiveNumbers(random);
            PrintList(player2DiceList);
            
            YatzyGame yatzyGame = new YatzyGame(consoleActions, random, player1DiceList, player2DiceList);
            yatzyGame.PlayerSum(player1DiceList);
            yatzyGame.PlayerSum(player2DiceList);
        }
        
        public YatzyGame(IConsole console, IRandom randomNumberGenerator, List<int> player1DiceList, List<int> player2DiceList) {
            _randomNumberGenerator = randomNumberGenerator;
            _newConsole = console;
            _diceList1 = player1DiceList;
            _diceList2 = player2DiceList;
        }

        public void PlayerSum(List<int> playerDiceList)
        {
            int totalScore = 0;
            int noOfTimesReRolled = 0;
            while (noOfTimesReRolled < 3)
            {
                Console.WriteLine("Would you like to re-roll (Y/N)?");
                string userOption = Console.ReadLine();
                if (userOption == "Y")
                {
                    string[] userSpecifiedIndexes = GetIndexesUserWantsToKeep();
                    List<int> keepIndexes = ConvertUserStringToInt(userSpecifiedIndexes);
                    playerDiceList = Reroll(playerDiceList, keepIndexes);
                    PrintList(playerDiceList);
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
            totalScore = CalculateSum(playerDiceList);
            Console.WriteLine("Your Score: " + totalScore);
        }
        
        public string[] GetIndexesUserWantsToKeep()
        {
            _newConsole.Write(
                "Which indexes would you like to keep between 1-5? (To keep first three numbers/indexes, please write 1,2,3 with indexes seperated by commas.) ");
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
    }

}