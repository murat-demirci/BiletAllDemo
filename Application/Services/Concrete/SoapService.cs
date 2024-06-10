using Application.Services.Abstract;
using Domain.Entities;
using Microsoft.Extensions.Options;
using System.Data;
using System.Xml;

namespace Application.Services.Concrete;
public sealed class SoapService(IOptions<Credentials> options) : ISoapService
{
    public async Task<DataSet> StringtoDataset(string xmlstring)
    {
        BiletAllServices.ServiceSoapClient sr = new(default);//BiletAll WS

        var response = await sr.XmlIsletAsync(
                    StrtoXmldocument(xmlstring).DocumentElement,
                    StrtoXmldocument("<Kullanici><Adi>" + options.Value.UserName + "</Adi><Sifre>" + options.Value.Password + "</Sifre></Kullanici>").DocumentElement);

        XmlNodeReader nr =
            new XmlNodeReader(response.Body.XmlIsletResult);
        DataSet ds = new DataSet();

        try
        {
            ds.ReadXml(nr);
        }
        catch
        { }



        return ds;
    }

    private XmlDocument StrtoXmldocument(string str)
    {
        XmlDocument xd = new();
        try
        {
            string str1 = str;
            xd.LoadXml(str1);
        }
        catch
        {

        }

        return xd;
    }
}
