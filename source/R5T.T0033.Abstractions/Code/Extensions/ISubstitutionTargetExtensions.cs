using System;

using R5T.T0033;


namespace System
{
    public static class ISubstitutionTargetExtensions
    {
        public static int IndexOf(this ISubstitutionTarget substitutionTarget, string value)
        {
            var output = substitutionTarget.IndexOf(value, IndexHelper.DefaultStartIndex);
            return output;
        }
    }
}
