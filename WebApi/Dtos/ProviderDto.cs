using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class ProviderDto
    {
        public int idProvider {get; set;}
        [StringLength (100)]
        public string nameProvider {get; set;}
        [StringLength (200)]
        public string reason {get;set;}
        [StringLength (10)]
        public string nit {get;set;}
        [StringLength (200)]
        public string address {get; set;}
        [EmailAddress]
        [StringLength (100)]
        public string email {get; set;}
        public int typeProvider {get; set;}
    }
}