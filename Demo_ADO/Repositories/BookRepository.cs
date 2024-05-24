
using Demo_ADO.Interfaces;
using Demo_ADO.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace Demo_ADO.Repositories
{
    internal class BookRepository : IBookRepository
    {
        private readonly string _connectionString;

        public BookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Book Convert(IDataRecord record)
        {
            return new Book()
            {
                Id = (int)record["Id"],
                Title = (string)record["Title"],
                Description = (string)record["Description"],
                AuthorId = (int)record["AuthorId"],
                Created = record["Created"] == DBNull.Value ? null : (DateTime)record["Created"]
            };
        }

        /*public Book ConvertFull(IDataRecord record)
        {
            Book pokemon = Convert(record);
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
        }*/


        public IEnumerable<Book> GetAll()
        {
            using SqlConnection conn = new SqlConnection( _connectionString );
            using SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"SELECT *
                                FROM Book";

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                yield return Convert(reader);
            }

            conn.Close();
        }

        public Book? GetById(int id)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"SELECT b.*, a.Firstname, a.Lastname 
                                FROM Book b 
                                    JOIN Author a 
                                        ON b.AuthorId = a.AuthorId  
                                WHERE b.Id = @id";

            cmd.Parameters.AddWithValue("id", id);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            Book? book = null;

            if (reader.Read())
            {
                book = Convert(reader);
            }

            conn.Close();

            return book;
        }

        public int Count()
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            using SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"SELECT COUNT(*)
                                FROM Book";

            conn.Open();

            int count = (int)cmd.ExecuteScalar();

            conn.Close();

            return count;
        }

        public int create(Book b)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            using SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"INSERT INTO Book
                                OUTPUT INSERTED.Id
                                VALUES (@title, @description, @authorId, @created)";

            cmd.Parameters.AddWithValue ("@title", b.Title);
            cmd.Parameters.AddWithValue ("@description", b.Description);
            cmd.Parameters.AddWithValue ("@authorId", b.AuthorId);
            cmd.Parameters.AddWithValue ("@created", b.Created is null ? DBNull.Value : b.Created);

            conn.Open();

            int id = (int)cmd.ExecuteScalar();

            conn.Close();

            return id;
        }

        public bool Update(int id, Book b)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            using SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"UPDATE Book
                                SET Title = @title,
                                    Description = @description,
                                    AuthorId = @authorId
                                    Created = @created
                                WHERE id = @id";

            cmd.Parameters.AddWithValue("@title", b.Title);
            cmd.Parameters.AddWithValue("@description", b.Description);
            cmd.Parameters.AddWithValue("@authorId", b.AuthorId);
            cmd.Parameters.AddWithValue("@created", b.Created is null ? DBNull.Value : b.Created);

            conn.Open();

            int nbRows = cmd.ExecuteNonQuery();

            conn.Close();

            return nbRows == 1;
        }

        public bool delete(int id)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            using SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"DELETE Book
                                WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();

            int nbRows = cmd.ExecuteNonQuery();

            conn.Close();

            return nbRows == 1;

        }
    }
}
