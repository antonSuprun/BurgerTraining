using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace SimpleCalculator
{
    [Export(typeof(ICalculator))]
    public class MySimpleCalculator : ICalculator
    {
        public String Calculate(String input)
        { 
            int fn = FindFirstNonDigit(input);
            
            if (fn < 0)
            {
                return "Could not parse command.";
            }
            int left;
            int right;
            try
            {
                left = int.Parse(input.Substring(0, fn));
                right = int.Parse(input.Substring(fn + 1));
            }
            catch 
            {
                return "Could not parse command.";
            }
            Char operation = input[fn];
            String result = "Operation Not Found!";
            foreach (Lazy<IOperation, IOperationData> currentOperation in operations)
            {
                if (currentOperation.Metadata.Symbol.Equals(operation))
                {
                    result = currentOperation.Value.Operate(left, right).ToString();
                    break;
                }
            }
            return result;
        }

        private int FindFirstNonDigit(String s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!(Char.IsDigit(s[i]))) return i;
            }
            return -1;
        }
        

        [ImportMany]
        private IEnumerable<Lazy<IOperation, IOperationData>> operations;
    }
}
