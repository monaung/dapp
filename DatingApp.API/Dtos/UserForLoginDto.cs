using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForLoginDto
    {
        [Required]
        private string _userName;
        public string UserName
        {
            get { return _userName.ToLower(); }
            set { _userName = value; }
        }
        
        public string Password { get; set; }
    }
}