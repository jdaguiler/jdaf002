using apiServicio.Models;
using apiServicio.Bussines.Contracts;
using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlTypes;
using Microsoft.AspNetCore.Identity;

namespace apiServicio.Bussines.Clases

{
    public class RolRepository: IRolRepository
    {
        private readonly string connec;
        public RolRepository(IConfiguration configuration)
        {
            connec = configuration.GetConnectionString("conBase");
        }
        public async Task<List<RolBE>> GetList()
        {
            List<RolBE> list = new List<RolBE>();
            RolBE = l;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                await conn.OpenAsync();
                sqlComand cmd = new sqlComand("select * from trnRol", conn);
                using var reader = await cmd.ExecuteReaderAsync(); 
                {
                    while (await reader.ReadAsync())
                    {
                        l = new RolBE();
                        l.IdRol = Convert.ToInt32(reader["IdRol"]);
                        l.NombreRol = Convert.ToString(reader["NombreRol"]);
                        list.Add(l);
                    }
                }
            }
        }
    }
}
