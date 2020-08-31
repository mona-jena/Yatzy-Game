using System.Collections.Generic;
using Xunit;
using YatzyKata;
using Moq;

namespace YatzyUnitTests
{
    public class UnitTest1
    {
       // var consoleActionsMock = new Mock<IConsole>();
        [Fact]
        public void TestToSeeIfFiveNumbersGenerated()
        {
            // var consoleActionsMock = new Mock<IConsole>();
            // var randomNum = new Mock<IRandom>();
            List<int> testNumbers = new List<int>() {3, 4, 5, 5, 2};
            int expected = 5;
            YatzyGame player = new YatzyGame(new ConsoleActions(), new Rng());
            int result = player.GenerateFiveNumbers().Count;
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void TestIfKeepNumPutsNumbersSpecifiedByUserInAnArray()
        {
            var consoleActionsMock = new Mock<IConsole>();
            consoleActionsMock.Setup(s => s.ReadLine())
                .Returns("1,2,3"); //fake readline
            // List<int> testNumbers = new List<int>();
            // int[] array = new int[] {3, 4, 5, 5, 2};
            // testNumbers.AddRange(array);
            // int[] heldNumbers = {1,2,3};
            string[] expected = {"1", "2", "3"};
            YatzyGame player = new YatzyGame(consoleActionsMock.Object, new Rng());
            string[] result = player.GetIndexesUserWantsToKeep();
            Assert.Equal(expected, result);
        }
        
        
        [Fact]
        public void TestIfGetIndexesToKeepReturnsKeepNumAsInt()
        {
            //var consoleActionsMock = new Mock<IConsole>();
            //Random randomNum = new Random();
            string[] eachNumToKeep = {"1", "2", "3"};
            int[] expected = {1,2,3};
            YatzyGame player = new YatzyGame(new ConsoleActions(), new Rng());
            List<int> result = player.ConvertUserStringToInt(eachNumToKeep);
            Assert.Equal(expected, result);
        }
        
        /*[Fact]
        public void TestIfIndexesNotSpecifiedByUserIsRemoved()
        {
            
            //MORE TEST CASES
            List<int> eachNumToKeepAsInt = new List<int>() {1, 2, 3};
            List<int> testOfFiveNumbers = new List<int>() {3, 4, 5, 5, 2};
            int[] expected = {3, 4, 5, 0, 0};
            YatzyGame player = new YatzyGame(new ConsoleActions(), new Rng());
            List<int> result = player.KeepIndexesSpecifiedByUser(eachNumToKeepAsInt, testOfFiveNumbers);
            Assert.Equal(expected, result);
        }*/

        /*[Fact]
        public void TestIfDetermineIndexesNotKeptReturnsCorrectList()
        {
            List<int> testList = new List<int>() {0, 3, 0, 0, 6};
            List<int> expected = new List<int>() {0, 2, 3};
            YatzyGame player = new YatzyGame(new ConsoleActions(), new Rng());
            List<int> result = player.DetermineIndexesNotKept(testList);
            Assert.Equal(expected, result);
        }*/
        
        /*[Fact]
        public void TestIfRollDicesReplacesNonUsedIndexes()
        {
            var rngMock = new Mock<IRandom>();
            rngMock.SetupSequence(s => s.Next())
                .Returns(1) //what random num should .Next() return 
                .Returns(4)
                .Returns(4);
            
            List<int> testList = new List<int>() {0, 3, 0, 0, 6};
            List<int> indexesNotRolled = new List<int> {0, 3, 2};
            List<int> expected = new List<int>() {1, 3, 4, 4, 6};
            
            YatzyGame player = new YatzyGame(new ConsoleActions(), rngMock.Object); //pass in Rng Object
            List<int> result = player.RollDice(testList, indexesNotRolled);
            Assert.Equal(expected, result);
        }*/

        [Fact]
        public void TestToSeeIfCalculateSumReturnsSum()
        {
            List<int> testNumbers = new List<int>() {3, 4, 5, 5, 2};
            int expected = 19;
            YatzyGame player = new YatzyGame(new ConsoleActions(), new Rng());
            int result = player.CalculateSum(testNumbers);
            Assert.Equal(expected, result);
        }

        /*[Fact]
        public void TestToAfterReRollMakesAUnionOfTwoLists()
        {
            List<int> newList = new List<int>() {0, 4, 0, 5, 0};
            List<int> reRolledNumbers = new List<int>() {3, 0, 5, 0, 2};
            List<int> expected = new List<int>() {3, 4, 5, 5, 2};
            YatzyGame player = new YatzyGame(new ConsoleActions(), new Rng());
            List<int> result = player.AfterReRoll(newList, reRolledNumbers);
            Assert.Equal(expected, result);
        }*/

        [Fact]
        public void TestIfCreateListRollsDiceForIndexesNotSpecifiedByUser()
        {
            var rngMock = new Mock<IRandom>();
            rngMock.SetupSequence(s => s.Next())
                .Returns(4) //what random num should .Next() return 
                .Returns(5)
                .Returns(3);
            
            List<int> fiveNumbers = new List<int>() {3, 6, 2, 1, 5};
            List<int> keepIndexes = new List<int>() {3, 5};
            List<int> expected = new List<int>() {4, 5, 2, 3, 5};
            
            YatzyGame player = new YatzyGame(new ConsoleActions(), rngMock.Object); //pass in Rng Object
            List<int> result = player.Reroll(fiveNumbers, keepIndexes);
            Assert.Equal(expected, result);
            
        }
    }


}