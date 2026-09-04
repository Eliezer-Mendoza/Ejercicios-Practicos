using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace algo
{
    class Principal
    {
        static void Main(string[] args)
        { 
            Queue<string> Cola = new Queue<string>();
            Cola.Enqueue("Javier");
            Cola.Enqueue("Shellsy");
            Cola.Enqueue("Isabel");
            while (Cola.Count>0)
            {
                Console.WriteLine(Cola.Dequeue());
            }
        }
    }
}