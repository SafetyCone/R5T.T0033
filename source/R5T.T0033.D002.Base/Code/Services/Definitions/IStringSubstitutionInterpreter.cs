using System;
using System.Collections.Generic;
using System.Threading.Tasks;using R5T.T0064;


namespace R5T.T0033.D002
{[ServiceDefinitionMarker]
    public interface IStringSubstitutionInterpreter:IServiceDefinition
    {
        Task<string> Interpret(string substitutionTarget, IStringSubstitutionScheme stringSubstitutionScheme, IDictionary<string, string> substitutions,
            bool substitutionValuesByCodeProvided,
            bool recursive);
    }
}
