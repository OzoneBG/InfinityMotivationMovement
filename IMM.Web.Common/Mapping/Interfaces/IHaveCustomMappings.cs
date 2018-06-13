namespace IMM.Web.Common.Mapping.Interfaces
{
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void ConfigureMapping(Profile profile);
    }
}
