using CodeMazeMapsterExample.Entities;
using Mapster;

namespace CodeMazeMapsterExample.Config;

public class CodeGenerationConfig : ICodeGenerationRegister
{
    public void Register(Mapster.CodeGenerationConfig config)
    {
        config.AdaptTo("[name]Model")
            .ForType<Person>()
            .ForType<Address>();

        config.GenerateMapper("[name]Mapper")
            .ForType<Person>()
            .ForType<Address>();
    }
}
