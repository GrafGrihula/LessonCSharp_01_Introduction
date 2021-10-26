using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Xml;

namespace ToDoList_Lesson
{
    class Program
    {
        static void Main()
        {
            Building house = new Building(9, 3);
            house.Address = "ул. Ленина, 12";
            string json = JsonSerializer.Serialize(house);
            File.WriteAllText("house.json", json);

            string json1 = File.ReadAllText("house.json");
            Building house1 = JsonSerializer.Deserialize<Building>(json1);
            Console.WriteLine(house1.Address); // ул. Ленина, 12 
            Console.WriteLine(house1.Floors); // 3 
            Console.WriteLine(house1.Entrances); // 1 
        }
    }
}