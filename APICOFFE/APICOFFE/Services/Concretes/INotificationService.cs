namespace APICOFFE.Services.Concretes;

public interface INotificationService
{
    Task SenOrderCreatedToAdmin(string trackingCode);
}
