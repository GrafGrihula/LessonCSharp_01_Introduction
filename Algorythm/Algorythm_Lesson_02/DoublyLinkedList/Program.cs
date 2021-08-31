using System;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListsss linkedList = new LinkedListsss();
            Node node = new Node();
            linkedList.AddNode( node, 321 );
            Display( node );
            linkedList.AddNode( node, 258 );
            Display( node );
            linkedList.AddNode( node, 951 );
            Display( node );
            linkedList.AddNodeAfter( node, 258, 789 );
            Display( node );
            linkedList.AddNode( node, 456 );
            Display( node );
            linkedList.AddNode( node, 123 );
            Display( node );
            linkedList.RemoveNode( node );
            Display( node );
            linkedList.RemoveNode( node, 2 );
            Display( node );
            linkedList.FindNode( node, 222 );
            Console.WriteLine( $"Список содержит {linkedList.GetCount( node )} элемента(ов)" );
        }

        // вывод списка
        private static void Display(Node node)
        {
            node = node.NextNode;
            while( node != null )
            {
                Console.Write( node.Value + " " );
                node = node.NextNode;
            }
            Console.WriteLine();
        }
    }
}
