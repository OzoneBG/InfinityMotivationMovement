namespace IMM.Web.ViewModels.HomeViewModels
{
    using AutoMapper;
    using IMM.Models;
    using IMM.Web.Common.Mapping.Interfaces;
    using System;

    public class IndexViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public DateTime CreatedOn { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile.
                CreateMap<User, IndexViewModel>()
                .ForMember(vm => vm.FullName, opt => opt.MapFrom(u => u.UserName + "" + u.Email));
        }
    }
}
