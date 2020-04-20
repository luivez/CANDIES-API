using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using WebApi.Helpers;

namespace WebApi.Entities
{
    public class OperationProductEntry
    {
        [JsonIgnore]
        private DataContext _context;

        public void update(OperationProductEntryDto dto, DataContext context)
        {
            this._context = context;
            this.idProduct = dto.idProduct;
            this.quantity = dto.quantity;
            this.unitValue = dto.unitValue;
            this.idProvider = dto.idProvider;
            this.provider = _context.Provider.Find(dto.idProvider);
            this.product = _context.Product.Find(dto.idProduct);
        }

        [Key]
        public int idOperationEntry {get;set;}
        public DateTime dateOperation {get;set;}
        public DateTime dateOperationEntry {get;set;}

        [ForeignKey("product")]
        public int idProduct {set; get;}

        public int quantity {get;set;}
        public float unitValue {get;set;}

        [ForeignKey("provider")]
        public int? idProvider {set; get;}

        [JsonIgnore]
        public Provider provider {get;set;}

        [JsonIgnore]
        public Product product {get;set;}
    }
}