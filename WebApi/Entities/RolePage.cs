using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApi.Helpers;

namespace WebApi.Entities
{
    public class RolePage
    {
        [JsonIgnore]
        private DataContext _context;
        public RolePage()
        {
            this.state = true;
        }

        public void update(RolePageDto dto, DataContext context)
        {
            this._context = context;
            this.idRole = dto.idRole;
            this.idPage = dto.idPage;
            this.state = true;
            this.role = _context.Role.Find(dto.idRole);
            this.page = _context.Page.Find(dto.idPage);
        }

        [Key]
        public int idRolePage { get; set; }

        [ForeignKey("role")]
        public int idRole {set; get;}

        [ForeignKey("page")]
        public int idPage {set; get;}

        public bool state { get; set; }

        [JsonIgnore]
        public Role role {get; set;}

        [JsonIgnore]
        public Page page {get; set;}
    }
}