using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using WebApi.Helpers;

namespace WebApi.Entities
{
    public class PurchaseDetail
    {
        [JsonIgnore]
        private DataContext _context;

        public void update(PurchaseDetailDto dto, DataContext context)
        {
            _context = context;
            this.idProduct = dto.idProduct;
            this.idPurchaseOrder = dto.idPurchaseOrder;
            this.product = _context.Product.Find(dto.idProduct);
            this.purchaseOrderFK = _context.PurchaseOrder.Find(dto.idPurchaseOrder);
        }

        [Key]
        public int idPurchaseDetail {get;set;}

        [ForeignKey("product")]
        public int idProduct {get;set;}

        [ForeignKey("purchaseOrder")]
        public int? idPurchaseOrder {get;set;}

        [JsonIgnore]
        public Product product {get;set;}

        [JsonIgnore]
        public PurchaseOrder purchaseOrderFK {get;set;}
    }
}