using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    public class UserRegisterDto
    {
        public int idUser { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
    }
}