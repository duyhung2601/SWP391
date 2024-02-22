using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Models.ViewModels
{
    public class ProductHomeViewModel
    {

        public IEnumerable<SliderViewModel> Sliders { get; set; } = Enumerable.Empty<SliderViewModel>();
        public IEnumerable<ProductViewModel> Products { get; set; } = Enumerable.Empty<ProductViewModel>();
    }

    public class ProductViewModel
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public string? Name { get; set; }
        public string? Company { get; set; }
        public double ListPrice { get; set; } = 0;
        public double Price100 { get; set; } = 0;
    }
    public class SliderViewModel
    {
        public string? ImageUrl { get; set; }
    }
}
