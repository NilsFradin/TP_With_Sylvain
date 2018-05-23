using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.ECommerce.Fluent;

namespace Modele.Console.ECommerce
{
    class Program
    {
        static void Main(string[] args)
        {
            ContextFluent context = new ContextFluent();
            context.Clients.ToList();
        }
    }
}
