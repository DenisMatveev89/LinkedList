using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListProject
{
    public class LinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        private int _length = 0;
        public int _index = 0;
        private int _countL;
        private Node _current;
        private Node preHead;
        private int _firstFound;
        private int _indexMax;
        private int _indexMin;

        public LinkedList() { }
        public LinkedList(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                AddLast(array[i]);
                _countL++;
            }
            _length = array.Length;
        }
        public LinkedList(int value)
        {

        }
        // Добавление элемента в конец списка
        public void AddLast(int value)
        {
            Node node = new Node(value);
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }
            Tail = node;
            _countL++;
            _length++;
        }
        // Добавление массива в конец списка
        public void AddLast(int[] array)
        {
            Node node = new Node(array);
            for (int i = 0; i < array.Length; i++)
            {
                AddLast(array[i]);
                // _length++;
            }
            //_length += array.Length;
        }
        // Добавление элемента в начало списка
        public void AddFirst(int value)
        {
            Node node = new Node(value);
            node.Next = Head;
            Head = node;
            if (_countL == 0) Tail = Head;
            _countL++;
            _length++;
        }
        // Добавление массива в начало списка
        public void AddFirst(int[] array)
        {
            Node node = new Node(array);
            for (int i = array.Length - 1; i >= 0; i--)
            {
                AddFirst(array[i]);
            }
            //_length += array.Length;
        }
        // Вставка элемента в список по указанному индексу.
        public void AddAt(int index, int item)
        {
            if (index < 0)
            {
                throw new Exception("Error");
            }
            Node currentNode = Head;
            Node prevNode = Head;
            int idx = 0;
            while (currentNode != null)
            {
                if (idx == index)
                {
                    Node node = new Node(item);
                    if (currentNode == Head)
                    {
                        Head = node;
                    }
                    else
                    {
                        prevNode.Next = node;
                    }
                    node.Next = currentNode;
                    _countL++;
                    _length++;
                    return;
                }
                prevNode = currentNode;
                currentNode = currentNode.Next;
                idx++;
            }

        }
        // Вставка массива в список по указанному индексу.
        public void AddAt(int index, int[] array)
        {
            if (index < 0 || index > _countL - 1)
            {
                throw new Exception("Error");
            }
            for (int i = 1; i < array.Length + 1; i++)
            {
                AddAt(index - 1, i);
                index++;
            }
        }
        // Получить размер списка.
        public int GetSize()
        {
            return _length;
        }
        // Поменять значение элемента с указанным индексом.
        public void Set(int index, int value) 
        {
            if (index > _countL - 1 || index < 0)
            {
                throw new Exception("Error");
            }
            Node newNode = Head;
            int idx = 0;
            while (newNode != null)
            {
                if (idx == index)
                {
                    newNode.Value = value;
                    return;
                }
                newNode = newNode.Next;
                idx++;
            }
        }
        // Удаление первого элемента из списка.
        public void RemoveFirst() 
        {
            if (Head == null)
            {
                throw new Exception("Error - Список пуст");
            }
            else if (_countL == 1)
            {
                Head = null;
                Tail = null;
                _countL--;
            }
            Head = Head.Next;
            _countL--;
            _length--;
        }
        // Удаление последнего элемента из списка.
        public void RemoveLast() 
        {
            if (Tail == null)
            {
                throw new Exception("Error - Список пуст");
            }
            else if (_countL == 1)
            {
                Head = null;
                Tail = null;
                _countL--;
                _length--;
            }
            else
            {
                Node currenNode = Head;
                int i = 0;

                while (currenNode.Next != null)
                {
                    if (i == _length - 2)
                    {
                        currenNode.Next = null;
                        _countL--;
                        _length--;
                        return;
                    }
                    currenNode = currenNode.Next;
                    i++;
                }
            }

        }
        // Удаление элемента по индексу.
        public void RemoveAt(int index) 
        {
            if (Head == null)
            {
                throw new Exception("Error - Список пуст");
            }
            else if (index > _length) { throw new Exception("Error - Нет такого индекса"); }
            else if (index == 0) { RemoveFirst(); }
            else if (index == _countL - 1) { RemoveLast(); }
            else
            {
                Node currentNode = Head;
                int idx = 0;
                while (currentNode.Next != null)
                {
                    if (idx == index - 1)
                    {
                        currentNode.Next = currentNode.Next.Next;
                        _countL--;
                        _length--;
                        return;
                    }
                    idx++;
                    currentNode = currentNode.Next;
                }
            }
        }
        // Удалить все элементы, равные val.
        public void RemoveAll(int value) 
        {
            if (Head == null)
            {
                throw new Exception("Error - Список пуст");
            }
            Node currentNode = Head;
            Node prevNode = Head;
            while (prevNode.Next != null)
            {

                if (currentNode.Value == value)
                {
                    if (prevNode.Value == value)
                    {
                        Head = prevNode.Next;
                        _countL--;
                        _length--;
                    }
                    else
                    {
                        prevNode.Next = currentNode.Next;
                        _countL--;
                        _length--;
                    }
                }
                prevNode = currentNode;
                currentNode = currentNode.Next;
            }
        }
        // Проверка, есть ли элемент в списке.
        public bool Contains(int value) 
        {
            Node currentNode = Head;

            for (int i = 0; i < _countL / 2; i++)
            {
                if (currentNode.Value == value)
                {
                    _firstFound = i;
                    return true;
                }
                currentNode = currentNode.Next;
            }
            for (int i = _countL / 2 - 1; i < _countL; i++)
            {
                if (currentNode.Value == value)
                {
                    _firstFound = i;
                    return true;
                }
                currentNode = currentNode.Next;
            }

            return false;
        }
        // Вернёт индекс первого найденного элемента, равного val(или -1, если элементов с таким значением в списке.
        public int IndexOf(int value)
        { 
            _firstFound = 0;
            if (Head == null)
            {
                throw new Exception("Error - Список пуст");
            }
            else if (Contains(value) == true)
            {
                return _firstFound;
            }
            return -1;
        }
        // Реверс списка.
        public void Reverse()
        {
            preHead = Head;
            while (preHead.Next != null)
            {
                _current = preHead.Next;
                preHead.Next = preHead.Next.Next;
                _current.Next = Head;
                Head = _current;
            }
            Tail = preHead;
        }
        // Вернёт хранимые данные в виде массива.
        public int[] ToArray() 
        {
            int[] newArray = new int[_countL];
            Node newNode = Head;
            int i = 0;

            while (newNode != null)
            {
                newArray[i++] = newNode.Value;
                newNode = newNode.Next;
            }
            return newArray;
        }
        // Вернёт значение первого элемента списка.
        public int GetFirst() 
        {
            if (Head == null)
            {
                throw new Exception("Error - Список пуст");
            }
            return Head.Value;
        }
        // Вернёт значение последнего элемента списка.
        public int GetLast()
        {
            if (Head == null)
            {
                throw new Exception("Error - Список пуст");
            }
            return Tail.Value;
        }
        // Вернёт значение элемента списка c указанным индексом.
        public int Get(int index)
        {
            if (Head == null)
            {
                throw new Exception("Error - Список пуст");
            }
            else if (index > _countL || index < 0) throw new Exception("Error - ошибка индекса");
            Node currentNode = Head;
            int idx = 0;
            while (Head != null)
            {
                if (idx == index)
                {
                    return currentNode.Value;
                }
                currentNode = currentNode.Next;
                idx++;
            }
            return 0;
        }
        // Поиск значения максимального элемента.
        public int Max()
        {
            if (Head == null)
            {
                throw new Exception("Error - Список пуст");
            }
            int max = Head.Value;
            int idx = 0;
            Node currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value > max)
                {
                    max = currentNode.Value;
                    _indexMax = idx;
                }
                currentNode = currentNode.Next;
                idx++;
            }
            return max;
        }
        // Поиск значения минммального элемента.
        public int Min() 
        {
            if (Head == null)
            {
                throw new Exception("Error - Список пуст");
            }
            int idx = 0;
            int min = Head.Value;
            Node currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value < min)
                {
                    min = currentNode.Value;
                    _indexMin = idx;
                }

                currentNode = currentNode.Next;
                idx++;
            }
            return min;
        }
        // Поиск индекса максимального элемента.
        public int IndexOfMax() 
        {
            if (Head == null)
            {
                throw new Exception("Error - Список пуст");
            }
            _indexMax = 0;
            Max();
            return _indexMax;
        }
        // Поиск индекса минимального элемента.
        public int IndexOfMin() 
        {
            if (Head == null)
            {
                throw new Exception("Error - Список пуст");
            }
            _indexMin = 0;
            Min();
            return _indexMin;
        }
        // Вывод списка в консоль.
        public void PrintArrayList()
        {
            int[] array = ToArray();
            Console.WriteLine("\n");
            for (int i = 0; i < _countL; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
        // Сортировка слиянием.
        Node SortedMerge(Node a, Node b)
        {
            Node result = null;
            if (a == null)
                return b;
            if (b == null)
                return a;

            if (a.Value <= b.Value)
            {
                result = a;
                result.Next = SortedMerge(a.Next, b);
            }
            else
            {
                result = b;
                result.Next = SortedMerge(a, b.Next);
            }
            return result;
        }
        // Cортировка слиянием по убыванию.
        Node SortMergeDesc(Node a, Node b) 
        {
            Node result = null;
            if (a == null)
                return b;
            if (b == null)
                return a;

            if (a.Value >= b.Value)
            {
                result = a;
                result.Next = SortMergeDesc(a.Next, b);
            }
            else
            {
                result = b;
                result.Next = SortMergeDesc(a, b.Next);
            }
            return result;
        }

        public Node Sort(Node h)
        {
            // Base case : if head is null 
            if (h == null || h.Next == null)
            {
                return h;
            }

            // get the middle of the list 
            Node middle = GetMiddle(h);
            Node nextofmiddle = middle.Next;

            // set the next of middle node to null 
            middle.Next = null;

            // Apply mergeSort on left list 
            Node left = Sort(h);

            // Apply mergeSort on right list 
            Node right = Sort(nextofmiddle);

            // Merge the left and right lists 
            Node sortedlist = SortedMerge(left, right);
            return sortedlist;
        }
        public Node SortDesc(Node h)
        {
            // Base case : if head is null 
            if (h == null || h.Next == null)
            {
                return h;
            }

            // get the middle of the list 
            Node middle = GetMiddle(h);
            Node nextofmiddle = middle.Next;

            // set the next of middle node to null 
            middle.Next = null;

            // Apply mergeSort on left list 
            Node left = SortDesc(h);

            // Apply mergeSort on right list 
            Node right = SortDesc(nextofmiddle);

            // Merge the left and right lists 
            Node sortedlist = SortMergeDesc(left, right);
            return sortedlist;
        }
        Node GetMiddle(Node h)
        {
            // Base case 
            if (h == null)
                return h;
            Node fastptr = h.Next;
            Node slowptr = h;

            // Move fastptr by two and slow ptr by one 
            // Finally slowptr will point to middle node 
            while (fastptr != null)
            {
                fastptr = fastptr.Next;
                if (fastptr != null)
                {
                    slowptr = slowptr.Next;
                    fastptr = fastptr.Next;
                }
            }
            return slowptr;
        }
        public void Clear()
        {
            Head = null;
            Tail = null;
            _countL = 0;
            _length = 0;
        }
    }
}
