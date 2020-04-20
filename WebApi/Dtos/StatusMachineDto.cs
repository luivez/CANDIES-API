using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class StatusMachineDto
    {
        public int idStatusMachine {get;set;}
        [StringLength (50)]
        public string description {get;set;}
    }
}