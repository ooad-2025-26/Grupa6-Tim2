namespace PopravkaBa.Domain.Models
{
    public class EmailNotifikacijaOglas : NotifikacijaOglas
    {
        public string EmailPrimalac { get; set; } = string.Empty;

        public string FormatIntoEmail()
        {
            return $"{Tekst}\n\nDatum: {DatumSlanja:dd.MM.yyyy HH:mm}";
        }
    }
}
