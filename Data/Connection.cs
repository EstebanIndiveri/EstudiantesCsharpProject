using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Connection : DataConnection
    {
        public Connection() : base("SistEstudiantes") { }
        
        public ITable<Estudiante> _Estudiante { get { return GetTable<Estudiante>(); } }
        

    }
}
