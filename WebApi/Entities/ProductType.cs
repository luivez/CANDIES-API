using System.ComponentModel.DataAnnotations;
using WebApi.Helpers;

namespace WebApi.Entities
{
    public class ProductType
    {
        public void update(ProductTypeDto dto, DataContext context)
        {
            this.description = dto.description;
        }

        [Key]
        public int idProductType {get;set;}

        [StringLength (50)]
        public string description {get;set;}
    }
}