using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            
            TIC.DatosPersonas persona = new TIC.DatosPersonas();
            persona.Cedula = this.txtCedula.Text;
            persona.Apellidos = this.txtApellido.Text;
            persona.Nombres = this.txtNombres.Text;
            string sexo = "M";
            if (this.cmbSexo.Text == "Femenino")
                sexo = "F";
            persona.Sexo = sexo;
            persona.FechaNacimiento = this.dtFechaNacimiento.Value;
            persona.Correo = this.txtCorreo.Text;
            persona.Estatura = Int32.Parse(this.txtEstatura.Text);
            persona.Peso = Decimal.Parse(this.txtPeso.Text);
            int x = 0;
            try
            {
                if(TIC.DatosPersonasDAO.existeCedula(this.txtCedula.Text))
                {
                    MessageBox.Show("Esa cédula ya existe...");
                    return; //abandonar
                }

                x = TIC.DatosPersonasDAO.crear(persona);
                if (x > 0)
                    MessageBox.Show("Registro agregado...");
                else
                    MessageBox.Show("No se pudo agregar el registro...");
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                //Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                //el código que se escriba en esta sección
                //se ejecutará siempre, es decir, haya o no error
                this.cargarGridPersonas();
            }
        }

        private void frmIngresar_Load(object sender, EventArgs e)
        {
            this.cargarGridPersonas();
        }
        private void cargarGridPersonas()
        {
            DataTable dt = TIC.DatosPersonasDAO.getAll();
            this.dgPersonas.DataSource = dt;
        }
    }
}
