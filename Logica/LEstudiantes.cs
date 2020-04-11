using Data;
using LinqToDB;
using Logica.Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqToDB.Data;


namespace Logica
{
    public class LEstudiantes : Librarie
    {
        private List<TextBox> listTextBox;
        private List<Label> listLabel;
        private PictureBox image;
        private Bitmap _imagBitMap;
        // private Librarie librarie;
        private DataGridView _dataGridView;
        private NumericUpDown _numericUpDown;
        private Paginador<Estudiante> _paginador;
        private String _accion = "insert";
        public LEstudiantes(List<TextBox> listTextBox, List<Label> listLabel, object[] objetosIMG)
        {
            this.listTextBox = listTextBox;
            this.listLabel = listLabel;
            //this.librarie = new Librarie();
            /*Downgrade Convertis el objeto en un pictureBox de menor escala*/
            image = (PictureBox)objetosIMG[0];
            _imagBitMap = (Bitmap)objetosIMG[1];
            _dataGridView = (DataGridView)objetosIMG[2];
            _numericUpDown = (NumericUpDown)objetosIMG[3];

            restablecer();
        }
        public void Registrar()
        {
            /*Si el campo esta vacio*/
            if (listTextBox[0].Text.Equals(""))
            {
                listLabel[0].Text = "Nombre requerido";
                listLabel[0].ForeColor = Color.DarkRed;

                listTextBox[0].Focus();
            }
            else
            {
                if (listTextBox[1].Text.Equals(""))
                {
                    listLabel[1].Text = "Apellido requerido";
                    listLabel[1].ForeColor = Color.DarkRed;

                    listTextBox[1].Focus();
                }
                else
                {
                    if (listTextBox[2].Text.Equals(""))
                    {
                        listLabel[2].Text = "Mat. requerida";
                        listLabel[2].ForeColor = Color.DarkRed;

                        listTextBox[2].Focus();
                    }
                    else
                    {
                        if (listTextBox[3].Text.Equals(""))
                        {
                            listLabel[3].Text = "Email requerido";
                            listLabel[3].ForeColor = Color.DarkRed;

                            listTextBox[3].Focus();
                        }
                        else
                        {
                            /*Tomamos el email valido o no */
                            if (textBoxEvent.comprobarFormatoEmail(listTextBox[3].Text))
                            {

                                var user = _Estudiante.Where(u => u.email.Equals(listTextBox[3].Text)).ToList();
                                if (user.Count.Equals(0))
                                {
                                    save();
                                }
                                else
                                {
                                    if (user[0].id.Equals(_idEstudiante))
                                    {
                                        save();
                                    }
                                    else
                                    {
                                        listLabel[3].Text = "Email ya registrado";
                                        listLabel[3].ForeColor = Color.DarkRed;
                                        listLabel[3].Focus();
                                    }
                                }

                            }
                            else
                            {
                                listLabel[3].Text = "Email invalido";
                                listLabel[3].ForeColor = Color.DarkRed;

                                listTextBox[3].Focus();
                            }
                        }

                    }
                }
            }
        }
        public void save()
        {

            BeginTransactionAsync();
            try
            {
                var imageArray = uploadImage.ImageToByte(image.Image);

                switch (_accion)
                {
                    case "insert":
                        _Estudiante.Value(e => e.nombre, listTextBox[0].Text)
                        .Value(e => e.apellido, listTextBox[1].Text)
                        .Value(e => e.matricula, listTextBox[2].Text)
                        .Value(e => e.email, listTextBox[3].Text)
                        .Value(e => e.image, imageArray)
                        .Insert();
                    break;

                    case "update":
                        _Estudiante.Where(u => u.id.Equals(_idEstudiante))
                        .Set(e => e.matricula, listTextBox[0].Text)
                        .Set(e => e.nombre, listTextBox[1].Text)
                        .Set(e => e.apellido, listTextBox[2].Text)
                        .Set(e => e.email, listTextBox[3].Text)
                        .Set(e => e.image, imageArray)
                        .Update();
                        break;
                }
                //var db = new Connection();
                //db.Insert(new Estudiante() { 

                //    nombre= listTextBox[0].Text,
                //    apellido= listTextBox[1].Text,
                //    matricula= listTextBox[2].Text,
                //    email= listTextBox[3].Text
                //});
                

                CommitTransaction();
                restablecer();
            }
            catch (Exception e)
            {
                RollbackTransaction();
                Console.WriteLine(e);
            }

        }
        private int _reg_por_pagina = 2, _num_pagina = 1;
        public void SearchEstudiante(string campo)
        {
            List<Estudiante> query = new List<Estudiante>();
            int inicio = (_num_pagina - 1) * _reg_por_pagina;
            if (campo.Equals(""))
            {
                query = _Estudiante.ToList();
            }
            else
            {
                query = _Estudiante.Where(c => c.matricula.StartsWith(campo) || c.nombre.StartsWith(campo) || c.apellido.StartsWith(campo)).ToList();
            }
            if (0 < query.Count)
            {
                _dataGridView.DataSource = query.Select(c => new
                {
                    c.id,
                    c.nombre,
                    c.apellido,
                    c.matricula,
                    c.email,
                    c.image

                }).Skip(inicio).Take(_reg_por_pagina).ToList();
                _dataGridView.Columns[0].Visible = false;
                _dataGridView.Columns[5].Visible = false;


                _dataGridView.Columns[1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                _dataGridView.Columns[3].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            }
            else
            {
                _dataGridView.DataSource = query.Select(c => new
                {
                    c.matricula,
                    c.nombre,
                    c.apellido,
                    c.email
                }).ToList();
            }
        }

        public void Paginador(String metodo)
        {
            switch (metodo)
            {
                case "Primero":
                    _num_pagina = _paginador.primero();
                    break;
                case "Anterior":
                    _num_pagina = _paginador.anterior();
                    break;
                case "Siguiente":
                    _num_pagina = _paginador.Siguiente();
                    break;
                case "Ultimo":
                    _num_pagina = _paginador.ultimo();
                    break;

            }
            SearchEstudiante("");
        }

        public void Registro_Paginas()
        {
            _num_pagina = 1;
            _reg_por_pagina=(int)_numericUpDown.Value;
            var list = _Estudiante.ToList();
            if (0<list.Count)
            {
                _paginador = new Paginador<Estudiante>(listEstudiante, listLabel[4], _reg_por_pagina);

                SearchEstudiante("");

            }
        }

        private int _idEstudiante = 0;
        public void getEstudiante()
        {
            _accion = "update";
            _idEstudiante = Convert.ToInt32(_dataGridView.CurrentRow.Cells[0].Value);
            listTextBox[0].Text = Convert.ToString(_dataGridView.CurrentRow.Cells[1].Value);
            listTextBox[1].Text = Convert.ToString(_dataGridView.CurrentRow.Cells[2].Value);
            listTextBox[2].Text = Convert.ToString(_dataGridView.CurrentRow.Cells[3].Value);
            listTextBox[3].Text = Convert.ToString(_dataGridView.CurrentRow.Cells[4].Value);

            try
            {
                byte[] arrayImage = (byte[])_dataGridView.CurrentRow.Cells[5].Value;
                image.Image = uploadImage.byteArrayToImage(arrayImage);
            }
            catch (Exception)
            {
                image.Image = _imagBitMap;
            }
        }

        public void Eliminar()
        {
            if (_idEstudiante.Equals(0))
            {
                MessageBox.Show("Seleccione un estudiante");
            }
            else
            {
                if (MessageBox.Show("¿Estas seguro de eliminar este usuario?", "Eliminar usuario", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _Estudiante.Where(c => c.id.Equals(_idEstudiante)).Delete();
                    restablecer();
                }
            }
        }


        private List<Estudiante> listEstudiante;
        public void restablecer()
        {
            _accion = "insert";
            _num_pagina = 1;
            _idEstudiante = 0;
            image.Image = _imagBitMap;
            listLabel[0].Text = "Nombre";
            listLabel[1].Text = "Apellido";
            listLabel[2].Text = "Matricula";
            listLabel[3].Text = "Email";

            listLabel[0].ForeColor = Color.LightSlateGray;
            listLabel[1].ForeColor = Color.LightSlateGray;
            listLabel[2].ForeColor = Color.LightSlateGray;
            listLabel[3].ForeColor = Color.LightSlateGray;

            listTextBox[0].Text = "";
            listTextBox[1].Text = "";
            listTextBox[2].Text = "";
            listTextBox[3].Text = "";
            listEstudiante = _Estudiante.ToList();
            if (0 < listEstudiante.Count)
            {
                _paginador = new Paginador<Estudiante>(listEstudiante, listLabel[4], _reg_por_pagina);
            }
            SearchEstudiante("");
        }
    }
}
