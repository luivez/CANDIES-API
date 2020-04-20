using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApi.Helpers;

namespace WebApi.Entities
{
    public class UserRole
    {
        [JsonIgnore]
        private DataContext _context;
        public UserRole()
        {
            this.state = true;
        }

        public void update(UserRoleDto dto, DataContext context)
        {
            this._context = context;
            this.idUser = dto.idUser;
            this.idRole = dto.idRole;
            this.state = true;
            this.user = _context.User.Find(dto.idUser);
            this.role = _context.Role.Find(dto.idRole);
        }

        [Key]
        public int idUserRole { get; set; }

        [ForeignKey("user")]
        public int idUser {set; get;}

        [ForeignKey("role")]
        public int idRole {set; get;}

        public bool state { get; set; }

        [JsonIgnore]
        public User user {get; set;}

        [JsonIgnore]
        public Role role {get; set;}
    }
}