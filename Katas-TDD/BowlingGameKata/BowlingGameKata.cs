using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas_TDD.BowlingGameKata
{
    public class BowlingGameKata
    {
        private int result = 0;
        private int[] resultList = new int[22];
        private int ball = 0;


        public void roll(int points)
        {
            resultList[ball] = points;

            ball++;

        }

        public int score()
        {
            int counter = 0;

            for (int i = 0; i < 10; i++)
            {
                if (IsSpare(resultList[counter], resultList[counter + 1]))
                {
                    result += 10 + resultList[counter + 2];
                    counter += 2;

                }

                else if (IsStrike(resultList[counter]))
                {
                    result += 10 + resultList[counter + 1] + resultList[counter + 2];

                    counter += 1;
                }

                else
                {
                    result += resultList[counter] + resultList[counter + 1];
                    counter += 2;
                }

            }

            return result;
        }


        private bool IsSpare(int x, int y)
        {

            return x + y == 10;
        }

        private bool IsStrike(int x)
        {

            return x == 10;
        }

    }
}

