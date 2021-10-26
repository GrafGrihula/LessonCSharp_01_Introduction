using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace ToDoList
{
    /// <summary>
    /// 
    /// Список задач (ToDo-list).
    /// 
    /// Мучался, мучался, потом всё-таки заглянул в "разбор ДЗ".
    /// "Превращать" готовый код в "свой" не стал, потому-что так не интересно.
    /// За-то оценил свои попытки решить данную задачу.
    /// Оказалось, что думал я не с таким размахом)))
    /// 
    /// В результате добавил в данный (готовый) код обработку исключения,
    /// которое появлялось при первом запуске и попытке открыть файл 'todo.*'
    /// со структурой, которая отличается от ожидаемой)
    /// 
    /// </summary>
    class ProgramToDoList
    {
        static void Main(string[] args)
        {
            string format = (args.Length > 0) ? args[0] : "json";
            string fileName = $"todo.{format}";

            List<ToDo> todoList = ReadFile(format, fileName); // Exception
            ShowList(todoList);

            while (true)
            {
                Console.Write($"'x' - отметить выполненную задачу\n" +
                               "'n' - добавить новую задачу\n" +
                               "'q' - выход: ");
                string choise = Console.ReadLine();
                Console.WriteLine();
                switch (choise)
                {
                    case "x": // 'i' заменил на 'x' (не принципиально)
                    case "ч": 
                        Edit(ref todoList);
                        break;
                    case "n":
                    case "т":
                        Add(ref todoList);
                        break;
                    case "q":
                    case "й":
                        Save(format, fileName, todoList);
                        return;
                    default:
                        Console.WriteLine("Ошибка.");
                        break;
                }
                ShowList(todoList);
            }
        }

        static void ShowList(List<ToDo> todoList)
        {
            for (int i = 0; i < todoList.Count; i++)
            {
                string isTaskDone = todoList[i].IsDone ? "[X]" : "";
                Console.WriteLine($"{i}  {isTaskDone,3} {todoList[i].Title}");
            }
            Console.WriteLine();
        }

        static void Edit(ref List<ToDo> todoList)
        {
            if (todoList.Count == 0)
            {
                Console.WriteLine("Список задач пуст.");
                return;
            }
            Console.Write("Введите порядковый номер задачи: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (number < todoList.Count)
                    todoList[number].IsDone = true;
                else
                {
                    Console.WriteLine($"Указан неверный номер задачи. " +
                        $"Введите номер от 0 до {todoList.Count - 1}");
                    Edit(ref todoList);
                }
            }
        }

        static void Add(ref List<ToDo> todoList)
        {
            Console.Write("Введите текст задачи: ");
            string task = Console.ReadLine();
            todoList.Add(new ToDo(task));
        }

        static List<ToDo> ReadFile(string format, string fileName)
        {
            List<ToDo> todoList;

            switch (format)
            {
                case "xml":
                    todoList = ReadXml(fileName);
                    break;
                case "bin":
                    todoList = ReadBin(fileName);
                    break;
                case "json":
                default:
                    todoList = ReadJson(fileName); // Exception
                    break;
            }
            return todoList;
        }

        static void Save(string format, string fileName, List<ToDo> todoList)
        {
            switch (format)
            {
                case "xml":
                    SaveXml(todoList, fileName);
                    break;
                case "bin":
                    SaveBin(todoList, fileName);
                    break;
                case "json":
                default:
                    SaveJson(todoList, fileName);
                    break;
            }
        }

        static List<ToDo> ReadXml(string fileName)
        {
            List<ToDo> todoList = new List<ToDo>();
            if (File.Exists(fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<ToDo>));
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    todoList = (List<ToDo>)serializer.Deserialize(fs);
                }
            }
            return todoList;
        }

        static List<ToDo> ReadJson(string fileName)
        {
            List<ToDo> todoList = new List<ToDo>();
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                
                // Добавил "отлов" ошибки при открытии файла с "иной" структурой
                try
                {
                    todoList = JsonSerializer.Deserialize<List<ToDo>>(jsonString); // Exception
                }
                catch
                {
                    Console.WriteLine($"Нарушена структура данных в файле '{fileName}'.\n" +
                        "Файл не прочитан.\n" +
                        $"При добавлении новой задачи файл '{fileName}' обновится.");
                }                
            }
            return todoList;
        }

        static List<ToDo> ReadBin(string fileName)
        {
            List<ToDo> todoList = new List<ToDo>();
            if (File.Exists(fileName))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    todoList = (List<ToDo>)formatter.Deserialize(fs);
                }
            }
            return todoList;
        }

        static void SaveXml(List<ToDo> todoList, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ToDo>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fs, todoList);
            }
        }

        static void SaveJson(List<ToDo> todoList, string fileName)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonSerialize = JsonSerializer.Serialize(todoList, options);
            File.WriteAllText(fileName, jsonSerialize);
        }

        static void SaveBin(List<ToDo> todoList, string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                formatter.Serialize(fs, todoList);
            }
        }
    }
}
