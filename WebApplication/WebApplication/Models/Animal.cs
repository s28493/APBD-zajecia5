using System.Diagnostics;

namespace WebApplication.Models;

public class Animal
{
    public int Id { get; set; }
    public string Imie { get; set; }
    public string Kategoria { get; set; }
    public double Masa { get; set; }
    public string KolorSiersci { get; set; }
    
    public Animal(int id, string imie, string kategoria, double masa, string kolorSiersci)
    {
        Id = id;
        Imie = imie;
        Kategoria = kategoria;
        Masa = masa;
        KolorSiersci = kolorSiersci;
    }
}