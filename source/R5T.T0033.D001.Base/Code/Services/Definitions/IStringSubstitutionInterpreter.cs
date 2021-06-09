using System;
using System.Threading.Tasks;


namespace R5T.T0033.D001
{
    public interface IStringSubstitutionInterpreter
    {
        Task<string> Interpret(string substitutionTarget,
            bool recursive);
    }
}
