using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer comp = new Computer();
            comp.Launch("Windows 8.1");
            Console.WriteLine(comp.OS.Name);

            // у нас не получится изменить ОС, так как объект уже создан    
            comp.OS = OS.getInstance("Windows 10");
            Console.WriteLine(comp.OS.Name);

            Console.ReadLine();
        }
    }

    class Computer
    {
        public OS OS { get; set; }
        public void Launch(string osName)
        {
            OS = OS.getInstance(osName);
        }
    }

    //Потоканебезопасный
    class OS
    {
        private static OS instance;

        public string Name { get; private set; }

        protected OS(string name)
        {
            this.Name = name;
        }

        public static OS getInstance(string name)
        {
            if (instance == null)
                instance = new OS(name);
            return instance;
        }
    }

    //Потокабезопасный
    class OSMT
    {
        private static OSMT instance;

        public string Name { get; private set; }
        private static object syncRoot = new Object();

        protected OSMT(string name)
        {
            this.Name = name;
        }

        public static OSMT getInstance(string name)
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new OSMT(name);
                }
            }
            return instance;
        }
    }

    //Потокабезопасный 
    public class Singleton
    {
        private static readonly Singleton instance = new Singleton();

        public string Date { get; private set; }

        private Singleton()
        {
            Date = System.DateTime.Now.TimeOfDay.ToString();
        }

        public static Singleton GetInstance()
        {
            return instance;
        }
    }
}
