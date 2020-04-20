using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebApi.Entities
{
    public class NotificationDto
    {
        public int idNotification {get;set;}
        public int idClient {get;set;}
        public int idUser {get;set;}
        public int idStatusMachine {get;set;}
        public float totalSales {get;set;}
    }
}