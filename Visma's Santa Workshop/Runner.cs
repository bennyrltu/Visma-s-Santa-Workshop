using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visma_s_Santa_Workshop
{
    public class Runner
    {
        private TaskUtils console;
        private List<Workshop> santa = new List<Workshop>();
        public static readonly string dataFilePath = "data.csv";

        public Runner(TaskUtils console)
        {
            this.console=console;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    santa = TaskUtils.ReadData(dataFilePath);
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("Data fiile is missing!");
                    Console.WriteLine("Creating...");
                    File.Create(dataFilePath).Close();
                }
                TaskUtils.Choice();
                int result;
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    switch (result)
                    {
                        case 1:
                            TaskUtils.PrintAll(santa);
                            break;
                        case 2:
                            TaskUtils.CompleteEntries(santa);
                            break;
                        case 3:
                            TaskUtils.UnassignedChildrenCount(santa);
                            break;
                        case 4:
                            TaskUtils.UnassignedGiftCount(santa);
                            break;
                        case 5:
                            console.AddChildren(santa);
                            break;
                        case 6:
                            console.AddGift(santa);
                            break;
                        case 7:
                            console.RandomAssign(santa);
                            break;
                        case 8:
                            console.AddEntry(santa);
                            break;
                        case 9:
                            console.ManualAssign(santa);
                            break;
                        case 10:
                            TaskUtils.RemoveAllData(dataFilePath);
                            break;
                        case 11:
                            console.AssignAllGifts(santa);
                            break;
                        case 12:
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Empty input! / Non existing selection! \n");
                }
            }
        }
    }
}
