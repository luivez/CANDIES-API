using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebApi.Entities
{
    public class OperationProductOutputDto
    {
        public int idOperationOutput {get;set;}
        public int idProducto {set; get;}
        public int quantity {get;set;}
        public float unitValue {get;set;}
        public int idClient {set; get;}
        public int idNotification {set; get;}
    }
}