using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Services;
using Sample.Models;

namespace Sample.Views
{
    class CounterViewer
    {
        private readonly ICounterService counterService;

        public CounterViewer(ICounterService counterService)
        {
            this.counterService = counterService;
        }

        public void ShowAllCounters()
        {
            ShowLine();
            foreach (var counter in counterService.GetAllCounters())
            {
                Console.WriteLine(counter.Name + " : " + counter.Count);
            }
            Console.WriteLine("Type --help , if you want see commands.");
            ShowLine();
        }

        public void AcceptCommand()
        {
            Console.Write("Type Command : ");
            var command = Console.ReadLine();
            if (command.Equals("--help"))
            {
                ShowCommands();
                AcceptCommand();
                return;
            }
            ICounter counter = PickCounterFromCommand(command);
            if (counter == null)
            {
                Console.WriteLine(command + " is not command.");
                AcceptCommand();
                return;
            }

            switch (command.Split(' ').First().First())
            {
                case '+':
                    counterService.Increment(counter, command.Split(' ').First().Length);
                    break;
                case '-':
                    counterService.Decrement(counter, command.Split(' ').First().Length);
                    break;
                case 'a':
                    counterService.Add(counter);
                    break;
                case'd':
                    counterService.Delete(counter);
                    break;

                default:
                    Console.WriteLine(command + " is not command.");
                    AcceptCommand();
                    return;
            }
        }

        public void ShowCommands()
        {
            Console.WriteLine("+ \"counter name\" : Increment count for num of '+' times.");
            Console.WriteLine("- \"counter name\" : Decrement count for num of '-' times.");
            Console.WriteLine("a \"counter name\" : Add new counter.");
            Console.WriteLine("d \"counter name\" : Delete counter.");
        }

        public void ShowLine()
        {
            Console.WriteLine("+--------------------------------------------------------------+");
        }

        private ICounter PickCounterFromCommand(string command)
        {
            int nameStart = command.IndexOf('\"');
            int nameEnd = command.LastIndexOf('\"');
            if (nameStart == nameEnd) return null;

            string name = command.Substring(nameStart + 1, nameEnd - nameStart - 1);
            return counterService.Find(name);
        }
    }
}
