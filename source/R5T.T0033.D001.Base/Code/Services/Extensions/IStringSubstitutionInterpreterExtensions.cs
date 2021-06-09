using System;
using System.Threading.Tasks;

using R5T.T0033.D001;
using R5T.T0033.T003;


namespace System
{
    public static class IStringSubstitutionInterpreterExtensions
    {
        /// <summary>
        /// Use the <see cref="StringSubstitutionInterpretationOptions.RecursionDefault"/> recursion value.
        /// </summary>
        public static Task<string> Interpret(this IStringSubstitutionInterpreter stringSubstitutionInterpreter, string substitutionTarget)
        {
            return stringSubstitutionInterpreter.Interpret(substitutionTarget, StringSubstitutionInterpretationOptions.RecursionDefault);
        }
    }
}
