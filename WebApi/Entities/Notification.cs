using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using WebApi.Helpers;

namespace WebApi.Entities
{
    public class Notification
    {
        [JsonIgnore]
        private DataContext _contex;

        public Notification()
        {
            this.date = DateTime.Now;
        }

        public void update(NotificationDto dto, DataContext contex)
        {
            _contex = contex;
            this.idClient = dto.idClient;
            this.idUser = dto.idUser;
            this.idStatusMachine = dto.idStatusMachine;
            this.totalSales = dto.totalSales;
            this.client = _contex.Client.Find(dto.idClient);
            this.user = _contex.User.Find(dto.idUser);
            this.statusMachine = _contex.StatusMachine.Find(dto.idStatusMachine);
        }

        [Key]
        public int idNotification {get;set;}

        [ForeignKey("client")]
        public int idClient {get;set;}

        [ForeignKey("user")]
        public int idUser {get;set;}
        public DateTime date {get;set;}

        [ForeignKey("statusMachine")]
        public int idStatusMachine {get;set;}
        public float totalSales {get;set;}

        [JsonIgnore]
        public Client client {get;set;}

        [JsonIgnore]
        public User user {get;set;}

        [JsonIgnore]
        public StatusMachine statusMachine {get;set;}

    }
}