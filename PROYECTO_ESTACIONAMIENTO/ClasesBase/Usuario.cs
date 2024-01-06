using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class Usuario: INotifyPropertyChanged
    {
        private int user_id;
        public int User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        private string userName;

        public string UserName  
        {
            get { return userName; }
            set { userName = value;
            OnPropertyChanged("UserName");
            }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value;
            OnPropertyChanged("Password");
            }
        }
        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value;
            OnPropertyChanged("Apellido");
            }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value;
            OnPropertyChanged("Nombre");
            }
        }
        private string rol;

        public string Rol
        {
            get { return rol; }
            set { rol = value;
            OnPropertyChanged("Rol");
            }
        }

        public Usuario()
        {
           
        }

        public Usuario(string userName,string password,string nombre,string apellido,string rol) {
            this.UserName = userName;
            this.Password = password;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Rol = rol;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string info)
        {
          
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(info));
            }
        }
    }
}
