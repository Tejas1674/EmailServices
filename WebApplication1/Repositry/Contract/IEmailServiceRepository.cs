using WebApplication1.Model.Dto;

namespace WebApplication1.Repositry.Contract
{
    public interface IEmailServiceRepository
    {
        void SendEmail(EmailservicesDto request);
    }
}
