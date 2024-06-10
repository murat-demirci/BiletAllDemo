using Application.Extensions;
using Application.Services.Abstract;
using Domain.Entities;
using System.Data;

namespace Application.Services.Concrete;
public sealed class BusService(ISoapService soapService) : IBusService
{
    public async Task<IEnumerable<KaraNokta>> ListKaraNoktaAsync()
    {
        DataSet dataSet = await soapService
            .StringtoDataset("<KaraNoktaGetirKomut/>")
            .ConfigureAwait(false);

        IEnumerable<KaraNokta> merkezKaraNoktas = dataSet.BindKaraNokta(true);

        return merkezKaraNoktas;
    }
}
