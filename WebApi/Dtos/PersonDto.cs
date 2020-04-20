using System.ComponentModel.DataAnnotations;
namespace WebApi.Entities
{
    public class PersonDto
    {
        public int idPerson {get;set;}

        [StringLength (100)]
        public string name {get;set;}

        [StringLength (10)]
        public string telephone {get;set;}

        [StringLength (200)]
        public string address {get;set;}

        [EmailAddress]
        [StringLength (100)]
        public string email {get;set;}
    }
}