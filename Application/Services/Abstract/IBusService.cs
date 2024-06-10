using Domain.Entities;

namespace Application.Services.Abstract;
public interface IBusService
{
    Task<IEnumerable<KaraNokta>> ListKaraNoktaAsync();
}
