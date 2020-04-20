using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using WebApi.Helpers;

namespace WebApi.Entities
{
    public class PurchaseOrder
    {
        [JsonIgnore]
        private DataContext _context;
        public void update(PurchaseOrderDto dto, DataContext context)
        {
            this._context = context;
            this.orderTitle = dto.orderTitle;
            this.purchaseOrderAmount = dto.purchaseOrderAmount;
            this.statusOrder = dto.statusOrder;
            this.idProvider = dto.idProvider;
            this.provider = _context.Provider.Find(dto.idProvider);
        }

        [Key]
        public int idPurchaseOrder {get;set;}

        [StringLength (50)]
        public string orderTitle {get;set;}
        public DateTime datePurchaseOrder {get;set;}
        public float purchaseOrderAmount {get;set;}
        public bool statusOrder {get;set;}

        [ForeignKey("provider")]
        public int idProvider {set; get;}

        [JsonIgnore]
        public Provider provider {get;set;}

    }
}