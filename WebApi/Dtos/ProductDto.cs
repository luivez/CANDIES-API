using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebApi.Entities
{
    public class ProductDto
    {
        public int idProduct {get;set;}
        [StringLength (50)]
        public string name {get;set;}
        public float cost {get;set;}
        public float price {get;set;}
        public int idProvider {set; get;}
        public int existence {get; set;}
        public int idProductType {set; get;}
    }
}