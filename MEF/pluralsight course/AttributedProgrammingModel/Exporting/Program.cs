using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;

namespace Exporting
{
    [InheritedExport]
    public interface IClass { }

    public class ClassA : IClass { }

    public class ClassB : ClassA { }

    class Program
    {
        static void Main(string[] args)
        {
            var catalog = new AssemblyCatalog(typeof(Program).Assembly);
            var container = new CompositionContainer(catalog);

            foreach (var part in container.Catalog.Parts)
            {
                Console.WriteLine(part.ToString());
            }
        }
    }
}
