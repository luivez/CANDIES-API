using System.ComponentModel.DataAnnotations;
using WebApi.Helpers;

namespace WebApi.Entities
{
    public class Provider
    {
        public Provider()
        {
            this.state = true;
        }

        public void update(ProviderDto dto, DataContext context)
        {
            this.nameProvider = dto.nameProvider;
            this.reason = dto.reason;
            this.nit = dto.nit;
            this.address = dto.address;
            this.email = dto.email;
            this.typeProvider = dto.typeProvider;
            this.state = true;
        }

        [Key]
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
        public bool state {get; set;}
    }
}