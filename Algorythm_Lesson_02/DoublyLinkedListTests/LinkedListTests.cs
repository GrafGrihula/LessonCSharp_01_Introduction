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
            LinkedList<int> linkedList = new LinkedList<int>();
            LinkedListNode<int> node = linkedList.AddFirst( value );
            LinkedListNode<int> current = linkedList.Find( value );

            // assert
            Assert.AreEqual( node, current );
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
            LinkedList<int> linkedList = new LinkedList<int>( array );
            LinkedListNode<int> current = linkedList.FindLast( lastValue );
            linkedList.AddAfter( current, newValue );
            LinkedListNode<int> next = linkedList.FindLast( nextValue );

            // assert
            Assert.AreEqual( current.Next.Next.Value, next.Value );
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