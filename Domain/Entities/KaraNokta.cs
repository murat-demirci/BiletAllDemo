namespace Domain.Entities;
public sealed class KaraNokta
{
    public int ID { get; set; }
    public int SeyahatSehirID { get; set; }
    public string Bolge { get; set; }
    public string UlkeKodu { get; set; }
    public string Ad { get; set; }
    public string Aciklama { get; set; }
    public bool MerkezMi { get; set; }
    public int BagliOlduguNoktaID { get; set; }
}
