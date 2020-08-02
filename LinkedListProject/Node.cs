using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListProject
{
    public class Node
    {
        private int[] array;

        public Node() { }
        public Node(int value)
        {
            Value = value;
        }

        public Node(int[] array)
        {
            this.array = array;
        }

        public int Value { get; set; }
        public Node Next { get; set; }
    }
}
