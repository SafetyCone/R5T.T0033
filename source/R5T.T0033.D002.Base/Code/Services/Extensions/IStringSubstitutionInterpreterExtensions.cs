using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.T0033;
using R5T.T0033.D002;
using R5T.T0033.T003;


namespace System
{
    public static class IStringSubstitutionInterpreterExtensions
    {
        /// <summary>
        /// Interprety using the <see cref="StringSubstitutionInterpretationOptions.SubstitutionValuesByCodeProvidedDefault"/> and <see cref="StringSubstitutionInterpretationOptions.RecursionDefault"/>.
        /// </summary>
        public static Task<string> Interpret(this IStringSubstitutionInterpreter stringSubstitutionInterpreter,
            string substitutionTarget, IStringSubstitutionScheme stringSubstitutionScheme, IDictionary<string, string> substitutions)
        {
            return stringSubstitutionInterpreter.Interpret(substitutionTarget, stringSubstitutionScheme, substitutions,
                StringSubstitutionInterpretationOptions.SubstitutionValuesByCodeProvidedDefault,
                StringSubstitutionInterpretationOptions.RecursionDefault);
        }
    }
}
