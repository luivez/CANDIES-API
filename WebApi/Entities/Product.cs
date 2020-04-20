using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using WebApi.Helpers;

namespace WebApi.Entities
{
    public class Product
    {
        [JsonIgnore]
        private DataContext _context = null;
        public Product()
        {
            this.state = true;
        }

        public void update(ProductDto dto, DataContext context)
        {
            this._context = context;
            this.name = dto.name;
            this.cost = dto.cost;
            this.price = dto.price;
            this.idProvider = dto.idProvider;
            this.existence = dto.existence;
            this.idProductType = dto.idProductType;
            this.state = true;
            this.provider = _context.Provider.Find(dto.idProvider);
            this.productType = _context.ProductType.Find(dto.idProductType);
        }

        [Key]
        public int idProduct {get;set;}

        [StringLength (50)]
        public string name {get;set;}
        public float cost {get;set;}
        public float price {get;set;}

        [ForeignKey("provider")]
        public int idProvider {set; get;}
        public int existence {get; set;}

        [ForeignKey("productType")]
        public int idProductType {set; get;}
        public bool state {get;set;}

        [JsonIgnore]
        public Provider provider {get;set;}

        [JsonIgnore]
        public ProductType productType {get;set;}
    }
}