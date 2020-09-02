using System.Collections.Generic;

namespace YatzyKata
{
    public class Player
    {
        
        public List<int> GenerateFiveNumbers(IRandom randomNumberGenerator)
        {
            List<int> dices = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                int newNum = randomNumberGenerator.Next();
                dices.Add(newNum);
            }
            return dices;
        }
    }
}