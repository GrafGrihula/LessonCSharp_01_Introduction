using System.Collections.Generic;

namespace DoublyLinkedList
{
    //public class Node
    //{
    //    public int Value { get; set; }
    //    public ILinkedList NextNode { get; set; }
    //    public ILinkedList PrevNode { get; set; }
    //}
    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value); // добавляет новый элемент списка
        void AddNodeAfter(ILinkedList node, int lastValue, int newValue); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(ILinkedList node, int index); // удаляет указанный элемент
        void FindNode(int searchValue); // ищет элемент по его значению
        //ILinkedList FindNode(int searchValue); // ищет элемент по его значению
        int IndexOf<T>(LinkedList<T> list, T item);
    }
}
