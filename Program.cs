using System;
using System.Linq;
using Microsoft.VisualBasic;

namespace Dominoes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> stonesInOrder = new List<int[]>();
            
            int[][] stones =
            {
                new [] {1, 6},
                new [] {2, 3},
                new [] {5, 6},
                new [] {2, 4},
                new [] {2, 4},
                new [] {1, 5},
                new [] {3, 1},
                new [] {6, 4},
                new [] {2, 5},
                new [] {3, 1},
                new [] {3, 2},
                new [] {1, 4},
                new [] {6, 2}
            };

            for (int i = 0; i < stones.Length; i++)
            {
                //if (!AllStonesUsed(stones, stonesInOrder) /*|| stonesInOrder.First().First() != stonesInOrder.Last().Last()*/)
                {
                    stonesInOrder.Clear();
                    stonesInOrder.Add(stones[i]);
                    TurnAndCheck(stones, stonesInOrder);
                    ContinuousCheck(stones, stonesInOrder);
                    WriteOrder(stones, stonesInOrder);
                }
            }
        }

        #region Are All Stones Used
        
        public static bool AllStonesUsed(int[][] stones, List<int[]> stonesInOrder)
        {
            for (int i = 0; i < stones.Length; i++)
            {
                if (!stonesInOrder.Contains(stones[i]))
                {
                    return false;
                }
            }
            return true;
        }
        
        #endregion

        #region Continuous Checks
        
        public static void ContinuousCheck(int[][] stones, List<int[]> stonesInOrder)
        {
            for (int i = 0; i < stones.Length; i++)
            {
                if (!stonesInOrder.Contains(stones[i]))
                {
                    TurnAndCheck(stones, stonesInOrder);
                }
            }
        }
        #endregion
        
        #region Turning, checking and placing
        
        public static void TurnAndCheck(int[][] stones, List<int []> stonesInOrder)
        {
            for (int i = 0; i < stones.Length; i++)
            {
                if (stones[i][0] == stonesInOrder.Last().Last() && !stonesInOrder.Contains(stones[i])) 
                {
                    stonesInOrder.Add(stones[i]);
                }
                else if (stones[i][1] == stonesInOrder.Last().Last() && !stonesInOrder.Contains(stones[i]))
                {
                    Array.Reverse(stones[i]);
                    stonesInOrder.Add(stones[i]);
                }
                else if (stones[i][0] == stonesInOrder.First().First() && !stonesInOrder.Contains(stones[i]))
                {
                    Array.Reverse(stones[i]);
                    stonesInOrder.Insert(0, stones[i]);
                }
                else if (stones[i][1] == stonesInOrder.First().First() && !stonesInOrder.Contains(stones[i]))
                {
                    stonesInOrder.Insert(0, stones[i]);
                }
            }
        }
        #endregion

        #region Writing out the order
        public static void WriteOrder(int[][] stones, List<int[]> stonesInOrder)
        {
            if (AllStonesUsed(stones, stonesInOrder))
            {
                foreach (var stone in stonesInOrder)
                {
                    Console.Write("-");
                    foreach (var num in stone)
                    {
                        Console.Write(num);
                    }
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}