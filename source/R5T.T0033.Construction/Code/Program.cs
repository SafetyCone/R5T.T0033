using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.T0033.D002.I001;


namespace R5T.T0033.Construction
{
    class Program
    {
        static async Task Main()
        {
            var interpretableString = "Hello world from %TEST1% on %TEST2%!!!";

            var interpreter = new StringSubstitutionInterpreter();

            var substitutions = new Dictionary<string, string>
            {
                { "TEST1", "Program" },
                { "TEST2", DateTime.Now.ToString() }
            };

            var interprettedString = await interpreter.Interpret(interpretableString, substitutions);

            Console.WriteLine($"Interprettable string:\n\n{interpretableString}\n\nInterpretted to:\n\n{interprettedString}");
        }
    }
}
