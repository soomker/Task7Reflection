using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Task7
{
    class Reflect
    {
      public static void ShowAsmInfo(Assembly asm)
        {
            Type[] types = asm.GetTypes();

            foreach (Type t in types)
            {
                Console.WriteLine("Type is " + t.Name + " " + t.Attributes);
                foreach (FieldInfo fi in t.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
                {
                    Console.WriteLine("FIELD " + fi.Name + " " + fi.FieldType);
                }
                foreach (MethodInfo mi in t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
                {
                    Console.WriteLine("METHOD "+mi.Name+ " " +mi.ReturnType + " " +mi.Attributes);
                    foreach (ParameterInfo pi in mi.GetParameters())
                    {
                        Console.WriteLine("Parametrs " + pi.Name + " " + pi.ParameterType);
                    }
                }
                foreach (PropertyInfo pi in t.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
                {
                    Console.WriteLine("PROPERTY " + pi.Name + " " + pi.GetMethod + " " +pi.SetMethod + " " + pi.Attributes);
                }

                foreach (ConstructorInfo ci in t.GetConstructors(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
                {
                    Console.WriteLine("CONSTRUCTOR " + ci.Name + " " + ci.Attributes);
                }
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------- INFO ABOUT ASSEMBLY "+asm.FullName+" --------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

        }


        private static void CorrectTheProperty(Type type)
        {
            FieldInfo fi = type.GetField("hello", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            fi.SetValue(type, "Hello, ");
        }
        public static void RunMethodHello(string name, Type t)
        {
            CorrectTheProperty(t);
            MethodInfo mi = t.GetMethod("Hello", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            object strObj = mi.Invoke(null,new object[] {name});
            Console.WriteLine((string)strObj);
        }
    }
}
