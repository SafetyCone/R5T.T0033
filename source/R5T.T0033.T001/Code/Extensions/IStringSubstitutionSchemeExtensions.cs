using System;
using System.Collections.Generic;

using R5T.T0033;
using R5T.T0033.T001;


namespace System
{
    public static class IStringSubstitutionSchemeExtensions
    {
        public static string InterpretRecursively(this IStringSubstitutionScheme stringSubstitutionScheme, string substitutionTargetString, IDictionary<string, string> substitutions, bool substitutionValuesByCodeProvided = false)
        {
            var substitutionTarget = new StringBuilderSubstitutionTarget(substitutionTargetString);

            var output = stringSubstitutionScheme.InterpretRecursively(substitutionTarget, substitutions, substitutionValuesByCodeProvided);
            return output;
        }

        public static string InterpretNonRecursively(this IStringSubstitutionScheme stringSubstitutionScheme, string substitutionTargetString, IDictionary<string, string> substitutions, bool substitutionValuesByCodeProvided = false)
        {
            var substitutionTarget = new StringBuilderSubstitutionTarget(substitutionTargetString);

            var output = stringSubstitutionScheme.InterpretNonRecursively(substitutionTarget, substitutions, substitutionValuesByCodeProvided);
            return output;
        }

        /// <summary>
        /// Selects <see cref="InterpretRecursively(IStringSubstitutionScheme, string, IDictionary{string, string}, bool)"/> as the default interpretation method.
        /// </summary>
        public static string Interpret(this IStringSubstitutionScheme stringSubstitutionScheme, string substitutionTargetString, IDictionary<string, string> substitutions, bool substitutionValuesByCodeProvided = false)
        {
            var output = stringSubstitutionScheme.InterpretRecursively(substitutionTargetString, substitutions, substitutionValuesByCodeProvided);
            return output;
        }
    }
}
