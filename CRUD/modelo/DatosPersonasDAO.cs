using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC
{
    public static class DatosPersonasDAO
    {
        private static String cadenaConexion= "server=DESKTOP-JMKMHRF; database= TI2020; user id=sa; password=Dragonforce@12";
        public static int crear(DatosPersonas datosPersonas)
        {
            //1. configurar la conexión con una fuente de datos
            //string cadenaConexion = "server=DESKTOP-JMKMHRF; database= TI2020; user id=sa; password=Dragonforce@12";
            //string cadenaConexion = "server=DESKTOP-JMKMHRF; database= TI2020; Integrated Security ";
            //definir un objeto tipo conexión
            SqlConnection conn = new SqlConnection(cadenaConexion);

            //2. Definir y configurar la operación a realizar en el motor de BDD
            //escribir sentencia sql
            string sql = "insert into DatosPersonas(cedula,apellidos,nombres,sexo," +
                "fechaNacimiento, correo, estaturacm, peso) values(@cedula,@apellidos,@nombres," +
                "@sexo, @fechaNacimiento, @correo, @estaturacm, @peso)";

            //definir un comando para ejecutar esa sentencia sql (operacion a realizar)
            SqlCommand comando = new SqlCommand(sql, conn);
            comando.CommandType = System.Data.CommandType.Text; //valor por defecto
            comando.Parameters.AddWithValue("@cedula", datosPersonas.Cedula);
            comando.Parameters.AddWithValue("@apellidos", datosPersonas.Apellidos);
            comando.Parameters.AddWithValue("@nombres", datosPersonas.Nombres);
            comando.Parameters.AddWithValue("@sexo", datosPersonas.Sexo);
            comando.Parameters.AddWithValue("@fechaNacimiento", datosPersonas.FechaNacimiento.Date);
            comando.Parameters.AddWithValue("@estaturacm", datosPersonas.Estatura);
            comando.Parameters.AddWithValue("@peso", datosPersonas.Peso);
            comando.Parameters.AddWithValue("@correo", datosPersonas.Correo);

            //3. Se abre la conexión y se ejecuta el comando
            conn.Open();
            int x = comando.ExecuteNonQuery(); //ejecutamos el comando
            //4. cerrar la conexión
            conn.Close();

            return x;
        }

        public static Boolean existeCedula(String scedula)
        {
            //1. definir y configurar conexión

            SqlConnection conn = new SqlConnection(cadenaConexion);

            //2. Definir y configurar la operación a realizar en el motor de BDD
            //escribir sentencia sql
            string sql = "select cedula " +
                "from DatosPersonas " + 
                "where cedula=@cedula";

            //Definir un adaptador de datos: es un puente que permite pasar los datos de nuestra BDD, hacia
            //el datatable
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            ad.SelectCommand.Parameters.AddWithValue("@cedula", scedula);

            //3. recuperamos los datos
            DataTable dt = new DataTable();
                ad.Fill(dt);
            Boolean existe = false;
            if (dt.Rows.Count > 0) //si existen filas
                existe = true;

            return existe;
        }
        public static int delete(String cedula)
        {
            //1) crear el método borrado usando como guía el método crear
            SqlConnection conn = new SqlConnection(cadenaConexion);

            //la sentencia sql es la siguiente
            //"delete from NombreTable where campo=@campo"
            string sql = "delete cedula " +
                "from DatosPersonas " +
                "where cedula=@cedula";

            //2) Definir la interfaz de usuario para probar este método(formulario)
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            ad.DeleteCommand.Parameters.AddWithValue("@cedula", cedula);
            return 0;
        }
    }
}
