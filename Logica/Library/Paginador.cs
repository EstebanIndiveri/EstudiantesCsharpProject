using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica.Library
{
    public class Paginador<T>
    {
        private List<T> _dataList;

        private Label _label;
        private static int maxReg, _reg_por_pagina, pageCount, numPag = 1;

        public Paginador(List<T> dataList,Label label, int reg_por_pagina)
        {
            _dataList = dataList;
            _label = label;
            _reg_por_pagina = reg_por_pagina;
            cargarDatos();
        }
        private void cargarDatos()
        {
            numPag = 1;
            maxReg = _dataList.Count;
            pageCount = (maxReg / _reg_por_pagina);
            //Residuo, si sobra un registro en la pagina
            if ((maxReg % _reg_por_pagina) > 0)
            {
                pageCount += 1;
            }
            _label.Text = $"Paginas 1 / {pageCount}";
        }
        public int primero()
        {
            numPag = 1;
            _label.Text = $"Paginas{numPag}/{pageCount}";
            return numPag;
        }
        public int anterior()
        {
            if (numPag > 1)
            {
                numPag -= 1;
                _label.Text = $"Paginas {numPag}/{pageCount}";
            }
            return numPag;
        }
        public int Siguiente()
        {
            if (numPag == pageCount)
            
                numPag -= 1;
                if (numPag < pageCount)
                {
                    numPag += 1;
                    _label.Text = $"Paginas {numPag}/{pageCount}";
                }
                return numPag;
        }
        public int ultimo()
        {
            numPag = pageCount;
            _label.Text = $"Paginas {numPag}/{pageCount}";
            return numPag;
        }
    }

}
