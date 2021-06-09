using System;

using R5T.Magyar;


namespace R5T.T0033
{
    /// <summary>
    /// Allows any scheme to be used in a string-substitution process as long as it:
    /// 1) Can find the next substitution site.
    /// 2) Can generate a substitution code from a substitution token.
    /// </summary>
    public interface IStringSubstitutionScheme
    {
        /// <summary>
        /// Creates a substitution code from a substitution token for use in matching the substitution codes provided by <see cref="FindNextSubstitutionSite(ISubstitutionTarget, int)"/> to replacement values via a replacement token.
        /// </summary>
        string CreateSubstitutionCode(string substitutionToken);

        /// <summary>
        /// Finds the next substitution code in the substitution target, and returns the code and its location.
        /// Find next allows 
        /// </summary>
        WasFound<SubstitutionSite> FindNextSubstitutionSite(ISubstitutionTarget substitutionTarget, int startIndex);
    }
}
