using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string[] bombNumberInfo = Console.ReadLine().Split();

            int bombNumber = int.Parse(bombNumberInfo[0]);
            int bombPower = int.Parse(bombNumberInfo[1]);

            Console.WriteLine(SumOfNumbersAfterBomb(bombNumber, bombPower, numbers));
        }

        static int SumOfNumbersAfterBomb(int bombNumber, int bombPower, List<int> currentList)
        {
            int timesExploded = 0;
            int bombNumberInstancesInList = NumberInstancesInList(bombNumber, currentList);

            for (int i = 0; i < bombNumberInstancesInList; i++)
            {
                Explosion(bombNumber, bombPower, timesExploded, currentList);
                RemoveBombNumber(bombNumber, currentList);
            }          

            return GetFinalSum(currentList);
        }
        
        static int NumberInstancesInList(int bombNumber, List<int> currentList)
        {
            int timesInList = 0;

            for (int i = 0; i < currentList.Count; i++)
            {
                if (currentList[i] == bombNumber)
                {
                    timesInList++;
                }
            }

            return timesInList;
        }
        static void Explosion(int bombNumber, int bombPower, int timesExploded, List<int> currentList)
        {
            for (int i = 0; i < currentList.Count; i++)
            {
                bool noNumbersToLeft = false;
                bool noNumbersToRight = false;
                bool hasExplodedLeft = false;
                bool hasExplodedRight = false;

                if (currentList[i] == bombNumber && timesExploded < bombPower)
                {
                    if (currentList[i] == currentList[0])
                    {
                        noNumbersToLeft = true;
                    }

                    if (currentList[i] == currentList[currentList.Count - 1])
                    {
                        noNumbersToRight = true;
                    }

                    if (!noNumbersToLeft)
                    {
                        currentList.RemoveAt(i - 1);
                        hasExplodedLeft = true;
                    }

                    if (!noNumbersToRight)
                    {
                        if (hasExplodedLeft)
                        {
                            currentList.RemoveAt(i);
                        }
                        else
                        {
                            currentList.RemoveAt(i + 1);
                        }

                        hasExplodedRight = true;
                    }

                    if (hasExplodedLeft || hasExplodedRight)
                    {
                        timesExploded++;
                        i = -1;
                    }
                }

                if (timesExploded == bombPower)
                {
                    break;
                }
            }
        }

        static void RemoveBombNumber(int bombNumber, List<int> currentList)
        {
            for (int i = 0; i < currentList.Count; i++)
            {
                if (currentList[i] == bombNumber)
                {
                    currentList.RemoveAt(i);
                    break;
                }
            }
        }

        static int GetFinalSum(List<int> currentList)
        {
            int finalSum = 0;

            for (int i = 0; i < currentList.Count; i++)
            {
                finalSum += currentList[i];
            }

            return finalSum;
        }

        /*
        static int SumOfNumbersAfterBomb(int bombNumber, int bombPower, List<int> currentList)
        {
            int finalSum = 0;
            int numbersBombedLeft = 0;
            int numbersBombedRight = 0;
            int bombPowerToLeft = bombPower;
            int bombPowerToRight = bombPower;
            

            //TO DO - combine left n right bombing.
            //TO DO - make multiple numbers explode.
            for (int i = 0; i < currentList.Count; i++)
            {
                if (currentList[i] == bombNumber && numbersBombedLeft != bombPowerToLeft)
                {
                    if (i < bombPower)
                    {
                        bombPowerToLeft -= bombPower;
                        bombPowerToLeft += i;

                        if (bombPowerToLeft == 0)
                        {
                            break;
                        }
                    }
                    currentList.RemoveAt(i - 1);
                    numbersBombedLeft++;
                    i = -1;
                }
            }

            for (int i = 0; i < currentList.Count; i++)
            {
                if (currentList[i] == bombNumber && numbersBombedRight != bombPowerToRight)
                {
                    if (currentList.Count - 1 - bombPower < i)
                    {
                        bombPowerToRight -= bombPower;
                        bombPowerToRight += ((currentList.Count - 1) - i);

                        if (bombPowerToRight == 0)
                        {
                            break;
                        }
                    }
                    currentList.RemoveAt(i + 1);
                    numbersBombedRight++;
                    i = -1;
                }
            }

            currentList.RemoveAll(x => x == bombNumber);

            for (int i = 0; i < currentList.Count; i++)
            {
                finalSum += currentList[i];
            }

            return finalSum;
        }
        */
    }
}
