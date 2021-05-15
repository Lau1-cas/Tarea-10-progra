
using P1Acrud.Clases.Archivos;
using P1Acrud.Clases.Archivos.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P1Acrud
{
    public partial class frmInicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void cargarArchivoExterno()
        {
            string fuente = @"C:\Users\USUARIO\Pictures\crudDB.csv";
            ClsArchivos ar = new ClsArchivos();


            //obtener todo el archivo, linea por linea dentro de un arreglo simple 
            string[] ArregloNotas = ar.LeerArchivo(fuente);
            string sentencia_sql = "";
            int NumeroLinea = 0;

            ClsConexion cn = new ClsConexion();

            foreach(string lineas in ArregloNotas)
            {
                //obtener datos
                string[] datos = lineas.Split(';');
                if (NumeroLinea > 0)
                {
                    sentencia_sql += $"insert into tb_alumnos values({datos[0]},'{datos[1]}',{datos[2]},{datos[3]},{datos[4]});\n";
                }
                NumeroLinea++;
            }
            cn.EjecutaSQLDirecto(sentencia_sql);
        }

        protected void ButtonSubirInformacion_Click(object sender, EventArgs e)
        {
            cargarArchivoExterno();
        }
    }
}