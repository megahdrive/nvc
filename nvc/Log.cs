using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// todo: make log to file

namespace nvc
{
    internal class Log
    {
        public static void PrintNvc() {
            Console.WriteLine($"NVC {nvc.Program.NvcVersion}, since 4/20/22.");
        }

        public static void Error(string msg)
        {
            Console.WriteLine($"[ ERROR ] {msg}");
        }

        public static void Write(string msg) { Console.WriteLine(msg);  }

        public static void WriteHelp(string finale) {
            Console.WriteLine();
            Console.WriteLine("-h       Display's help about NVC");
            Console.WriteLine("--help   Display's help about NVC");
            Console.WriteLine("[folder] Zips the folder in the argument");
            Console.WriteLine($"{finale}");
        }
    }
}
