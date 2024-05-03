using System.Data.SqlClient;
using WebApplication.Models;

namespace WebApplication.Repositories;

public class AnimalRepository : IAnimalRepository
{   private readonly string connectionString = "Server=db-mssql;DataBase=2019SBD;Integrated Security=True;TrustServerCertificate=True;";
    public IEnumerable<Animal> GetAnimals()
    {
        using var con = new SqlConnection(connectionString);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY Name";
        
        var dr = cmd.ExecuteReader();
        var students = new List<Animal>();
        while (dr.Read())
        {
            var grade = new Animal
            {
                IdAnimal = (int)dr["IdAnimal"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Category = dr["Category"].ToString(),
                Area = dr["Area"].ToString(),
            };
            students.Add(grade);
        }
        
        return students;
    }

    public int CreateAnimal(Animal animal)
    {
        using var con = new SqlConnection(connectionString);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText =
            "INSERT INTO Animal(IdAnimal, Name, Description, Category, Area) VALUES (@IdAnimal, @Name, @Description, @Category, @Area)";
        cmd.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public Animal GetAnimal(int idAnimal)
    {
        using var con = new SqlConnection(connectionString);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdStudent", idAnimal);
        
        var dr = cmd.ExecuteReader();
        
        if (!dr.Read()) return null;
        
        var animal = new Animal
        {
            IdAnimal = (int)dr["IdAnimal"],
            Name = dr["Name"].ToString(),
            Description = dr["Description"].ToString(),
            Category = dr["Category"].ToString(),
            Area = dr["Area"].ToString(),
        };
        
        return animal;
    }

    public int UpdateAnimal(Animal animal)
    {
        using var con = new SqlConnection(connectionString);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText =
            "UPDATE Animal SET " +
            "Name = @Name, " +
            "Description = @Description, " +
            "Category = @Category, " +
            "Area = @Area " +
            "WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int DeleteAnimal(int idAnimal)
    {
        using var con = new SqlConnection(connectionString);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM Animal WHERE IdAniaml = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
}