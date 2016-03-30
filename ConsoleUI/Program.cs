using System;
using System.Threading;
using Task1;
using Timer = Task1.Timer;

namespace ConsoleUI
{
    #region Listeners
    sealed class Computer
    {
        private void ComputerMsg(object sender, NewMessageEventArgs eventArgs)
        {
            Console.WriteLine("I am computer!");
            Console.WriteLine($"Text: {eventArgs.Text}, Time:  {eventArgs.Time}");
        }

        public void Register(Timer timer)
        {
            timer.TimerTick += ComputerMsg;
        }

        public void Unregister(Timer timer)
        {
            timer.TimerTick -= ComputerMsg;
        }
    }

    class Laptop
    {
        private void LaptopMsg(object sender, NewMessageEventArgs eventArgs)
        {
            Console.WriteLine("I am laptop!");
            Console.WriteLine($"Text: {eventArgs.Text}, Time:  {eventArgs.Time}");
        }

        public void Register(Timer timer)
        {
            timer.TimerTick += LaptopMsg;
        }

        public void Unregister(Timer timer)
        {
            timer.TimerTick -= LaptopMsg;
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();

            Computer computer = new Computer();
            computer.Register(timer);

            Laptop laptop = new Laptop();
            laptop.Register(timer);

            timer.SimulateTimerTick("Shutdown", 1);

            Thread.Sleep(2000);
            Console.WriteLine();

            computer.Unregister(timer);
            
            timer.SimulateTimerTick("Enable", 2);

            Console.ReadKey();
        }
    }
}
