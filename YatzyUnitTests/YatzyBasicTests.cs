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
            List<int> result = player.IndexesToKeepAsInt(eachNumToKeep);
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void TestIfIndexesNotSpecifiedByUserIsRemoved()
        {
            
            //MORE TEST CASES
            List<int> eachNumToKeepAsInt = new List<int>() {1, 2, 3};
            List<int> testOfFiveNumbers = new List<int>() {3, 4, 5, 5, 2};
            int[] expected = {3, 4, 5, 0, 0};
            YatzyGame player = new YatzyGame(new ConsoleActions(), new Rng());
            List<int> result = player.KeepIndexesSpecifiedByUser(eachNumToKeepAsInt, testOfFiveNumbers);
            Assert.Equal(expected, result);
        }

        public void TestIfDetermineIndexesNotKeptReturnsCorrectList()
        {
            List<int> testList = new List<int>() {0, 3, 0, 0, 6};
            
        }
        
        
        
        
        
        
        
        [Fact]
        public void TestToSeeIfCalculateSumReturnsSum()
        {
          //  var consoleActionsMock = new Mock<IConsole>();
            //Random randomNum = new Random();
            List<int> testNumbers = new List<int>() {3, 4, 5, 5, 2};
            int expected = 19;
            YatzyGame player = new YatzyGame(new ConsoleActions(), new Rng());
            int result = player.CalculateSum(testNumbers);
            Assert.Equal(expected, result);
        }

    }


}