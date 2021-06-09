using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace R5T.T0033.D002
{
    public interface IStringSubstitutionInterpreter
    {
        Task<string> Interpret(string substitutionTarget, IStringSubstitutionScheme stringSubstitutionScheme, IDictionary<string, string> substitutions,
            bool substitutionValuesByCodeProvided,
            bool recursive);
    }
}
