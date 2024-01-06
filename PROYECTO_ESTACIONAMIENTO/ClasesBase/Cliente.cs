using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Cliente:IDataErrorInfo
    {
        private int clienteDni;

        public int ClienteDni
        {
            get { return clienteDni; }
            set { clienteDni = value; }
        }
        private String apellido;

        public String Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        private String nombre;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private String telefono;

        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public Cliente() { }

        public Cliente(int clienteDni, String nombre, String apellido,String telefono)
        {
            this.ClienteDni = clienteDni;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
        }

        public override string ToString()
        {
            return string.Format("Cliente: {0}, {1}, {2}, {3}", ClienteDni, Nombre, Apellido, Telefono);
        }


        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get {
                  string result=null;
                  if (columnName == "Nombre")
                  {
                      if (string.IsNullOrEmpty(Nombre))
                          result = "Ingrese Nombre";
                      else if (Nombre.Length < 3)
                          result = "Debe ingresar al menos 3 carracteres";
                  }
                  else if (columnName == "Apellido")
                  {
                      if (string.IsNullOrEmpty(Apellido))
                          result = "Ingrese Apellido";
                      else if (Apellido.Length < 3)
                          result = "Debe ingresar al menos 3 carracteres";
                  }
                  else if (columnName == "ClienteDni")
                  {
                      if (ClienteDni==0)
                          result = "Ingrese Dni";
                      else if (ClienteDni.ToString().Length < 8)
                          result = "Debe ingresar 8 dijitos";  
                  }
                  else if (columnName == "Telefono")
                  {
                      if (string.IsNullOrEmpty(Telefono))
                          result = "Ingrese Telefono";
                      else if (Telefono.Length < 10)
                          result = "Telefono Invalido";
                  }
                  return result;
            }
        }
    }
}
