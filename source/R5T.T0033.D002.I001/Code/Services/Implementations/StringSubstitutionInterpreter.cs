using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace R5T.T0033.D002.I001
{
    public class StringSubstitutionInterpreter : IStringSubstitutionInterpreter
    {
        public Task<string> Interpret(string substitutionTarget, IStringSubstitutionScheme stringSubstitutionScheme, IDictionary<string, string> substitutions,
            bool substitutionValuesByCodeProvided, bool recursive)
        {
            var output = recursive
                ? stringSubstitutionScheme.InterpretRecursively(substitutionTarget, substitutions, substitutionValuesByCodeProvided)
                : stringSubstitutionScheme.InterpretNonRecursively(substitutionTarget, substitutions, substitutionValuesByCodeProvided);

            return Task.FromResult(output);
        }
    }
}
