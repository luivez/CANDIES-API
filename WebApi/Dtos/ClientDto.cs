using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using WebApi.Helpers;

namespace WebApi.Entities
{
    public class ClientDto
    {
        public int idClient {get;set;}
        [StringLength (50)]
        public string name {get;set;}
        [StringLength (200)]
        public string address {get;set;}
        [StringLength (200)]
        public string coordinate {get; set;}
        [StringLength (10)]
        public string nit {get; set;}
        public bool wholesaler {get;set;}
        [StringLength (100)]
        [EmailAddress]
        public string email {get; set;}
        public int idPerson {get;set;}
        [Url]
        [StringLength (500)]
        public string urlPage {get;set;}
    }
}