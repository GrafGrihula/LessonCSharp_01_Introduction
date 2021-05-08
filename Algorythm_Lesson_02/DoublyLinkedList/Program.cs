using System;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AddNode( 123 );
            linkedList.AddNode( 456 );
            linkedList.AddNodeAfter( linkedList, 456, 321 );
            linkedList.FindNode( 321 );
            Console.WriteLine( "Всего в списке " + linkedList.GetCount() + " элемента(ов)" );
            linkedList.RemoveNode( 2 );
            linkedList.RemoveNode( linkedList, 123 );
        }

    }
}
