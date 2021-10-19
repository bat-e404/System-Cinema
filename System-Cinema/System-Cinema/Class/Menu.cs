using System;
using System.Collections.Generic;
using System.Text;

namespace System_Cinema.Class
{
    public class Menu
    {
        //Funcion que nos imprimira el logo en la cabecera del sistema
        public static void NameHader()
        {
            Console.Clear();
            Console.WriteLine("\n\t░██████╗██╗░░░██╗░██████╗███████╗███╗░░░███╗  ░░░░░░  ░█████╗░██╗███╗░░██╗███████╗███╗░░░███╗░█████╗░ ");
            Console.WriteLine("\t██╔════╝╚██╗░██╔╝██╔════╝██╔════╝████╗░████║  ░░░░░░  ██╔══██╗██║████╗░██║██╔════╝████╗░████║██╔══██╗ ");
            Console.WriteLine("\t╚█████╗░░╚████╔╝░╚█████╗░█████╗░░██╔████╔██║  █████╗  ██║░░╚═╝██║██╔██╗██║█████╗░░██╔████╔██║███████║ ");
            Console.WriteLine("\t░╚═══██╗░░╚██╔╝░░░╚═══██╗██╔══╝░░██║╚██╔╝██║  ╚════╝  ██║░░██╗██║██║╚████║██╔══╝░░██║╚██╔╝██║██╔══██║ ");
            Console.WriteLine("\t██████╔╝░░░██║░░░██████╔╝███████╗██║░╚═╝░██║  ░░░░░░  ╚█████╔╝██║██║░╚███║███████╗██║░╚═╝░██║██║░░██║ ");
            Console.WriteLine("\t╚═════╝░░░░╚═╝░░░╚═════╝░╚══════╝╚═╝░░░░░╚═╝  ░░░░░░  ░╚════╝░╚═╝╚═╝░░╚══╝╚══════╝╚═╝░░░░░╚═╝╚═╝░░╚═╝ ");
            
        }
        public static bool DespliegoMenu()
        {

            return true;
        }
        private static void StructurMenu()
        {
            Console.WriteLine();
        }
    }
}
