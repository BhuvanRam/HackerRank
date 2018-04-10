using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestAreaHistogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] h = { 8979, 4570, 6436, 5083, 7780, 3269, 5400, 7579, 2324, 2116 };
            long maxArea = CalculateHistogramMaxArea(h);
            Console.WriteLine(maxArea);
        }

        public static long CalculateHistogramMaxArea(int[] h)
        {
            long area = 0, maxArea = 0;
            Stack<long> hStack = new Stack<long>();
            int[] array = h;
            for(int i=0;i<array.Length + 1;i++)
            {
                if(hStack.Count == 0)                
                    hStack.Push(i);
                else
                {
                    if (i < array.Length)
                    {
                        bool isCurrentIndexPushingToStack = true;
                        while (isCurrentIndexPushingToStack)
                        {
                            
                            if (hStack.Count == 0)
                            {
                                hStack.Push(i);
                                isCurrentIndexPushingToStack = false;
                                break;
                            }

                            // Check current array value is less than the stack top or not
                            long sTopIndex = hStack.Peek();
                            if (array[i] < array[sTopIndex])
                            {
                                // Pop from stack and calculate area and maxarea
                                long sPoppedIndex = hStack.Pop();
                                if (hStack.Count == 0)
                                    area = array[sPoppedIndex] * i; // area = HeightofStack * RightMostIndex
                                else
                                    area = array[sPoppedIndex] * (i - hStack.Peek() - 1); // area = HeightofStack * (RightMostIndex  - LeftMostIndex -1)
                                maxArea = maxArea > area ? maxArea : area;
                            }
                            else
                            {
                                hStack.Push(i);
                                isCurrentIndexPushingToStack = false; // CurrentElementPushedToStatck
                                break;
                            }
                        }
                    }
                    else
                    {
                        while (hStack.Count != 0)
                        {
                            long sPoppedIndex = hStack.Pop();
                            if (hStack.Count == 0)
                                area = array[sPoppedIndex] * i;
                            else
                                area = array[sPoppedIndex] * (i - hStack.Peek() - 1);
                            maxArea = maxArea > area ? maxArea : area;
                        }
                    }
                }
            }
            return maxArea;
        }
    }
}
