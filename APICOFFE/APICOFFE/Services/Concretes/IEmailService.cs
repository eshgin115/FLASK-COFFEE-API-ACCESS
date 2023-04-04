using APICOFFE.Contracts.Email;

namespace APICOFFE.Services.Concretes;

public interface IEmailService
{
    public void Send(MessageDto messageDto);
}