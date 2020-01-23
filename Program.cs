using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedListReverser
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = new Node<int>();
            SeedNodes(start, 25, 1);

            var initialList = PrintNodes(start);

            Reverse(ref start);

            var reversedList = PrintNodes(start);

            initialList.Reverse();
            Console.WriteLine($"Reversed list equals to reversed initial list: {reversedList.SequenceEqual(initialList)}");
        }

        static void Reverse<TValue>(ref Node<TValue> start)
        {
            Node<TValue> nextNode = start.Next;
            Node<TValue> previousNode = null;
            start.Next = previousNode;

            while (nextNode != null)
            {
                previousNode = start;
                start = nextNode;
                nextNode = start.Next;
                start.Next = previousNode;
            }
        }

        static void SeedNodes(Node<int> start, int firstNumber, int lastNumber)
        {
            IEnumerable<int> numbers;
            if (firstNumber < lastNumber)
                numbers = Enumerable.Range(firstNumber, lastNumber);
            else
                numbers = Enumerable.Range(lastNumber, firstNumber).Reverse();

            foreach (var number in numbers)
            {
                start.Value = number;
                if (firstNumber < lastNumber 
                    ? number < lastNumber : number > lastNumber)
                {
                    start.Next = new Node<int>();
                    start = start.Next;
                }
            }
        }

        static List<TValue> PrintNodes<TValue>(Node<TValue> start)
        {
            var result = new List<TValue>();
            while (start != null)
            {
                Console.WriteLine(start.Value);
                result.Add(start.Value);
                start = start.Next;
            }

            return result;
        }
    }

    class Node<TValue>
    {
        public Node<TValue> Next { get; set; }

        public TValue Value { get; set; }
    }
}