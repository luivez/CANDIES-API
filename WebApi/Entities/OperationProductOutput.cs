using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using WebApi.Helpers;

namespace WebApi.Entities
{
    public class OperationProductOutput
    {
        [JsonIgnore]
        private DataContext _context;
        public OperationProductOutput()
        {
            this.dateOperation = DateTime.Now;
        }

        public void update(OperationProductOutputDto dto, DataContext context)
        {
            _context = context;
            this.idProducto = dto.idProducto;
            this.quantity = dto.quantity;
            this.unitValue = dto.unitValue;
            this.idClient = dto.idClient;
            this.idNotification = dto.idNotification;
            this.product = _context.Product.Find(dto.idProducto);
            this.client = _context.Client.Find(dto.idClient);
            this.notification = _context.Notification.Find(dto.idNotification);
        }

        [Key]
        public int idOperationOutput {get;set;}
        public DateTime dateOperation {get;set;}

        [ForeignKey("product")]
        public int idProducto {set; get;}

        public int quantity {get;set;}
        public float unitValue {get;set;}

        [ForeignKey("client")]
        public int idClient {set; get;}

        [ForeignKey("notification")]
        public int? idNotification {set; get;}

        [JsonIgnore]
        public Product product {get;set;}

        [JsonIgnore]
        public Client client {get;set;}

        [JsonIgnore]
        public Notification notification {get;set;}

    }
}