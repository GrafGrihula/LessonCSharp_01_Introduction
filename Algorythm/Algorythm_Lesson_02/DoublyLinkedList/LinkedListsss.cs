using System;
using System.Collections.Generic;

namespace DoublyLinkedList
{
    public class LinkedListsss : ILinkedListsss
    {
        public void AddNode(Node node, int value)
        {
            while( node.NextNode != null )
            {
                node = node.NextNode;
            }
            var newNode = new Node { Value = value };
            node.NextNode = newNode;
        }

        public void AddNodeAfter( Node node, int startValue, int insertValue )
        {
            var currentNode = node;
            while( currentNode != null )
            {
                if( currentNode.Value == startValue )
                {
                    var nextItem = currentNode.NextNode;
                    var newNode = new Node { Value = insertValue };
                    newNode.NextNode = nextItem;
                    node.NextNode = newNode;
                }
                currentNode = currentNode.NextNode;
            }                   
        }

        public Node FindNode(Node node, int searchValue)
        {
            var currentNode = node;
            while( currentNode != null )
            {
                if( currentNode.Value == searchValue )
                {
                    Console.WriteLine( currentNode.Value );
                    return currentNode;
                }
                currentNode = currentNode.NextNode;
            }
            Console.WriteLine( $"Элемент {searchValue} не найден" );
            return null; // если ничего не нашли, то null
        }

        public int GetCount(Node node)
        {
            int count = -1;
            while( node != null )
            {
                node = node.NextNode;
                count++;
            }
            return count;
        }

        public void RemoveNode(Node node, int index)
        {
            if( index == 0 )
            {
                var newStartNode = node.NextNode;
                node.NextNode = null;
            }
            int currentIndex = 0;
            var currentNode = node;
            while( currentNode != null )
            {
                if( currentIndex == index - 1 )
                {
                    RemoveNode( currentNode );
                }
                currentNode = currentNode.NextNode;
                currentIndex++;
            }
        }

        public void RemoveNode(Node node)
        {
            if( node.NextNode == null )
                return;
            var nextItem = node.NextNode.NextNode;
            node.NextNode = nextItem;
        }
    }
}
