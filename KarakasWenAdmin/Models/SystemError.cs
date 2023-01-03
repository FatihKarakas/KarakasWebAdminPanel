namespace KarakasWenAdmin.Models
{
    public class SystemError
    {
        public int Id { get; set; }
        public string ShortMessage { get; set; }
        public string FullMessage { get; set; }
        public string IpAddress { get; set; }
        public string PageUrl { get; set; }
        public string ReferrerUrl { get; set; }
        public DateTime ErrorDate { get; set; }
    }
}
