using System;
using System.Collections.Generic;

namespace DoublyLinkedList
{
    public class LinkedList : ILinkedList
    {
        //public int count;
        //public Node startNode;
        //public Node finishNode;
        public LinkedList<int> sentence = new LinkedList<int>();

        // добавляет новый элемент списка
        public void AddNode(int value)
        {
            sentence.AddFirst( value );
            Display( sentence, $"Добавили '{value}' в начало списка:" );
        }

        // добавляет новый элемент списка после определённого элемента
        public void AddNodeAfter(ILinkedList node, int lastValue, int newValue)
        {
            LinkedListNode<int> current = sentence.FindLast( lastValue );
            sentence.AddAfter( current, newValue );
            Display( sentence, $"Добавили '{newValue}' после элемента {lastValue}" );
        }

        // ищет элемент по его значению
        public void FindNode(int searchValue)
        {
            LinkedListNode<int> current = sentence.Find( searchValue );
            Console.WriteLine( $"Элемент {searchValue} является {IndexOf( sentence, searchValue )} по счёту" );
            Console.WriteLine();
        }

        // возвращает количество элементов в списке
        public int GetCount()
        {
            return sentence.Count;
        }

        // удаляет элемент по порядковому номеру
        public void RemoveNode(int index)
        {
            int removIndex = NumberOf( index );
            sentence.Remove( removIndex );
            Display( sentence, $"Удалён {index}-й элемент по счёту ({removIndex})" );
        }

        // удаляет указанный элемент
        public void RemoveNode(ILinkedList node, int index)
        {
            sentence.Remove( index );
            Display( sentence, $"Удалён элемент {index}" );
        }

        // вывод списка
        private static void Display(LinkedList<int> elements, string test)
        {
            Console.WriteLine( test );
            foreach( int element in elements )
            {
                Console.Write( element + " " );
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        // получение порядкового номера элемента
        public int IndexOf<T>(LinkedList<T> list, T item)
        {
            var count = 0;
            for( var node = list.First; node != null; node = node.Next, count++ )
            {
                if( item.Equals( node.Value ) )
                    return count + 1;
            }
            return -1;
        }

        // получение индекса по его порядковому номеру
        public int NumberOf(int item)
        {
            var count = 1;
            foreach( int number in sentence )
            {
                if( item == count )
                {
                    return number;
                }
                count++;
            }
            return -1;
        }
    }
}
