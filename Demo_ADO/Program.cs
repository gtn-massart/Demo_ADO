
using Demo_ADO.Interfaces;
using Demo_ADO.Models;
using Demo_ADO.Repositories;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

string connectionString = @"server=(localdb)\MSSQLLocalDB;database=PokemonDB;integrated security=true";

#region GetAll

//List<Pokemon> pokemons = new List<Pokemon>();

//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    SqlCommand cmd = connection.CreateCommand();

//    cmd.CommandText = "SELECT * FROM Pokemon";

//    connection.Open();

//    SqlDataReader reader = cmd.ExecuteReader();


//    while (reader.Read())
//    {
//        int id = (int)reader["ID"];
//        string name = (string)reader["Name"];
//        int weight = (int)reader["Weight"];
//        int heigth = (int)reader["Height"];
//        string? desctription = reader["Description"] == DBNull.Value ? null : (string)reader["Description"];
//        int type1Id = (int)reader["Type1Id"];
//        int? type2Id = reader["Type2Id"] == DBNull.Value ? null : (int)reader["Type2Id"];

//        Pokemon p = new Pokemon()
//        {
//            Id = id,
//            Name = name,
//            Weight = weight,
//            Height = heigth,
//            Description = desctription,
//            Type1Id = type1Id,
//            Type2Id = type2Id
//        };

//        pokemons.Add(p);
//    }
//}
//pokemons.ForEach(p => Console.WriteLine(p));

#endregion

#region GetOne

//Pokemon p = new Pokemon();
//int idReceived = 1;

//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    SqlCommand cmd = connection.CreateCommand();

//    cmd.CommandText = "SELECT * FROM Pokemon where Id = @id";

//    cmd.Parameters.AddWithValue("@id", idReceived); // → partamètre SQL

//    connection.Open();

//    SqlDataReader reader = cmd.ExecuteReader();


//    if (reader.Read())
//    {
//        int id = (int)reader["ID"];
//        string name = (string)reader["Name"];
//        int weight = (int)reader["Weight"];
//        int heigth = (int)reader["Height"];
//        string? desctription = reader["Description"] == DBNull.Value ? null : (string)reader["Description"];
//        int type1Id = (int)reader["Type1Id"];
//        int? type2Id = reader["Type2Id"] == DBNull.Value ? null : (int)reader["Type2Id"];

//        p = new Pokemon()
//        {
//            Id = id,
//            Name = name,
//            Weight = weight,
//            Height = heigth,
//            Description = desctription,
//            Type1Id = type1Id,
//            Type2Id = type2Id
//        };
//    }
//}

//Console.WriteLine(p);

#endregion

#region GetCount 

//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    SqlCommand cmd = connection.CreateCommand();

//    cmd.CommandText = "SELECT COUNT(*) FROM pokemon";

//    connection.Open();

//    int count = (int)cmd.ExecuteScalar();

//    Console.WriteLine($"{count} Pokemon(s) dans la DB");

//}

#endregion

#region Create

//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    SqlCommand cmd = connection.CreateCommand();

//    cmd.CommandText = $"INSERT INTO pokemon " +
//                      $"VALUES (@name, @height, @weight, @description, @type1Id, @type2Id)";

//    cmd.Parameters.AddWithValue("@name", "Arcanin");
//    cmd.Parameters.AddWithValue("@height", 50);
//    cmd.Parameters.AddWithValue("@weight", 100);
//    cmd.Parameters.AddWithValue("@description", "Belle bête");
//    cmd.Parameters.AddWithValue("@type1Id", 2);
//    cmd.Parameters.AddWithValue("@type2Id", DBNull.Value);

//    connection.Open();

//    int nbRows = cmd.ExecuteNonQuery();
//    Console.WriteLine($"{nbRows} row(s) affected");
//}

#endregion

#region Test Repo

//IPokemonRepository pokemonRepository = new PokemonRepository(connectionString);

//List<Pokemon> pokemons = pokemonRepository.GetAll().ToList();

//int count = pokemonRepository.Count();
//Console.WriteLine($"Count: {count}");

//pokemons.ForEach(p => Console.WriteLine(p));

//Console.WriteLine("------------------------------------------------------------");

//Pokemon? pokemon = pokemonRepository.GetById(2);

//if (pokemon is not null)
//{
//    Console.WriteLine($"Name: {pokemon.Name}\nType1: {pokemon.Type1?.Name}\nType2: {pokemon.Type2?.Name}");
//}

//Console.WriteLine("------------------------------------------------------------");

//Pokemon newPokemon = new Pokemon()
//{
//    Name = "Leviator",
//    Height = 50,
//    Weight = 100,
//    Description = "The GOAT",
//    Type1Id = 4,
//    Type2Id = 7
//};

//int newId = pokemonRepository.Create(newPokemon);

//Console.WriteLine($"Pokémon insérer avec Id {newId}");

//Console.WriteLine("------------------------------------------------------------");

//Pokemon updatePokemon = new Pokemon()
//{
//    Name = "Magikarp",
//    Height = 10,
//    Weight = 2,
//    Description = "The GOAT",
//    Type1Id = 4,
//    Type2Id = 7
//};

//if(pokemonRepository.Update(newId, updatePokemon))
//{
//    Console.WriteLine("OK");
//}
//else
//{
//    Console.WriteLine("KO");
//}

//Console.WriteLine("------------------------------------------------------------");

//if (pokemonRepository.Delete(newId))
//{
//    Console.WriteLine("OK");
//}

#endregion

#region EXO_Book
IBookRepository bookRepository = new BookRepository(connectionString);

//List<Book> books = bookRepository.GetAll().ToList();

//Console.WriteLine("------------------------------------------------");

Book? book = bookRepository.GetById(2);

if (book is not null)
{
    Console.WriteLine($"Titre: {book.Title}\nDescription: {book.Description}\nAuthor: {book.AuthorId}");
}
#endregion

#region EXO
//Console.WriteLine("*********************************");
//Console.WriteLine("*** Bienvenue à Pokémon World ***");
//Console.WriteLine("*********************************\n");
//Console.WriteLine("1 → Lister les Pokémons\n2 → Ajouter un Pokémon\n3 → Effacer un pokémon\n");

//Console.Write("Faites votre choix : ");
//string? answer = Console.ReadLine();

//if (answer != null)
//{
//	switch (answer)
//	{
//		case "1":
//            GetAllPokemons();
//			break;
//        case "2":
//            AddPokemon();
//            break;
//        case "3":
//            break;
//        default:
//			break;
//	}
//}



//void GetAllPokemons()
//{
//    List<Pokemon> pokemons = new List<Pokemon>();
//    using (SqlConnection connection = new SqlConnection(connectionString))
//    {
//        SqlCommand cmd = connection.CreateCommand();

//        cmd.CommandText = "SELECT * FROM Pokemon";

//        connection.Open();

//        SqlDataReader reader = cmd.ExecuteReader();


//        while (reader.Read())
//        {
//            int id = (int)reader["ID"];
//            string name = (string)reader["Name"];
//            int weight = (int)reader["Weight"];
//            int heigth = (int)reader["Height"];
//            string? desctription = reader["Description"] == DBNull.Value ? null : (string)reader["Description"];
//            int type1Id = (int)reader["Type1Id"];
//            int? type2Id = reader["Type2Id"] == DBNull.Value ? null : (int)reader["Type2Id"];

//            Pokemon p = new Pokemon()
//            {
//                Id = id,
//                Name = name,
//                Weight = weight,
//                Height = heigth,
//                Description = desctription,
//                Type1Id = type1Id,
//                Type2Id = type2Id
//            };

//            pokemons.Add(p);
//        }
//    }
//    pokemons.ForEach(p => Console.WriteLine(p));
//}
//void AddPokemon()
//{
//    using (SqlConnection connection = new SqlConnection(connectionString))
//    {
//        SqlCommand cmd = connection.CreateCommand();

//        cmd.CommandText = $"INSERT INTO pokemon " +
//                          $"VALUES (@name, @height, @weight, @description, @type1Id, @type2Id)";

//        cmd.Parameters.AddWithValue("@name", "Arcanin");
//        cmd.Parameters.AddWithValue("@height", 50);
//        cmd.Parameters.AddWithValue("@weight", 100);
//        cmd.Parameters.AddWithValue("@description", "Belle bête");
//        cmd.Parameters.AddWithValue("@type1Id", 2);
//        cmd.Parameters.AddWithValue("@type2Id", DBNull.Value);

//        connection.Open();

//        int nbRows = cmd.ExecuteNonQuery();
//        Console.WriteLine($"{nbRows} row(s) affected");
//    }
//}
#endregion