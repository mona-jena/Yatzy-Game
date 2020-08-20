using System.Collections.Generic;
using Xunit;
using YatzyKata;

namespace YatzyUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestToSeeIfFiveNumbersGenerated()
        {
            List<int> testNumbers = new List<int>() {3, 4, 5, 5, 2};
            int expected = 5;
            YatzyGame player = new YatzyGame();
            int result = player.RollDice(testNumbers).Count;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestToSeeIfCalculateSumReturnsSum()
        {
            List<int> testNumbers = new List<int>() {3, 4, 5, 5, 2};
            int expected = 19;
            YatzyGame player = new YatzyGame();
            int result = player.CalculateSum(testNumbers);
            Assert.Equal(expected, result);
        }


        [Fact]
        public void TestIfKeepNumKeepsNumbersOnlySpecifiedByUser()
        {
            List<int> testNumbers = new List<int>();
            int[] array = new int[] {3, 4, 5, 5, 2};
            testNumbers.AddRange(array);
            int[] heldNumbers = {1,2,3};
            int[] expected = {3, 4, 5, 0, 0};
            YatzyGame player = new YatzyGame();
            int[] result = player.KeepNum(testNumbers, heldNumbers);
            Assert.Equal(expected, result);
        }
        
    }
 
    }