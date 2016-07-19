using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;



namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.Load("HelloLibrary");
            Reflect.ShowAsmInfo(asm);
            Type [] t = asm.GetTypes();
            Console.WriteLine("Type your name ");
            Reflect.RunMethodHello(Console.ReadLine(), t[0]);
            Console.ReadLine();
        }
    }
}
