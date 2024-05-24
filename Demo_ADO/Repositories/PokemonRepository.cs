using Demo_ADO.Interfaces;
using Demo_ADO.Models;
using System.Data;
using System.Data.SqlClient;

namespace Demo_ADO.Repositories
{
    internal class PokemonRepository : IPokemonRepository
    {
        private readonly string _connectionString;

        public PokemonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Pokemon Convert(IDataRecord record)
        {
            return new Pokemon()
            {
                Id = (int)record["Id"],
                Name = (string)record["Name"],
                Height = (int)record["Height"],
                Weight = (int)record["Weight"],
                Description = record["Description"] == DBNull.Value ? null : (string)record["Description"],
                Type1Id = (int)record["Type1Id"],
                Type2Id = record["Type2Id"] == DBNull.Value ? null : (int)record["Type2Id"]
            };
        }


        public Pokemon ConvertFull(IDataRecord record) 
        {
            Pokemon pokemon = Convert(record);
            pokemon.Type1 = new PokemonType()
            {
                Id = (int)record["Id"],
                Name = (string)record["Type1Name"],
            };

            if (record["Type2Id"] != DBNull.Value)
            {
                pokemon.Type2 = new PokemonType()
                {
                    Id = (int)record["Id"],
                    Name = (string)record["Type2Name"],
                };
            }
            return pokemon;
        }


        public IEnumerable<Pokemon> GetAll()
        {
            using SqlConnection conn = new SqlConnection( _connectionString );
            using SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT * " +
                              "FROM Pokemon";

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                yield return Convert(reader);
            }

            conn.Close();
        }


        public Pokemon? GetById(int id)
        {
            using SqlConnection conn = new SqlConnection( _connectionString );
            using SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"SELECT p.*, t.Name as 'Type1Name', t2.Name as 'Type2Name'
                                FROM Pokemon p
                                    LEFT JOIN Type t
                                        ON p.Type1Id = t.Id
                                    LEFT JOIN Type t2
                                        ON p.Type2Id = t2.Id
                                WHERE p.Id = @id";

            cmd.Parameters.AddWithValue("id", id);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            Pokemon? pokemon = null;

            if (reader.Read())
            {
                pokemon = ConvertFull(reader);
            }

            conn.Close();

            return pokemon;
        }


        public int Count()
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            using SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"SELECT COUNT(*)
                                FROM Pokemon";

            conn.Open();

            int count = (int)cmd.ExecuteScalar();

            conn.Close();

            return count;
        }


        public int Create(Pokemon p)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            using SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"INSERT INTO Pokemon
                                OUTPUT INSERTED.Id
                                VALUES (@name, @height, @weight, @description, @type1Id, @type2Id)";

            cmd.Parameters.AddWithValue("@name", p.Name);
            cmd.Parameters.AddWithValue("@height", p.Height);
            cmd.Parameters.AddWithValue("@weight", p.Weight);
            cmd.Parameters.AddWithValue("@description", p.Description is null ? DBNull.Value : p.Description);
            cmd.Parameters.AddWithValue("@type1Id", p.Type1Id);
            cmd.Parameters.AddWithValue("@type2Id", p.Type2Id is null ? DBNull.Value : p.Type2Id);

            conn.Open();

            int id = (int)cmd.ExecuteScalar();

            conn.Close();

            return id;    
        }


        public bool Update(int id, Pokemon p)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            using SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"UPDATE Pokemon
                                SET Name = @name,
                                    Height = @height,
                                    Weight = @weight,
                                    Description = @description,
                                    Type1Id = @type1Id,
                                    Type2Id = @type2Id
                                WHERE id = @id";

            cmd.Parameters.AddWithValue("@name", p.Name);
            cmd.Parameters.AddWithValue("@height", p.Height);
            cmd.Parameters.AddWithValue("@weight", p.Weight);
            cmd.Parameters.AddWithValue("@description", p.Description is null ? DBNull.Value : p.Description);
            cmd.Parameters.AddWithValue("@type1Id", p.Type1Id);
            cmd.Parameters.AddWithValue("@type2Id", p.Type2Id is null ? DBNull.Value : p.Type2Id);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();

            int nbRows = cmd.ExecuteNonQuery();

            conn.Close();

            return nbRows == 1;
        }


        public bool Delete(int id)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            using SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"DELETE Pokemon
                                WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            conn.Open() ;

            int nbRows = cmd.ExecuteNonQuery();
            
            conn.Close();

            return nbRows == 1;
        }
    }
}
