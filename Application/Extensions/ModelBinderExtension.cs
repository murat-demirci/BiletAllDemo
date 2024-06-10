using Domain.Entities;
using System.Data;

namespace Application.Extensions;
public static class ModelBinderExtension
{
    public static IEnumerable<KaraNokta> BindKaraNokta(this DataSet dataSet,bool isMerkez = false)
    {
        List<KaraNokta> karaNoktaList = new();
        if (dataSet.Tables.Contains("KaraNokta"))
        {
            DataTable dt = dataSet.Tables["KaraNokta"];

            foreach (DataRow row in dt.Rows)
            {
                KaraNokta karaNokta = new KaraNokta
                {
                    ID = Convert.ToInt32(row["ID"]),
                    SeyahatSehirID = Convert.ToInt32(row["SeyahatSehirID"]),
                    Bolge = row["Bolge"].ToString(),
                    UlkeKodu = row["UlkeKodu"].ToString(),
                    Ad = row["Ad"].ToString(),
                    Aciklama = row["Aciklama"].ToString(),
                    MerkezMi = Convert.ToInt32(row["MerkezMi"]) == 1 ? true : false,
                    BagliOlduguNoktaID = Convert.ToInt32(row["BagliOlduguNoktaID"])
                };

                karaNoktaList.Add(karaNokta);
            }
        }
        return karaNoktaList?.AsQueryable().Where(x => x.UlkeKodu == "TR" && x.MerkezMi == isMerkez).AsEnumerable();
    }
}
