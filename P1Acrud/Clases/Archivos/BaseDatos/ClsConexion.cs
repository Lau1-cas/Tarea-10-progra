using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace P1Acrud.Clases.Archivos.BaseDatos
{
    public class ClsConexion
    {
        public SqlConnection conexion;
        private String _conexion { get; }

        public ClsConexion()
        {

         _conexion = "Data Source=DESKTOP-EMF2OEN\\SQLEXPRESS;Initial Catalog=dbprogra;Integrated Security=True";

        }

        public void cerrarConexionBD()
        {
            conexion.Close();
        }

        public void abrirConexion()
        {
            conexion = new SqlConnection(_conexion);
            conexion.Open();
        }

        public DataTable consultaTablaDirecta(String sqll)
        {
            abrirConexion();
            SqlDataReader dr;
            SqlCommand comm = new SqlCommand(sqll, conexion);
            dr = comm.ExecuteReader();

            var dataTable = new DataTable();
            dataTable.Load(dr);
            cerrarConexionBD();
            return dataTable;
        }

        public void EjecutaSQLDirecto(String sqll)
        {
            abrirConexion();
            try
            {

                SqlCommand comm = new SqlCommand(sqll, conexion);
                comm.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                cerrarConexionBD();
            }



        }

        public void EjecutaSQLManual(String sqll)
        {
      
            SqlCommand comm = new SqlCommand(sqll, conexion);
            comm.ExecuteReader();
        }


    private void cargarArchivoExterno()
    {
        string fuente = @"C:\Users\USUARIO\Pictures\crudDB.csv";
            ClsArchivos ar = new ClsArchivos();
     
        string[] ArregloNotas = ar.LeerArchivo(fuente);
        string sentencia_sql = "";
        int Numerolinea = 0;
        ClsConexion cn = new ClsConexion();
        foreach (string linea in ArregloNotas)
        {
          
            String[] datos = linea.Split(';');
            if (Numerolinea > 0)
            {
                sentencia_sql = sentencia_sql + $"insert into tb_alumnos values({datos[0]},'{datos[1]}',{datos[2]},{datos[3]},{datos[4]},{datos[5]},'{datos[6]}');\n ";
            }
            Numerolinea++;
        }
        cn.EjecutaSQLDirecto(sentencia_sql);
    }
    }//fin clase
}



