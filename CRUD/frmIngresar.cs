using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIC;

namespace CRUD
{
    public partial class frmIngresar : Form
    {
        public frmIngresar()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //1. reemplazar y validar cuadro de texto
            //2. validar que el correo sea correcto
            //3. agregar try...catch
            //3. insertar al menos 5 registros
            //4. compartir en github
            TIC.DatosPersonas persona = new TIC.DatosPersonas();
            persona.Cedula = "08011183";
            persona.Apellidos = "Ortiz";
            persona.Nombres = "Gerardo";
            persona.Sexo = "M";
            persona.FechaNacimiento = DateTime.Now.Date;
            persona.Correo = "gerardortiz21@gmail.com";
            persona.Estatura = 174;
            persona.Peso = 70.20m;
            int x = TIC.DatosPersonasDAO.crear(persona);
            if (x > 0)
                MessageBox.Show("Registro agregado...");
            else
                MessageBox.Show("No se pudo agregar el registro...");
        }
    }
}
