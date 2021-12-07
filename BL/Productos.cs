using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Productos
    {
        public static ML.Result GetById(ML.Producto productos)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "GetById";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                        collection[0].Value = productos.IdProducto;

                        collection[1] = new SqlParameter("DistanciaSucursalSol", SqlDbType.Int);
                        collection[1].Value = 500;

                        cmd.Parameters.AddRange(collection);

                        context.Open();
                        DataTable data = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(data);

                        if (data.Rows.Count > 0)
                        {
                            DataRow row = data.Rows[0];

                            ML.Producto producto = new ML.Producto();
                            producto.Sucursal = new ML.Sucursal();

                            producto.Nombre = row[0].ToString();
                            producto.PrecioEnvio = double.Parse(row[1].ToString());
                            producto.Sucursal.DistanciaEstimada = int.Parse(row[2].ToString());
                            producto.Precio = double.Parse(row[3].ToString());
                            producto.Iva = double.Parse(row[4].ToString());
                            producto.PrecioFinal = double.Parse(row[5].ToString());

                            result.Object = producto;

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No hay información que mostrar";
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
            }
            return result;
        }

        public static ML.Result CambiarDivisas(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                if (producto.FechaConsulta != null)
                {
                    producto.PrecioDolares = producto.PrecioEnvio * 0.047;
                    producto.PrecioEuros = producto.PrecioEnvio * 0.042;

                    result.Object = producto;

                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "Ocurro un error";
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
            }
            return result;
        }
    }
}
