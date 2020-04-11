using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica.Library
{
    public class TextBoxEvent
    {
        public void textKeyPress(KeyPressEventArgs e)
        {
            /* si el dato es de carater alfabetico*/
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
                /*Conficion que no permite dar salto de linea*/
            }else if (e.KeyChar == Convert.ToChar(Keys.Enter)) 
            {
                e.Handled = true;
                /*Condición que nos permite utilizar la tecla backspace*/
            }else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                /*Condición que nos permite utilizar la tecla espacio*/
            }else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }
        public void numberKeyPress(KeyPressEventArgs e)
        {
            /* si el dato es de carater alfabetico*/
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                /*Conficion que no permite dar salto de linea*/
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                /*Condición que nos permite utilizar la tecla backspace*/
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                /*Condición que nos permite utilizar la tecla espacio*/
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        public bool comprobarFormatoEmail(String email)
        {
            /*using de .net*/
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
