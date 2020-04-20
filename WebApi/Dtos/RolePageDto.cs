using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class RolePageDto
    {
        public int idRolePage { get; set; }
        public int idRole {set; get;}
        public int idPage {set; get;}
    }
}