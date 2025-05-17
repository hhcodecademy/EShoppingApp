namespace EShoppingApp.EmailOperations.Interfaces
{
    public interface IEmailSenderOpt
    {
        Task SendEmailAsync(string email, string subject, string message);

    }
}
