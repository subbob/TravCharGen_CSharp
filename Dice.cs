using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLib
{
    public class Dice
    {
        Random random = new System.Random();

        public int RollDie(int MaxSize)
        {
            return random.Next(1, MaxSize + 1);
        }

        public int RollDice(int Quantity, int Sides)
        {
            int i;
            int sum = 0;
            for (i = 1; i <= Quantity; i++)
            {
                sum += RollDie(Sides);
            }
            return sum;
        }
    }
}
