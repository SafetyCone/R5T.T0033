using System;

using R5T.Magyar;


namespace R5T.T0033.T002
{
    public class PercentStringSubstitutionScheme : IStringSubstitutionScheme
    {
        public const string SubstitutionCodeDelimiter = Strings.Percent;


        public string CreateSubstitutionCode(string substitutionToken)
        {
            var substitutionCode = $"{PercentStringSubstitutionScheme.SubstitutionCodeDelimiter}{substitutionToken}{PercentStringSubstitutionScheme.SubstitutionCodeDelimiter}";
            return substitutionCode;
        }

        public WasFound<SubstitutionSite> FindNextSubstitutionSite(ISubstitutionTarget substitutionTarget, int startIndex)
        {
            var indexOfNextStartingDelimiter = substitutionTarget.IndexOf(PercentStringSubstitutionScheme.SubstitutionCodeDelimiter, startIndex);
            if (StringHelper.IsFound(indexOfNextStartingDelimiter))
            {
                var indexOfEndingDelimiter = substitutionTarget.IndexOf(PercentStringSubstitutionScheme.SubstitutionCodeDelimiter, indexOfNextStartingDelimiter + 1);
                if (StringHelper.IsFound(indexOfEndingDelimiter))
                {
                    var substitutionCode = substitutionTarget.Substring(indexOfNextStartingDelimiter, indexOfEndingDelimiter - indexOfNextStartingDelimiter + 1);

                    var substitutionSite = new SubstitutionSite
                    {
                        Index = indexOfNextStartingDelimiter,
                        SubstitutionCode = substitutionCode,
                    };

                    return WasFound.Found(substitutionSite);
                }
                else
                {
                    throw new ArgumentException($"The substitution target did not have a matching ending substitution code delimiter.\nDelimiter: {PercentStringSubstitutionScheme.SubstitutionCodeDelimiter}\nAfter index: {indexOfNextStartingDelimiter}");
                }
            }
            else
            {
                return WasFound.NotFound<SubstitutionSite>();
            }
        }
    }
}
