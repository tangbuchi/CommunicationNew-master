using ipScan.Classes.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IPScanForm iPScanForm = new IPScanForm();
            iPScanForm.StartScan("192.168.61.1","192.168.61.254");
            while (IPScanForm.IPScanDone == false)
            {
                if (IPScanForm.IPScanDone)
                {
                    Console.WriteLine("------------------------");
                }
                System.Threading.Thread.Sleep(300);
            }
            //foreach (var item in IPScanForm.GetResultIPAddressStr)
            //{
            //    Console.WriteLine(item);
            //}

            Console.ReadLine();
        }
    }
}
