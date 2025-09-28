using Cdoe_SAS.DB;
using Microsoft.Data.SqlClient;
using myportfolio.Models;
namespace myportfolio.Services.ProfileS
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly string _connectionString;

        public ProfileRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        ConnectionClass cc = new ConnectionClass();
        //public List<Profile> GetAll()
        //{
        //    var profiles = new List<Profile>();
        //    using var conn = new SqlConnection(cc.getConnection());
        //    var cmd = new SqlCommand("SELECT * FROM Profiles", conn);
        //    conn.Open();
        //    using var reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        profiles.Add(new Profile
        //        {
        //            Id = (int)reader["Id"],
        //            FullName = reader["FullName"].ToString(),
        //            JobRole = reader["JobRole"].ToString(),
        //            Experience = reader["Experience"].ToString(),
        //            Bio = reader["Bio"].ToString(),
        //            ProfileImageUrl = reader["ProfileImageUrl"].ToString()
        //        });
        //    }
        //    return profiles;
        //}
       
        public void Create(Profile profile)
        {
            using var conn = new SqlConnection(cc.getConnection());
            var cmd = new SqlCommand(@"INSERT INTO Profiles (FullName, JobRole, Experience, Bio, ProfileImageUrl)
                                   VALUES (@FullName, @JobRole, @Experience, @Bio, @ProfileImageUrl)", conn);
            cmd.Parameters.AddWithValue("@FullName", profile.FullName);
            cmd.Parameters.AddWithValue("@JobRole", profile.JobRole);
            cmd.Parameters.AddWithValue("@Experience", profile.Experience);
            cmd.Parameters.AddWithValue("@Bio", profile.Bio);
            cmd.Parameters.AddWithValue("@ProfileImageUrl", profile.ProfileImageUrl);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Update(Profile profile)
        {
            using var conn = new SqlConnection(cc.getConnection());
            var cmd = new SqlCommand(@"UPDATE Profiles SET FullName=@FullName, JobRole=@JobRole, Experience=@Experience,
                                   Bio=@Bio, ProfileImageUrl=@ProfileImageUrl WHERE Id=@Id", conn);
            cmd.Parameters.AddWithValue("@Id", profile.Id);
            cmd.Parameters.AddWithValue("@FullName", profile.FullName);
            cmd.Parameters.AddWithValue("@JobRole", profile.JobRole);
            cmd.Parameters.AddWithValue("@Experience", profile.Experience);
            cmd.Parameters.AddWithValue("@Bio", profile.Bio);
            cmd.Parameters.AddWithValue("@ProfileImageUrl", profile.ProfileImageUrl);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new SqlConnection(cc.getConnection());
            var cmd = new SqlCommand("DELETE FROM Profiles WHERE Id=@Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

}
