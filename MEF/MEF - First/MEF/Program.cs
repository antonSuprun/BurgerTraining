using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using SimpleCalculator;

namespace MEF
{
    class Program
    {
        private CompositionContainer container;

        [Import(typeof(ICalculator))]
        public ICalculator Calculator{get;set;}

        private Program()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog("D:\\Study\\BurgerTraining\\MEF\\MEF\\Extensions"));
            container = new CompositionContainer(catalog);
            
            try
            {
                this.container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
                throw;
            }
        }

        static void Main(string[] args)
        {
            Program p = new Program(); 
            String s;
            
            Console.WriteLine("Enter Command:");
            while (true)
            {
                s = Console.ReadLine();
                Console.WriteLine(p.Calculator.Calculate(s));
            }            
        }
    }
}
