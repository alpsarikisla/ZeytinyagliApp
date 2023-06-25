using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxingUnboxing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //c# Typesafe bir dildir.
            //Her tür object türünden doğar

            int sayi = 45;
            object obj = 15;
            obj = "Selam Napin?";

            obj = sayi;//Boxing
            //Herhangi bir türdeki verinin object türündeki değişkene atılması olayına boxing denir
            Console.WriteLine(obj);

            //string veri = (string)obj;//Unboxing

            int veri = (int)obj;//Unboxing

            Console.WriteLine(veri + 15);

        }
    }
}
