using System;
using System.Diagnostics;

namespace FileManager
{
    class TaskManager
    {
        public void MainTask()
        {
            ProcRead();
            do
            {
                Console.WriteLine("Введите ID или Имя процесса (затем Enter) для его завершения. Enter, затем Esc - закрыть панель");
                string procKill = Console.ReadLine();
                bool isNum = int.TryParse(procKill, out _);
                if (isNum)
                {
                    int idNum = int.Parse(procKill);
                    Process.GetProcessById(idNum).Kill();
                    Console.Clear();
                    ProcRead();
                }
                else if (procKill != "")
                {
                    Process[] process = Process.GetProcesses();
                    foreach(Process nameProc in process)
                    {
                        if (nameProc.ProcessName.Contains($"{procKill}"))
                        {
                            nameProc.Kill();
                        }
                    }
                    Console.Clear();
                    ProcRead();
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void ProcRead()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                Console.WriteLine($"ID: {process.Id} \tПриор.: {process.BasePriority} \tИмя: {process.ProcessName}");
            }
        }
    }
}

