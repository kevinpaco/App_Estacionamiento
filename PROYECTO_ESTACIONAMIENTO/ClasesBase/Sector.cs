using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Sector
    {
        private int sec_id;
        private int sectorCodigo;
        private String descripcion;
        private String identificador;
        private bool habilitado;
        private int estado;

        public bool Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }

        public String Identificador
        {
            get { return identificador; }
            set { identificador = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int SectorCodigo
        {
            get { return sectorCodigo; }
            set { sectorCodigo = value; }
        }

        public int Sec_id
        {
            get { return sec_id; }
            set { sec_id = value; }
        }

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
