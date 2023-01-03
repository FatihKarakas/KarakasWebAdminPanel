namespace KarakasWenAdmin.Models
{
    public class Setting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int Type { get; set; }
        public int InputType { get; set; }
        public string Description { get; set; }
        public string SelectedValue { get; set; }
    }
}
