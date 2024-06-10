using System.Data;

namespace Application.Services.Abstract;
public interface ISoapService
{
    Task<DataSet> StringtoDataset(string xmlstring);
}
