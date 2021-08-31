using System.Collections.Generic;

namespace DoublyLinkedList
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }

    interface ILinkedListsss
    {
        int GetCount(Node node); // возвращает количество элементов в списке
        void AddNode(Node node, int value); // добавляет новый элемент списка
        void AddNodeAfter(Node node, int startValue, int insertValue); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(Node node, int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(Node node, int searchValue); // ищет элемент по его значению
    }
}
