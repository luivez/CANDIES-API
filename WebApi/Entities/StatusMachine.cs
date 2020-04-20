using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class StatusMachine
    {
        public void update(StatusMachineDto dto)
        {
            this.description = dto.description;
        }

        [Key]
        public int idStatusMachine {get;set;}

        [StringLength (50)]
        public string description {get;set;}
    }
}