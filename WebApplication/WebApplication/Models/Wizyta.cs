namespace WebApplication.Models;

public class Wizyta
{
    public  string DataWizyty { get; set; }
    public int AnimalId { get; set; }
    public string OpisWizyty { get; set; }
    public double CenaWizyty { get; set; }

    public Wizyta(string dataWizyty, int animalId, string opisWizyty, double cenaWizyty)
    {
        DataWizyty = dataWizyty;
        AnimalId = animalId;
        OpisWizyty = opisWizyty;
        CenaWizyty = cenaWizyty;
    }
}