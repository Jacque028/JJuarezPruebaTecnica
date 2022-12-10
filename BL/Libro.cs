using System;
using System.Collections.Generic;
using System.Data;
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


        // Update 
        public static ML.Result Update(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                //SqlConnection es para conexión a sql server
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    //almacenar querys de sql y ejercutarlos
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UPDATE [Libro] SET [Nombre] = @Nombre, [IdAutor] = @IdAutor, [NumeroPaginas] = @NumeroPaginas, [FechaPublicacion] =@FechaPublicacion, [IdEditorial] =@IdEditorial, [Edicion] =@Edicion, [IdGenero] =@IdGenero WHERE Libro.[IdLibro] =@IdLibro";
                        cmd.Connection = context;

                        //Agregar parametros
                        SqlParameter[] collection = new SqlParameter[8];

                        collection[0] = new SqlParameter("@IdLibro", System.Data.SqlDbType.Int);
                        collection[0].Value = libro.IdLibro;

                        collection[1] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[1].Value = libro.Nombre;

                        collection[2] = new SqlParameter("@IdAutor", System.Data.SqlDbType.Int);
                        collection[2].Value = libro.Autor.IdAutor;

                        collection[3] = new SqlParameter("@NumeroPaginas", System.Data.SqlDbType.Int);
                        collection[3].Value = libro.NumeroPaginas;

                        collection[4] = new SqlParameter("@FechaPublicacion", System.Data.SqlDbType.Date);
                        collection[4].Value = libro.FechaPublicacion;

                        collection[5] = new SqlParameter("@IdEditorial", System.Data.SqlDbType.Int);
                        collection[5].Value = libro.Editorial.IdEditorial;

                        collection[6] = new SqlParameter("@Edicion", System.Data.SqlDbType.VarChar);
                        collection[6].Value = libro.Edicion;

                        collection[7] = new SqlParameter("@IdGenero", System.Data.SqlDbType.Int);
                        collection[7].Value = libro.Genero.IdGenero;

                        //Pasarle a mi command los parametros

                        cmd.Parameters.AddRange(collection);

                        //Abrir la conexión
                        cmd.Connection.Open();

                        //Ejecutando nuestra sentencia
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
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        // GetAll 
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroGetAll";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        //aqui voy a almacenar la información
                        DataTable tableLibro = new DataTable();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        //adapter.SelectCommand = cmd;
                        adapter.Fill(tableLibro);

                        if (tableLibro.Rows.Count > 0)
                        {
                            //mi lista
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableLibro.Rows)
                            {
                                ML.Libro libro = new ML.Libro();
                                libro.IdLibro = int.Parse(row[0].ToString());
                                libro.Nombre = row[1].ToString();

                                libro.Autor = new ML.Autor();
                                libro.Autor.IdAutor = int.Parse(row[2].ToString()); 

                                libro.NumeroPaginas = int.Parse(row[3].ToString());
                                libro.FechaPublicacion = row[4].ToString();

                                libro.Editorial = new ML.Editorial();
                                libro.Editorial.IdEditorial = int.Parse(row[5].ToString());

                                
                                libro.Edicion = row[6].ToString();

                                libro.Genero = new ML.Genero();
                                libro.Genero.IdGenero = int.Parse(row[7].ToString());

                                result.Objects.Add(libro);
                            }
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
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


        // GetById 
        public static ML.Result GetById(int IdLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroGetById";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdLibro", SqlDbType.Int);
                        collection[0].Value = IdLibro;

                        cmd.Parameters.AddRange(collection);

                        //aqui voy a almacenar la información
                        DataTable tableLibro = new DataTable();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        //adapter.SelectCommand = cmd;
                        adapter.Fill(tableLibro);

                        if (tableLibro.Rows.Count > 0)
                        {

                            DataRow row = tableLibro.Rows[0];

                            ML.Libro libro = new ML.Libro();

                            libro.IdLibro = int.Parse(row[0].ToString());
                            libro.Nombre = row[1].ToString();

                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = int.Parse(row[2].ToString());

                            libro.NumeroPaginas = int.Parse(row[3].ToString());
                            libro.FechaPublicacion = row[4].ToString();

                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = int.Parse(row[5].ToString());


                            libro.Edicion = row[6].ToString();

                            libro.Genero = new ML.Genero();
                            libro.Genero.IdGenero = int.Parse(row[7].ToString());


                            //boxing
                            //Almacenar cualquier tipo de dato en un dato object
                            result.Object = libro;

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
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        // Delete 
        public static ML.Result Delete(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                //SqlConnection es para conexión a sql server
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    //almacenar querys de sql y ejercutarlos
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroDelete";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;

                        //Agregar parametros
                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdLibro", System.Data.SqlDbType.VarChar);
                        collection[0].Value = libro.IdLibro;

                        //Pasarle a mi command los parametros

                        cmd.Parameters.AddRange(collection);

                        //Abrir la conexión
                        cmd.Connection.Open();

                        //Ejecutando nuestra sentencia
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
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

    }
}
