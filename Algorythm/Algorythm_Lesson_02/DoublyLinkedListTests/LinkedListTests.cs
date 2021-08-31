using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DoublyLinkedList.Tests
{
    [TestClass()]
    public class LinkedListTests
    {
        [TestMethod()]
        public void AddNodeTest()
        {
            AddNodePreTest( 777 );
            AddNodePreTest( 888 );
            AddNodePreTest( 999 );
        }

        private void AddNodePreTest(int value)
        {
            LinkedListsss linkedListsss = new LinkedListsss();
            Node node = new Node();
            linkedListsss.AddNode( node, value );
            int extended = node.NextNode.Value;
            int current = value;

            // assert
            Assert.AreEqual( extended, current );
        }

        [TestMethod()]
        public void AddNodeAfterTest()
        {
            AddNodeAfterPreTest( 111, 000, 222 );
            AddNodeAfterPreTest( 333, 123, 444 );
            AddNodeAfterPreTest( 555, 321, 666 );
        }

        private void AddNodeAfterPreTest(int lastValue, int newValue, int nextValue)
        {
            int[] array = { 111, 222, 333, 444, 555, 666, 777, 888, 999 };

            LinkedListsss linkedListsss = new LinkedListsss();
            Node node = new Node();

            for( int i = 0; i < array.Length; i++ )
            {
                var newNode = new Node { Value = array[i] };
                node.NextNode = newNode;
            }

            linkedListsss.AddNodeAfter( node, lastValue, newValue );
            int[] extended = { lastValue, newValue, nextValue };
            int[] current =
            {
                node.PrevNode.Value,
                node.Value,
                node.NextNode.Value
            };

            // assert
            Assert.AreEqual( extended, current );
        }

        [TestMethod()]
        public void FindNodeTest()
        {
            FindNodePreTest( 111 );
            FindNodePreTest( 333 );
            FindNodePreTest( 555 );
        }

        private void FindNodePreTest(int findValue)
        {
            int[] array = { 111, 222, 333, 444, 555, 666, 777, 888, 999 };
            LinkedList<int> linkedList = new LinkedList<int>( array );
            LinkedListNode<int> current = linkedList.FindLast( findValue );

            // assert
            Assert.AreEqual( findValue, current.Value );
        }

        [TestMethod()]
        public void RemoveNodeTest()
        {
            RemoveNodePreTest( 2, 333 );
            RemoveNodePreTest( 4, 555 );
            RemoveNodePreTest( 7, 888 );
        }

        private void RemoveNodePreTest(int removeIndex, int currentAfterRemoveNumber)
        {
            int[] array = { 111, 222, 333, 444, 555, 666, 777, 888, 999 };
            var count = 1;
            int nextNumber = 0;

            LinkedList<int> linkedList = new LinkedList<int>( array );

            foreach( int number in linkedList )
            {
                if( removeIndex == count )
                {
                    linkedList.Remove( number );
                    count = 1;
                    break;
                }
                count++;
            }

            foreach( int numberAfterDel in linkedList )
            {
                if( removeIndex == count )
                {
                    LinkedListNode<int> currentNumberAfterDel = linkedList.FindLast( numberAfterDel );
                    nextNumber = currentNumberAfterDel.Value;
                    break;
                }
                count++;
            }

            // assert
            Assert.AreEqual( currentAfterRemoveNumber, nextNumber );
        }
    }
}