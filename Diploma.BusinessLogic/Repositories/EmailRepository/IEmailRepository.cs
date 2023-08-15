using Diploma.DTO.Email;

namespace Diploma.BusinessLogic.Repositories.EmailRepository
{
    public interface IEmailRepository
    {
        void SendEmail(EmailDto request);
    }
}
