using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApi.Helpers;

namespace WebApi.Entities{
    public class Role {
        public Role()
        {
            this.state = true;
        }

        public void update(RoleDto dto, DataContext context)
        {
            this.description = dto.description;
            this.state = true;
        }

        [Key]
        public int idRole { get; set; }

        [StringLength (50)]
        public string description { get; set; }
        public bool state { get; set; }
    }
}