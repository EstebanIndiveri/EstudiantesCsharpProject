using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica.Library
{
    public class UploadImage
    {
        private OpenFileDialog openFd = new OpenFileDialog();
        public void CargarImagen(PictureBox pictureBox)
        {
            /*Establecer la propiedad WitOnLoad a true es par que la imagen se cargue de forma sincrónica*/
            pictureBox.WaitOnLoad = true;
            openFd.Filter = "Imagenes|*.jpg;*.gif;*.jpeg*.png;";
            /*Mustra la ventana*/
            openFd.ShowDialog();
            /*Verifica si el filename es distinto a vacio xd*/
            if (openFd.FileName != string.Empty)
            {
                pictureBox.ImageLocation = openFd.FileName;
            }
        }
        public byte[] ImageToByte(Image img)
        {
            /*Convierte una imagen en un array de tipo Byte*/
            ImageConverter converter = new ImageConverter();
            /*Retorna la información*/
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            //Image returnImage = Image.FromStream(ms);
            return Image.FromStream(ms);
        }
    }
}
