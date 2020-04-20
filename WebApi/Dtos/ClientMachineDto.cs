using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebApi.Entities
{
    public class ClientMachineDto
    {
        public int idClientMachine {get;set;}
        public int idClient {get;set;}
        public int idMachine {get;set;}
        public string dateAssignment {get;set;}
    }
}