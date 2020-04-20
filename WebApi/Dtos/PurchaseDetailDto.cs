using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebApi.Entities
{
    public class PurchaseDetailDto
    {
        public int idPurchaseDetail {get;set;}
        public int idProduct {get;set;}
        public int idPurchaseOrder {get;set;}
    }
}