using Application.Extensions;
using Application.Services.Abstract;
using Domain.Entities;
using System.Data;
using System.Text.Json;

namespace Application.Services.Concrete;
public sealed class BusService(ISoapService soapService,ICacheService cache) : IBusService
{
    public async Task<IEnumerable<KaraNokta>> ListKaraNoktaAsync()
    {
        DataSet dataSet = await soapService
            .StringtoDataset("<KaraNoktaGetirKomut/>")
            .ConfigureAwait(false);

        var cacheResposne = await cache.GetAsync<IEnumerable<KaraNokta>>("karanoktalar");
        if (cacheResposne is IEnumerable<KaraNokta>)
            return cacheResposne;
        
        IEnumerable<KaraNokta> merkezKaraNoktas = dataSet.BindKaraNokta(true);
        await cache.GetOrSetAsync<IEnumerable<KaraNokta>>("karanoktalar", JsonSerializer.Serialize(merkezKaraNoktas));

        return merkezKaraNoktas;
    }
}
