using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList
{
    [Serializable]
    public class ToDo
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public ToDo()
        { }

        public ToDo(string title)
        {
            Title = title;
            IsDone = false;
        }
    }

    //[Serializable]
    //public class ToDo
    //{
    //    public string[] Title { get; set; }
    //    public bool[] IsDone { get; set; }
    //    public ToDo() { }
    //}
}
