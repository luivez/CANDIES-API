using System;

namespace WebApi.Entities
{
    public class OperationProductEntryDto
    {
        public int idOperationEntry {get;set;}
        public string dateOperation {get;set;}
        public int idProduct {set; get;}
        public int quantity {get;set;}
        public float unitValue {get;set;}
        public int? idProvider {set; get;}
    }
}