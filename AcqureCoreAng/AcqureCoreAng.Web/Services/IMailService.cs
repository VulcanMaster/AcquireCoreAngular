namespace AcqureCoreAng.Web.Services
{
    public interface IMailService
    {
        void SendMessage(string to, string from, string body);
    }
}