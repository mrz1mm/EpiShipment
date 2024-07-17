using EpiShipment.Models;
using EpiShipment.Models.Dto;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.Data.SqlClient;
using System.Security.Claims;

namespace EpiShipment.Services
{

    public class UserService
    {
        private readonly IConfiguration _config;
        public UserService(IConfiguration config)
        {
            _config = config;
        }

        public User GetUser(LoginDto loginDto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string SELECT_CMD = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(SELECT_CMD, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", loginDto.Username);
                        cmd.Parameters.AddWithValue("@Password", loginDto.Password);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                User user = new User
                                {
                                    UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                    Username = reader.GetString(reader.GetOrdinal("Username")),
                                    Password = ""
                                };
                                return user;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero dell'utente", ex);
            }
            return null;
        }



        public User AddUser(RegisterDto registerDto)
            {
            try
            {
                using
                    (
                    SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection"))
                    )
                    {
                    conn.Open();
                    const string INSERT_CMD = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                    using (SqlCommand cmd = new SqlCommand(INSERT_CMD, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", registerDto.Username);
                        cmd.Parameters.AddWithValue("@Password", registerDto.Password);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nell'inserimento dell'utente", ex);
            }
            return null;
        }
    }
}
