using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumNumber
{
    public class Program
    {
        static void Main(String[] args)
        {
            // Console.WriteLine("Enter your input to play Maximum Element Game");
            int numberOfTimes = Convert.ToInt32(Console.ReadLine());
            Stack<int> inputStack = new Stack<int>();
            Stack<int> maxElementsStack = new Stack<int>();
            int maxArea = 0;
            int iIncrementer = 0;

            /*
            Console.WriteLine("----------------- Options of the Game -----------------");
            Console.WriteLine("1 - Push the element x into the stack");
            Console.WriteLine("2 - Delete the element present at the top of the stack.");
            Console.WriteLine("3 - Print the maximum element in the stack.");
            Console.WriteLine("-------------------------------------------------------");
            */
            while (iIncrementer < numberOfTimes)
            {
                string readInput = Console.ReadLine();
                int[] choiceofGame = readInput.Split(' ').Select(p => Convert.ToInt32(p)).ToArray();


                switch (choiceofGame[0])
                {
                    case 1:
                        inputStack.Push(choiceofGame[1]);
                        maxArea = choiceofGame[1] > maxArea ? choiceofGame[1] : maxArea;
                        if (maxElementsStack.Count() == 0)
                            maxElementsStack.Push(maxArea);
                        else
                        {
                            int topOfStack = maxElementsStack.Peek();
                            if (maxArea > topOfStack) maxElementsStack.Push(maxArea);
                        }
                        break;
                    case 2:
                        int iDeletedElement = inputStack.Pop();
                        if (maxElementsStack.Count() != 0)
                        {
                            int topOfStack = maxElementsStack.Peek();
                            if (iDeletedElement == topOfStack)
                            {
                                // Before Popping i need to check whether the element is already in input stack or not.'
                                int i = 0;
                                foreach (int item in inputStack)
                                {
                                    if (item == iDeletedElement)
                                    {
                                        i = i + 1;
                                        break;
                                    }
                                }
                                if (i == 0)
                                    maxElementsStack.Pop();

                                maxArea = maxElementsStack.Count() != 0 ? maxElementsStack.Peek() : 0;
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine(maxArea);
                        break;
                }
                iIncrementer++;
            }
        }
    }
}
