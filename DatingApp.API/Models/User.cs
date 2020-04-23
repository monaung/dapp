namespace DatingApp.API.Models
{
    public class User
    {
        public int Id { get; set; }
        private string _userName;
        public string UserName
        {
            get { return _userName.ToLower(); }
            set { _userName = value; }
        }
        
        public byte[] PasswordHash { get; set; }
        public byte[]  PasswordSalt{ get; set; }
    }
}