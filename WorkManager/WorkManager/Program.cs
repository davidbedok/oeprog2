using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkManager
{
    public class Program
    {

        private static WorkManager MANAGER = new WorkManager();

        private static void testWork()
        {
            System.Console.WriteLine("### testWork ###");
            Work<String> stringWork = new StringWork("foo", "one", "two", "three");
            System.Console.WriteLine(stringWork);
            stringWork.updateProgress("one");
            System.Console.WriteLine(stringWork);
            stringWork.updateProgress("two");
            System.Console.WriteLine(stringWork);
            try
            {
                stringWork.updateProgress("two");
                System.Console.WriteLine(stringWork);
            }
            catch (InvalidUpdateParameterException e)
            {
                System.Console.WriteLine(e.Message);
            }
            try
            {
                stringWork.updateProgress("no");
                System.Console.WriteLine(stringWork);
            }
            catch (InvalidUpdateParameterException e)
            {
                System.Console.WriteLine(e.Message);
            }
            stringWork.updateProgress("three");
            System.Console.WriteLine(stringWork);
            System.Console.WriteLine("\n\n");
        }

        private static void testManager()
        {
            String stringWorkId = Program.MANAGER.createWork("one", "two", "three");
            Program.printWorkProgress(stringWorkId);
            String integerWorkId = Program.MANAGER.createWork(10, 20, 30, 40);
            Program.printWorkProgress(integerWorkId);

            System.Console.WriteLine(Program.MANAGER);

            Program.MANAGER.updateWorkProgress(stringWorkId, "two");
            Program.printWorkProgress(stringWorkId);

            Program.MANAGER.updateWorkProgress(integerWorkId, 20);
            Program.printWorkProgress(integerWorkId);

            Program.MANAGER.updateWorkProgress(integerWorkId, 10);
            Program.printWorkProgress(integerWorkId);

            System.Console.WriteLine(Program.MANAGER);

            try
            {
                Program.MANAGER.updateWorkProgress(integerWorkId, "foo");
            }
            catch (WorkManagerException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        private static void printWorkProgress(String workId)
        {
            System.Console.WriteLine("Progress of " + workId + ": " + Program.MANAGER.getWorkProgress(workId) + "%\n");
            
        }

        private static void Main(string[] args)
        {
            Program.testWork();
            Program.testManager();
        }
    }
}
