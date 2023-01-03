namespace KarakasWenAdmin.Models.Entitys
{
    public class Comment
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string EmailAddress { get; set; } = string.Empty;
        public string Content { get; set; } = "";
        public bool IsAccept { get; set; }
        public DateTime CreateDate { get; set; }
        public int PostId { get; set; }
        public int ParentId { get; set; }
        public string IpAdres { get; set; } = "";

        public virtual Post? Post { get; set; }
    }
}
