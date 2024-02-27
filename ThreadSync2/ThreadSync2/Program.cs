using System.Reflection.Metadata;
using System.Diagnostics;
using System.Threading;
using System;

namespace ThreadSync2
{
    internal class Program
    {
        private static Mutex _mutex = new Mutex(true, "Global\\Mutex");
        private static ManualResetEvent _manualResetEvent = new ManualResetEvent(false);
        private static AutoResetEvent _autoResetEvent = new AutoResetEvent(false);
        static void Main()
        {
            if (!_mutex.WaitOne(0))
            {
                Console.WriteLine("The program is already running");
                return;
            }
            var thread1 = new Thread(ThreadProc1);
            thread1.Name = "Thread 1";
            thread1.Start();

            var thread2 = new Thread(ThreadProc2);
            thread2.Name = "Thread 2";
            thread2.Start();

            Thread.Sleep(300);

            for (int i = 3; i < 5; i++)
            {
                var thread = new Thread(ThreadProcManual);
                thread.Name = $"Thread {i}";
                thread.Start();
                Thread.Sleep(300);
            }

            for (int i = 5; i < 7; i++)
            {
                var thread = new Thread(ThreadProcAuto);
                thread.Name = $"Thread {i}";
                thread.Start();
                Thread.Sleep(300);
            }
            _mutex.ReleaseMutex();
        }
        public static void ThreadProc1()
        {
            var threadName = Thread.CurrentThread.Name;
            Console.WriteLine($"{threadName} starts");

            Thread.Sleep(2000);
            Console.WriteLine($"{threadName} sets signal");
            _manualResetEvent.Set();

            Thread.Sleep(300);

            Console.WriteLine($"Thread 1 resets signal");
            _manualResetEvent.Reset();
        }
        public static void ThreadProc2()
        {
            var threadName = Thread.CurrentThread.Name;
            Console.WriteLine($"{threadName} starts");
            for (int i = 0; i < 2; i++)
            {
                Thread.Sleep(1500);
                Console.WriteLine($"{threadName} sets signal");
                _autoResetEvent.Set();
            }
        }
        public static void ThreadProcAuto()
        {
            var threadName = Thread.CurrentThread.Name;
            Console.WriteLine($"{threadName} is waiting for an auto signal from Thread 2");
            _autoResetEvent.WaitOne();
            Console.WriteLine($"{threadName} received an auto signal, continue working");
        }
        public static void ThreadProcManual()
        {
            var threadName = Thread.CurrentThread.Name;
            Console.WriteLine($"{threadName} is waiting for a manual signal from Thread 1");
            _manualResetEvent.WaitOne();
            Console.WriteLine($"{threadName} received a manual signal, continue working");
        }
    }
}