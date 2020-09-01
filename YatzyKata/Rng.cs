using System;

namespace YatzyKata
{
    //Interfaces don't need to be in a class
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