using System.ComponentModel.DataAnnotations;
namespace WebApi.Entities
{
    public class Person
    {
        public Person()
        {
            this.state = true;
        }

        public void update(PersonDto dto)
        {
            this.name = dto.name;
            this.telephone = dto.telephone;
            this.address = dto.address;
            this.email = dto.email;
        }

        [Key]
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
        public bool state {get;set;}
    }
}