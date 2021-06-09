using System;


namespace R5T.T0033
{
    /// <summary>
    /// Allows any efficient data structure to be a substitution target, not just <see cref="String"/> or <see cref="System.Text.StringBuilder"/>.
    /// </summary>
    public interface ISubstitutionTarget
    {
        int IndexOf(string value, int startIndex);
        void Replace(string oldValue, string newValue, int index);
        string Substring(int startIndex, int length);
    }
}
