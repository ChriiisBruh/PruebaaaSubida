using Hitosapi.Connection;
using Hitosapi.Models;
using System.Data;
using System.Data.SqlClient;

namespace Hitosapi.Data
{
    public class Dprojects
    {
        ConnectionDB cn = new ConnectionDB();
        public async Task<List<Mprojects>> GetMprojects()
        {
            var list = new List<Mprojects>();
            using(var sql = new SqlConnection(cn.stringSQL())) 
            {
                using (var cmd = new SqlCommand("getProjects", sql)) 
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = await cmd.ExecuteReaderAsync()) 
                    { 
                        while (await reader.ReadAsync())
                        {
                            var mprojects = new Mprojects();
                            mprojects.id = (int)reader["id"];
                            mprojects.name = (string)reader["name"];
                            mprojects.description = (string)reader["description"];
                            list.Add(mprojects);

                        }
                    
                    }
                }
            }
            return list;

        }
    }
}
