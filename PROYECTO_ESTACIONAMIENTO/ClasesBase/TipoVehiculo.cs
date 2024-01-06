using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class TipoVehiculo : IDataErrorInfo
    {
        public int TvCodigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Tarifa { get; set; }
        public string UrlImagen { get; set; }

        public TipoVehiculo()
        {
        }

        public TipoVehiculo(int tvCodigo, string descripcion, decimal tarifa, string urlImagen)
        {
            this.TvCodigo = tvCodigo;
            this.Descripcion = descripcion;
            this.Tarifa = tarifa;
            this.UrlImagen = urlImagen;
        }

        public TipoVehiculo(int tvCodigo, string descripcion, decimal tarifa)
        {
            this.TvCodigo = tvCodigo;
            this.Descripcion = descripcion;
            this.Tarifa = tarifa;
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "TvCodigo")
                {
                    if (TvCodigo == 0)
                        result = "Ingrese Codigo";
                    else if (TvCodigo.ToString().Length < 3)
                        result = "Debe ingresar al menos 3 caracteres";
                }
                else if (columnName == "Descripcion")
                {
                    if (string.IsNullOrEmpty(Descripcion))
                        result = "Ingrese Descripcion";
                    else if (Descripcion.Length < 3)
                        result = "Debe ingresar al menos 3 caracteres";
                }
                else if (columnName == "Tarifa")
                {
                    if (Tarifa == 0)
                        result = "Ingrese Tarifa";
                    else if (Tarifa < 10)
                        result = "Debe ingresar al menos dos dígitos";
                }

                return result;
            }
        }
        public override string ToString()
        {
            return string.Format("Código: {0}\nDescripción: {1}\nTarifa: {2:C}\nUrlImagen: {3}", TvCodigo, Descripcion, Tarifa, UrlImagen);
        }
    }
}
