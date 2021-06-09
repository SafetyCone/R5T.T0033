using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.T0033.D002;
using R5T.T0033.T002;



namespace System
{
    public static class IStringSubstitutionInterpreterExtensions
    {
        public static Task<string> Interpret(this IStringSubstitutionInterpreter stringSubstitutionInterpreter,
            string substitutionTarget, IDictionary<string, string> substitutions,
            bool substitutionValuesByCodeProvided, bool recursive)
        {
            var percentStringSubstitutionScheme = new PercentStringSubstitutionScheme();

            return stringSubstitutionInterpreter.Interpret(substitutionTarget, percentStringSubstitutionScheme, substitutions,
                substitutionValuesByCodeProvided, recursive);
        }

        public static Task<string> Interpret(this IStringSubstitutionInterpreter stringSubstitutionInterpreter,
            string substitutionTarget, IDictionary<string, string> substitutions)
        {
            var percentStringSubstitutionScheme = new PercentStringSubstitutionScheme();

            return stringSubstitutionInterpreter.Interpret(substitutionTarget, percentStringSubstitutionScheme, substitutions);
        }
    }
}
