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

            Player player2 = new Player();
            List<int> player2DiceList = player2.GenerateFiveNumbers(random);

            YatzyGame yatzyGame = new YatzyGame(consoleActions, random, player1DiceList, player2DiceList);
            Console.WriteLine("The aim of this game is to roll your 5 dice to get the highest sum. Each player can only re-roll upto 3 times. ");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("######### STARTING YATZY GAME #########");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("\n### Player 1 it's your turn. ###");
            System.Threading.Thread.Sleep(1000);
            PrintList(player1DiceList);
            System.Threading.Thread.Sleep(2000);
            int player1Score = yatzyGame.PlayerSum(player1DiceList);
            
            System.Threading.Thread.Sleep(300);
            Console.WriteLine("### PLayer 2 now it's your turn. ###");
            System.Threading.Thread.Sleep(1000);
            PrintList(player2DiceList);
            System.Threading.Thread.Sleep(2000);
            int player2Score = yatzyGame.PlayerSum(player2DiceList);

            Console.WriteLine(yatzyGame.Winner(player1Score, player2Score));
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("\n######### GAME OVER #########");
        }

        public YatzyGame(IConsole console, IRandom randomNumberGenerator, List<int> player1DiceList,
            List<int> player2DiceList)
        {
            _randomNumberGenerator = randomNumberGenerator;
            _newConsole = console;
            _diceList1 = player1DiceList;
            _diceList2 = player2DiceList;
        }

        public int PlayerSum(List<int> playerDiceList)
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
                    Console.WriteLine();
                    System.Threading.Thread.Sleep(2000);
                    PrintList(playerDiceList);
                    System.Threading.Thread.Sleep(1000);
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
            Console.Write("--------------\nYour Score: ");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(totalScore + "\n");
            System.Threading.Thread.Sleep(2000);
            return totalScore;
        }

        public string[] GetIndexesUserWantsToKeep()
        {
            _newConsole.Write(
                "Which die would you like to keep between 1-5? Must keep atleast one die.\n" +
                "(To keep first three die, please write 1,2,3 with die indexes seperated by commas.) ");
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
            List<int> userInputToInt = new List<int>();
            ;
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
            for (int i = 1; i <= diceList.Count; i++) //dice rolls start at 1
            {
                if (!keepIndexes.Contains(i))
                {
                    diceList[i - 1] = DiceRoll();
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
            Console.Write("Rolled Dice: (");
            for (int i = 0; i < listToPrint.Count; i++)
            {
                Console.Write(listToPrint[i]);
                if (i != listToPrint.Count - 1)
                {
                    Console.Write(",");
                }
            }

            Console.WriteLine(")");
        }
        
        public string Winner(int player1Score, int player2Score)
        {
            if (player1Score > player2Score)
            {
                return "Player 1 Wins!!!";
            }
            else if (player2Score > player1Score)
            {
                return "Player 2 Wins!!!";
            }
            else
            {
                return "It's a draw!";
            }
        }
    }
}