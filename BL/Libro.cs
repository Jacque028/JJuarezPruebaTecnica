using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    { 
        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result(); 
            
            try 
            { 
                using(SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "INSERT INTO Libro(Nombre, IdAutor, NumeroPaginas,FechaPublicacion,IdEditorial,Edicion,IdGenero) " +
                            "VALUES (@Nombre, @IdAutor, @NumeroPaginas, @FechaPublicacion, @IdEditorial, @Edicion, @IdGenero)";
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[7];

                        collection[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = libro.Nombre;

                        collection[1] = new SqlParameter("@IdAutor", System.Data.SqlDbType.Int);
                        collection[1].Value = libro.Autor.IdAutor;

                        collection[2] = new SqlParameter("@NumeroPaginas", System.Data.SqlDbType.Int);
                        collection[2].Value = libro.NumeroPaginas;

                        collection[3] = new SqlParameter("@FechaPublicacion", System.Data.SqlDbType.Date);
                        collection[3].Value = libro.FechaPublicacion;

                        collection[4] = new SqlParameter("@IdEditorial", System.Data.SqlDbType.Int);
                        collection[4].Value = libro.Editorial.IdEditorial;

                        collection[5] = new SqlParameter("@Edicion", System.Data.SqlDbType.VarChar);
                        collection[5].Value = libro.Edicion;

                        collection[6] = new SqlParameter("@IdGenero", System.Data.SqlDbType.Int);
                        collection[6].Value = libro.Genero.IdGenero;

                        cmd.Parameters.AddRange(collection);

                        //Abrir Conexion
                        cmd.Connection.Open();

                        //Ejecutar
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }


                    }
                }
            }
            catch (Exception ex)
            { 
                result .Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            } 
            return result;
        }

        
    }
}
