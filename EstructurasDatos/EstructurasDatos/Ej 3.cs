using System;
using System.Collections.Generic;

namespace EstructurasDatos
{
    internal class Ej_3
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            Queue<int> ourQueue = new Queue<int>();

            string[] splitNumbers = numbers.Split(' ');
            for (int i = 0; i < splitNumbers.Length; i++)
            {
                ourQueue.Enqueue(int.Parse(splitNumbers[i]));
            }

            Queue<int> originalQueue = new Queue<int>(ourQueue);


            Console.WriteLine();
            foreach (var item in originalQueue)
            {
                Console.WriteLine(item);
            }
            InvertirCola(ourQueue);
            Console.WriteLine("Cola invertida:");
            foreach (var item in ourQueue)
            {
                Console.WriteLine(item);
            }
        }

        static void InvertirCola(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();

            while (queue.Count > 0)
            {
                stack.Push(queue.Dequeue());
            }

            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }
        }
    }
}
