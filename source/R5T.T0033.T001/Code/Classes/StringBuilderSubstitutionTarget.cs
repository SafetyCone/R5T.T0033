using System;
using System.Text;


namespace R5T.T0033.T001
{
    public class StringBuilderSubstitutionTarget : ISubstitutionTarget
    {
        private StringBuilder StringBuilder { get; }


        public StringBuilderSubstitutionTarget(string substitutionTargetString)
        {
            this.StringBuilder = new StringBuilder(substitutionTargetString);
        }

        public int IndexOf(string value, int startIndex)
        {
            // No way to search a StringBuilder other than conversion to a string. See: https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=net-5.0#Searching
            var output = this.StringBuilder.ToString().IndexOf(value, startIndex);
            return output;
        }

        public void Replace(string oldValue, string newValue, int index)
        {
            // TODO, there might be a more efficient method to do this.
            this.StringBuilder.Replace(oldValue, newValue, index, oldValue.Length);
        }

        public string Substring(int startIndex, int length)
        {
            var output = this.StringBuilder.ToString(startIndex, length);
            return output;
        }

        public override string ToString()
        {
            return this.StringBuilder.ToString();
        }
    }
}
