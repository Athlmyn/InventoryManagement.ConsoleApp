using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.ConsoleApp {
    public static class DataValidator {
        public static int GetIntInput(string prompt)
        {
            Console.Write( prompt );
            if (!int.TryParse( Console.ReadLine(), out int result ))
            {
                Console.WriteLine( "Invalid number." );
                throw new ArgumentException( "Invalid number." );
            }
            return result;
        }

        public static decimal GetDecimalInput(string prompt)
        {
            Console.Write( prompt );
            if (!decimal.TryParse( Console.ReadLine(), out decimal result ))
            {
                Console.WriteLine( "Invalid decimal number." );
                throw new ArgumentException( "Invalid decimal number." );
            }
            return result;
        }

        public static string GetStringInput(string prompt)
        {
            Console.Write( prompt );
            string result = Console.ReadLine();
            if (string.IsNullOrWhiteSpace( result ))
            {
                Console.WriteLine( "Input cannot be empty." );
                throw new ArgumentException( "Input cannot be empty." );
            }
            return result;
        }
    }
}
