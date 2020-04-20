using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities{
    public class RoleDto {

        public int idRole { get; set; }

        [StringLength (50)]
        public string description { get; set; }
    }
}