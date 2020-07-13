using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC
{
    public static class DatosPersonasDAO
    {
        public static int crear(DatosPersonas datosPersonas)
        {
            //1. configurar la conexión con una fuente de datos
            string cadenaConexion = "server=DESKTOP-JMKMHRF; database= TI2020; user id=sa; password=Dragonforce@12";
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
    }
}
