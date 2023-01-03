namespace KarakasWenAdmin.Models
{
    
        public class Referanslar
        {
            public int Id { get; set; }
            public string? Baslik { get; set; }
            public string? Aciklama { get; set; }
            public string? ResimAdres { get; set; }
            public byte ProjeAktifmi { get; set; }
            public string? CalismaSuresi { get; set; }
            public string? Platform { get; set; }
            public string? Kurum { get; set; }
            public string? LinUrl { get; set; }
            public byte Yayinda { get; set; }
        }

   
}
