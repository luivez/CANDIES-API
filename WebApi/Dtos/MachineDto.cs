using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebApi.Entities
{
    public class MachineDto
    {
        public int idMachine {get;set;}
        public int idStatusMachine {get;set;}
        public int capacity {get;set;}
    }
}