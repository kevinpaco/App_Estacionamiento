using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vistas
{
    /// <summary>
    /// UserControl que proporciona campos de entrada para UserName y Password.
    /// </summary>
    public partial class UCLogin : UserControl
    {
        /// <summary>
        /// Obtiene o establece el valor del campo UserName.
        /// </summary>
        public string UserName
        {
            get { return txtUser.Text; }
            set { txtUser.Text = value; }
        }

        /// <summary>
        /// Obtiene o establece el valor del campo Password.
        /// </summary>
        public string Password
        {
            get { return txtPass.Password; }
            set { txtPass.Password = value; }
        }

        /// <summary>
        /// Constructor de la clase UCLogin.
        /// </summary>
        public UCLogin()
        {
            InitializeComponent();
        }
    }
}
