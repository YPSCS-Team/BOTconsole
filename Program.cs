using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace BOTConsole
{
    class Program
    {
        static void Main(string[] args)
        {
//remark
            int exitcode;
            ProcessStartInfo ProcessInfo;
            Process process;
            ProcessInfo = new
            ProcessStartInfo(@"D:\EDA_Project\EC2013\NCCCTool\bin\Debug\NCCCTool.exe", "Upload EC2012");
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;
            // redirecting standard output and error
            ProcessInfo.RedirectStandardError = true;
            ProcessInfo.RedirectStandardOutput = true;

            process = Process.Start(ProcessInfo);

            process.WaitForExit();

            //Reading output and error
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitcode = process.ExitCode;
            Console.WriteLine("Output:{0}", output);
            if (!String.IsNullOrEmpty(error))
                Console.WriteLine("Error:{0}", error);
            if (exitcode != 0)
                Console.WriteLine("Exit Code:{0}", exitcode);

            process.Close();
            Console.ReadLine();
        }


        static void WriteMSG(string stype, string msg)
        {
            Console.WriteLine(stype + " => " + msg);
        }
    }
}
