namespace PopravkaBa.Domain.Interfaces
{
    public interface IEmailSender
    {
        Task PosaljiEmailAsync(string primalac, string subjekt, string tijelo);
    }
}
