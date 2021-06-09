using System;
using System.Collections.Generic;
using System.Linq;

using R5T.Magyar;

using R5T.T0033;


namespace System
{
    public static class IStringSubstitutionSchemeExtensions
    {
        public static WasFound<SubstitutionSite> FindNextSubstitution(this IStringSubstitutionScheme stringSubstitutionScheme, ISubstitutionTarget substitutionTarget)
        {
            var output = stringSubstitutionScheme.FindNextSubstitutionSite(substitutionTarget, IndexHelper.DefaultStartIndex);
            return output;
        }

        /// <summary>
        /// Converts substitution values by substitution token ("APP_DATA") to substitution values by substition code ("%APP_DATA%").
        /// </summary>
        public static Dictionary<string, string> GetSubstitutionValuesByCode(this IStringSubstitutionScheme stringSubstitutionScheme,
            IDictionary<string, string> substitutionValuesByToken)
        {
            var output = substitutionValuesByToken.ToDictionary(
                x => stringSubstitutionScheme.CreateSubstitutionCode(x.Key),
                x => x.Value);

            return output;
        }

        public static bool HasNextSubstitution(this IStringSubstitutionScheme stringSubstitutionScheme, ISubstitutionTarget substitutionTarget, int startIndex, out SubstitutionSite substitutionSite)
        {
            var wasFound = stringSubstitutionScheme.FindNextSubstitutionSite(substitutionTarget, startIndex);

            substitutionSite = wasFound.Result;

            return wasFound;
        }

        private delegate int NextStartIndexProvider(int substitutionSiteIndex, string substitutionValue);

        private static void InterpretTarget_Internal(this IStringSubstitutionScheme stringSubstitutionScheme, ISubstitutionTarget substitutionTarget, IDictionary<string, string> substitutions, bool substitutionValuesByCodeProvided,
            NextStartIndexProvider nextStartIndexProvider)
        {
            var substitutionValuesByCode = substitutionValuesByCodeProvided
                ? substitutions
                : stringSubstitutionScheme.GetSubstitutionValuesByCode(substitutions);

            int startIndex = 0;
            while (stringSubstitutionScheme.HasNextSubstitution(substitutionTarget, startIndex, out var substitutionSite))
            {
                var substitutionValue = substitutionValuesByCode[substitutionSite.SubstitutionCode];

                substitutionTarget.Replace(substitutionSite.SubstitutionCode, substitutionValue, substitutionSite.Index);

                startIndex = nextStartIndexProvider(substitutionSite.Index, substitutionValue);
            }
        }

        public static void InterpretTargetRecursively(this IStringSubstitutionScheme stringSubstitutionScheme, ISubstitutionTarget substitutionTarget, IDictionary<string, string> substitutions, bool substitutionValuesByCodeProvided = false)
        {
            // Since replacement values might themselves contain replacement codes, start searching from the start of the successful substitution.
            static int NextStartIndexProvider(int substitutionSiteIndex, string substitutionValue)
            {
                var output = substitutionSiteIndex;
                return output;
            }

            stringSubstitutionScheme.InterpretTarget_Internal(substitutionTarget, substitutions, substitutionValuesByCodeProvided,
                NextStartIndexProvider);
        }

        public static void InterpretTargetNonRecursively(this IStringSubstitutionScheme stringSubstitutionScheme, ISubstitutionTarget substitutionTarget, IDictionary<string, string> substitutions, bool substitutionValuesByCodeProvided = false)
        {
            // Since this method is not recursive, replacement values are assumed to contain no replacement codes. So start searching from the end of the successful substitution.
            static int NextStartIndexProvider(int substitutionSiteIndex, string substitutionValue)
            {
                var output = substitutionSiteIndex + substitutionValue.Length;
                return output;
            }

            stringSubstitutionScheme.InterpretTarget_Internal(substitutionTarget, substitutions, substitutionValuesByCodeProvided,
                NextStartIndexProvider);
        }

        /// <summary>
        /// Selects <see cref="InterpretTargetRecursively(IStringSubstitutionScheme, ISubstitutionTarget, IDictionary{string, string}, bool)"/> as the default target interpretation method.
        /// </summary>
        public static void InterpretTarget(this IStringSubstitutionScheme stringSubstitutionScheme, ISubstitutionTarget substitutionTarget, IDictionary<string, string> substitutions, bool substitutionValuesByCodeProvided = false)
        {
            stringSubstitutionScheme.InterpretTargetRecursively(substitutionTarget, substitutions, substitutionValuesByCodeProvided);
        }

        public static string InterpretRecursively(this IStringSubstitutionScheme stringSubstitutionScheme, ISubstitutionTarget substitutionTarget, IDictionary<string, string> substitutions, bool substitutionValuesByCodeProvided = false)
        {
            stringSubstitutionScheme.InterpretTargetRecursively(substitutionTarget, substitutions, substitutionValuesByCodeProvided);

            var output = substitutionTarget.ToString();
            return output;
        }

        public static string InterpretNonRecursively(this IStringSubstitutionScheme stringSubstitutionScheme, ISubstitutionTarget substitutionTarget, IDictionary<string, string> substitutions, bool substitutionValuesByCodeProvided = false)
        {
            stringSubstitutionScheme.InterpretTargetNonRecursively(substitutionTarget, substitutions, substitutionValuesByCodeProvided);

            var output = substitutionTarget.ToString();
            return output;
        }

        /// <summary>
        /// Selects <see cref="InterpretRecursively(IStringSubstitutionScheme, ISubstitutionTarget, IDictionary{string, string}, bool)"/> as the default interpretation method.
        /// </summary>
        public static string Interpret(this IStringSubstitutionScheme stringSubstitutionScheme, ISubstitutionTarget substitutionTarget, IDictionary<string, string> substitutions, bool substitutionValuesByCodeProvided = false)
        {
            var output = stringSubstitutionScheme.InterpretRecursively(substitutionTarget, substitutions, substitutionValuesByCodeProvided);
            return output;
        }
    }
}
