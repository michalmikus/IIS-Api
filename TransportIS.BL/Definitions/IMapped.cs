using AutoMapper;

namespace TransportIS.BL.Definitions
{
    public interface IMapped
    {
        void CreateMap(IMapperConfigurationExpression cfg);
    }
}