using System;
using System.Diagnostics;

namespace TaskManager
{
    /// <summary>
    /// 
    /// </summary>
    class ProgramTaskManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ProcRead();
            do
            {
                Console.WriteLine("Введите ID или Имя процесса для его завершения");
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

        /// <summary>
        /// 
        /// </summary>
        private static void ProcRead()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                Console.WriteLine($"ID: {process.Id} \tИмя: {process.ProcessName}");
            }
        }
    }
}

