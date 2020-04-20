using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Newtonsoft.Json;
using WebApi.Helpers;

namespace WebApi.Entities
{
    public class ClientMachine
    {
        [JsonIgnore]
        private DataContext _context;
        public ClientMachine()
        {
            this.state = true;
        }

        public void update(ClientMachineDto dto, DataContext context)
        {
            _context = context;
            this.idClient = dto.idClient;
            this.idMachine = dto.idMachine;
            this.dateAssignment = DateTime.ParseExact(dto.dateAssignment, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this.client = _context.Client.Find(dto.idClient);
            this.machine = _context.Machine.Find(dto.idMachine);
        }

        [Key]
        public int idClientMachine {get;set;}

        [ForeignKey("client")]
        public int idClient {get;set;}

        [ForeignKey("machine")]
        public int idMachine {get;set;}
        public DateTime dateAssignment {get;set;}
        public bool state {get;set;}

        [JsonIgnore]
        public Client client {get;set;}

        [JsonIgnore]
        public Machine machine {get;set;}
    }
}