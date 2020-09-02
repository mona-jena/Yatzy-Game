using System.Collections.Generic;
using Xunit;
using YatzyKata;
using Moq;

namespace YatzyUnitTests
{
    public class UnitTest2
    {
        [Fact]
        public void TestToSeeIfFiveNumbersGenerated()
        {
            var rngMock = new Mock<IRandom>();
            rngMock.SetupSequence(s => s.Next())
                .Returns(4) //what random num should .Next() return 
                .Returns(3)
                .Returns(1)
                .Returns(4)
                .Returns(5);
            int expected = 5;
            Player player = new Player();
            int result = player.GenerateFiveNumbers(new Rng()).Count;
            Assert.Equal(expected, result);
        }
    }
}