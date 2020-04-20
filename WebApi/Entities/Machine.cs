using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using WebApi.Helpers;

namespace WebApi.Entities
{
    public class Machine
    {
        [JsonIgnore]
        private DataContext _context;

        public void update(MachineDto dto, DataContext context)
        {
            this._context = context;
            this.idStatusMachine = dto.idStatusMachine;
            this.capacity = dto.capacity;
            this.statusMachine = _context.StatusMachine.Find(dto.idStatusMachine);
        }

        [Key]
        public int idMachine {get;set;}

        [ForeignKey("statusMachine")]
        public int idStatusMachine {get;set;}
        public int capacity {get;set;}

        [JsonIgnore]
        public StatusMachine statusMachine {get;set;}
    }
}