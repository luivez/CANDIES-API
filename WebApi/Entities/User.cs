using System.ComponentModel.DataAnnotations;
using WebApi.Dtos;

namespace WebApi.Entities
{
    public class User
    {
        public User()
        {
            this.state = true;
        }

        public void update(UserDto dto)
        {
            this.name = name;
            this.lastName = lastName;
            this.userName = userName;
            this.state = true;
        }

        [Key]
        public int idUser { get; set; }

        [StringLength (50)]
        public string name { get; set; }

        [StringLength (50)]
        public string lastName { get; set; }

        [StringLength (15)]
        public string userName { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
        public bool state { get; set; }
    }
}