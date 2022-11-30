using System;
using System.Diagnostics;
using System.IO.Compression;
using nvc;

namespace nvc
{
    internal class Program
    {
        public const string NvcVersion = "1.0";
        static void Main(string[] args)
        {
            Terminal.PrintNvc();
            Stopwatch stopwatch = Stopwatch.StartNew();

            if (args.Length != 0 ) {
                string arg = args[0];
                string now = DateTime.Now.ToString("MM-dd-yy");
                
                if (arg == "-h" || arg == "--help")
                {
                    Terminal.WriteHelp("");
                    Environment.Exit(0);
                }

                // if long directory doesnt exist, check if folder exists in run dir
                if (!Directory.Exists(arg))
                {
                    if (Directory.Exists($@"{Environment.CurrentDirectory}\\{arg}"))
                    {
                        arg = Environment.CurrentDirectory + "\\" + arg;
                    } else
                    {
                        Terminal.Error("Directory does not exist!");
                        Environment.Exit(1);
                    }
                }

                // directory exists, zip it
                try
                {
                    ZipFile.CreateFromDirectory(arg, $@"{now}.zip");
                    stopwatch.Stop();
                    Terminal.Write($"{now}.zip created in {stopwatch.ElapsedMilliseconds}ms");
                } catch (Exception e)
                {
                    Terminal.Error(e.Message);
                    Environment.Exit(1);
                }
            } else
            {
                Terminal.Error("You must provide atleast one argument to NVC");
            }
        }
    }
}