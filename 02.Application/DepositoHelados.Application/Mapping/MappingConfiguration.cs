using AutoMapper;

namespace DepositoHelados.Application.Mapping;
public static class MappingConfiguration
{
    public static void Configure()
    {
        var configuration = new MapperConfiguration(x => { x.AddMaps(typeof(MappingConfiguration)); });
    }
}
