using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visma_s_Santa_Workshop
{
    public class TaskUtils
    {

        public static List<Workshop> ReadData(string fileName)
        {
            List<Workshop> questionList = new List<Workshop>();
            string[] lines = File.ReadAllLines(fileName).ToArray();
            foreach (var line in lines)
            {
                string[] parts = line.Trim().Split(';');
                string name = parts[0];
                string gift = parts[1];

                Workshop newData = new Workshop(name, gift);
                questionList.Add(newData);
            }
            return questionList;
        }

        public static void WriteData(string santa, string resultsPath)
        {
            StreamWriter writer = new StreamWriter(resultsPath, true, Encoding.UTF8);
            writer.WriteLine(santa);
            writer.Close();
        }

        public static void RemoveAllData(string resultsPath)
        {
            if (File.Exists(resultsPath))
            {
                Console.Clear();
                Console.WriteLine("All data removed! \n");
                File.Delete(resultsPath);
                File.Create(resultsPath).Close();
            }
        }

        public static void Choice()
        {
            Console.WriteLine("Welcome to the Visma's Santa workshop! Type the number and press enter of what you would like to do!");
            Console.WriteLine("1. See all registered data");
            Console.WriteLine("2. See entries with no missing fields");
            Console.WriteLine("3. See count of of unassigned children");
            Console.WriteLine("4. See count of of unassigned gifts");
            Console.WriteLine("5. Add new children to the list");
            Console.WriteLine("6. Add new gift to the list");
            Console.WriteLine("7. Assign entered gift to a random child in list");
            Console.WriteLine("8. Add child and corresponding gift entry");
            Console.WriteLine("9. Assign a certain gift to a specific child");
            Console.WriteLine("10. Delete all data");
            Console.WriteLine("11. Assign ALL gifts at once");
            Console.WriteLine("12. Clear console");
        }

        public static void Header()
        {
            Console.WriteLine(new string('-', 63));
            Console.WriteLine("|{0,-25}|{1,-35}|", "Children list", "Gifts list");
            Console.WriteLine(new string('-', 63));
        }
        public static void PrintAll(List<Workshop> data)
        {
            Console.Clear();
            Header();
            foreach (var item in data)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine(new string('-', 63));
            Console.WriteLine("");
        }

        public static void CompleteEntries(List<Workshop> data)
        {
            Console.Clear();
            Header();
            foreach (var item in data)
            {
                if (item.Name.Length != 0 && item.Gift.Length != 0)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.WriteLine(new string('-', 63));
            Console.WriteLine("");
        }

        public static void UnassignedChildrenCount(List<Workshop> data)
        {
            Console.Clear();
            int count = 0;
            foreach (var item in data)
            {
                if (item.Name.Length == 0)
                {
                    count++;
                }
            }
            Console.WriteLine(new string('-', 63));
            Console.WriteLine("Unassigned children count: " + count);
            Console.WriteLine(new string('-', 63));
        }

        public static void UnassignedGiftCount(List<Workshop> data)
        {
            Console.Clear();
            int count = 0;
            foreach (var item in data)
            {
                if (item.Gift.Length == 0)
                {
                    count++;
                }
            }
            Console.WriteLine(new string('-', 63));
            Console.WriteLine("Unassigned gift count: " +count);
            Console.WriteLine(new string('-', 63));
        }

        public void AddChildren(List<Workshop> data)
        {
            Console.Clear();
            Console.WriteLine("Enter child's name: ");
            string name = Console.ReadLine();
            Workshop newData = new Workshop(name, null);
            if (!data.Any(x => x.Equals(newData)))
            {
                WriteData(newData.ToFile(), Runner.dataFilePath);
            }
            else
            {
                Console.WriteLine("Exists");
            }
        }

        public void AddGift(List<Workshop> data)
        {
            Console.Clear();
            string gift = System.Console.ReadLine();
            Workshop newData = new Workshop(null, gift);
            WriteData(newData.ToFile(), Runner.dataFilePath);
        }
        public void AddEntry(List<Workshop> data)
        {
            Console.Clear();
            Console.WriteLine("Enter child's name:");
            string name = System.Console.ReadLine();
            if (!data.Any(x => x.Name.Equals(name)))
            {
                Console.WriteLine("Enter gift name:");
                string gift = System.Console.ReadLine();
                Workshop newData = new Workshop(name, gift);
                WriteData(newData.ToFile(), Runner.dataFilePath);
            }
            else
            {
                Console.WriteLine("Child with such name already exists! \n");
            }

        }

        public void RandomAssign(List<Workshop> data)
        {
            Console.Clear();
            Console.WriteLine("Enter gift name:");
            string gift = System.Console.ReadLine();
            Random rnd = new Random();
            int index = rnd.Next(0, data.Count);
            List<string> linesList = File.ReadAllLines(Runner.dataFilePath).ToList();
            linesList[index] = data[index].Name +";" +gift;
            File.WriteAllLines(Runner.dataFilePath, linesList.ToArray());
        }

        public void ManualAssign(List<Workshop> data)
        {
            Console.Clear();
            Header();
            foreach (var item in data)
            {
                System.Console.WriteLine(item.ToString());
            }
            Console.WriteLine("");
            Console.WriteLine("Enter child name:");
            string name = System.Console.ReadLine();

            int index = data.FindIndex(x => x.Name == name);
            if (index == -1)
            {
                Console.Clear();
                Console.WriteLine("Non existing child! Try entering existing child or check for mistakes! \n");
            }
            else
            {
                Console.WriteLine("Enter gift name:");
                string gift = System.Console.ReadLine();

                List<string> linesList = File.ReadAllLines(Runner.dataFilePath).ToList();
                linesList[index] = data[index].Name +";" +gift;
                File.WriteAllLines(Runner.dataFilePath, linesList.ToArray());
            }
        }

        public void AssignAllGifts(List<Workshop> data)
        {
            Console.Clear();
            int index = 0;

            if (data.Count(x => x.Name.Length > 0) == data.Count(x => x.Gift_Name.Length > 0))
            {
                foreach (var item in data)
                {
                    Console.WriteLine("Enter " + index+ " gift name");
                    string gift = Console.ReadLine();
                    List<string> linesList = File.ReadAllLines(Runner.dataFilePath).ToList();
                    linesList[index] = data[index].Name +";" +gift;
                    File.WriteAllLines(Runner.dataFilePath, linesList.ToArray());
                    index++;
                }
            }
            else
            {
                Console.WriteLine("Not identical number of gifts and children! Try removing some. \n");
            }
        }
    }
}

