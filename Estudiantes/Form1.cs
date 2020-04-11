using Logica;
using Logica.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudiantes
{
    public partial class Form1 : Form
    {
        private LEstudiantes estudiante;
        //private Librarie librarie;

        public Form1()
        {
            InitializeComponent();
            //this.librarie = new Librarie();
            /*contiene una colección de objetos de la clase textbox*/
            var listTextBox = new List<TextBox>();
            listTextBox.Add(textBoxNombre);
            listTextBox.Add(textBoxApellido);
            listTextBox.Add(textBoxMatricula);
            listTextBox.Add(textBoxEmail);

            var listLabel = new List<Label>();
            listLabel.Add(labelNombre);
            listLabel.Add(labelApellido);
            listLabel.Add(labelMatricula);
            listLabel.Add(labelEmail);
            listLabel.Add(labelPaginas);

            Object[] objetosIMG = { pictureBoxImage,
                                    Properties.Resources.placeholder_user,
                                    dataGridView1,
                                    NumericPage};

            estudiante = new LEstudiantes(listTextBox,listLabel, objetosIMG);


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            estudiante.Registrar();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            estudiante.restablecer();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            estudiante.uploadImage.CargarImagen(pictureBoxImage);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            estudiante.Eliminar();
        }

        private void label5_Click_2(object sender, EventArgs e)
        {

        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNombre.Text.Equals(""))
            {
                labelNombre.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelNombre.ForeColor = Color.Green;
                labelNombre.Text = "Nombre";
            }
        }

        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            estudiante.textBoxEvent.textKeyPress(e);
        }

        private void textBoxApellido_TextChanged(object sender, EventArgs e)
        {
            if (textBoxApellido.Text.Equals(""))
            {
                labelApellido.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelApellido.ForeColor = Color.Green;
                labelApellido.Text = "Apellido";
            }
        }

        private void textBoxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            estudiante.textBoxEvent.textKeyPress(e);
        }

        private void textBoxMatricula_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMatricula.Text.Equals(""))
            {
                labelMatricula.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelMatricula.ForeColor = Color.Green;
                labelMatricula.Text = "Matricula";
            }
        }

        private void textBoxMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            estudiante.textBoxEvent.numberKeyPress(e);
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            if (textBoxEmail.Text.Equals(""))
            {
                labelEmail.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelEmail.ForeColor = Color.Green;
                labelEmail.Text = "Email";
            }
        }

        private void textBoxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            estudiante.SearchEstudiante(textBoxBuscar.Text);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            estudiante.Paginador("Anterior");

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            estudiante.Paginador("Ultimo");

        }

        private void buttonSiguiente_Click(object sender, EventArgs e)
        {
            estudiante.Paginador("Siguiente");

        }

        private void buttonPrimero_Click(object sender, EventArgs e)
        {
            estudiante.Paginador("Primero");
        }

        private void NumericPage_ValueChanged(object sender, EventArgs e)
        {
            estudiante.Registro_Paginas();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows.Count != 0)
                estudiante.getEstudiante();
            
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
                estudiante.getEstudiante();
        }

        //private void NumericPage(object sender, EventArgs e)
        //{

        //}
    }
}
