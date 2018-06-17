namespace IMM.Web.ViewModels.ShopViewModels
{
    using AutoMapper;
    using IMM.Data.Models;
    using IMM.Web.Common.Mapping.Interfaces;

    public class ShopIndexViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile
                .CreateMap<Product, ShopIndexViewModel>()
                .ForMember(vm => vm.CategoryName, cfg => cfg.MapFrom(p => p.Category.Name));
        }
    }
}
