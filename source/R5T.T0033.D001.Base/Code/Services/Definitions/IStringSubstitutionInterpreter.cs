using System;
using System.Threading.Tasks;using R5T.T0064;


namespace R5T.T0033.D001
{[ServiceDefinitionMarker]
    public interface IStringSubstitutionInterpreter:IServiceDefinition
    {
        Task<string> Interpret(string substitutionTarget,
            bool recursive);
    }
}
