namespace KarakasWenAdmin.Models.Entitys
{
    public class UserControl
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public string  FullName { get; set; }
        public string emailAddresss { get; set; }
        public bool IsActive { get; set; }
       
    }
}
