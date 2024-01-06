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
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using ClasesBase;
using System.ComponentModel;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for WinUsuariosABM.xaml
    /// </summary>
    public partial class WinUsuariosABM : Window
    {
        public WinUsuariosABM()
        {
            InitializeComponent();
        }

        CollectionView Vista;
        private ObservableCollection<Usuario> listUsuarios;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
         //   MessageBox.Show("cargo");
          ObjectDataProvider odp =(ObjectDataProvider)this.Resources["list_user"];
            listUsuarios= odp.Data as ObservableCollection<Usuario>;
            Vista=(CollectionView)CollectionViewSource.GetDefaultView(cvs_content.DataContext);
        }

        private void ListUsuarios_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Si se agregó un nuevo usuario, recarga la ventana
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                this.Window_Loaded(this, new RoutedEventArgs());
            }

            // Si se eliminó un usuario, recarga la ventana
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                this.Window_Loaded(this, new RoutedEventArgs());
            }
        }

        private void ListUsuarios_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Si la propiedad que cambió es la colección de usuarios, recarga la ventana
            if (e.PropertyName == "Collection")
            {
                // Recarga la ventana
                this.Window_Loaded(this, new RoutedEventArgs());
            }
        }
      
        private void btnPrimero_Click(object sender, RoutedEventArgs e){
              Vista.MoveCurrentToFirst();
        }
       private void btnUltimo_Click(object sender, RoutedEventArgs e){
            Vista.MoveCurrentToLast();
        }
        private void btnSiguiente_Click(object sender, RoutedEventArgs e){
            Vista.MoveCurrentToNext();
            if(Vista.IsCurrentAfterLast)
                Vista.MoveCurrentToFirst();
        }
        private void btnAnterior_Click(object sender, RoutedEventArgs e){
            Vista.MoveCurrentToPrevious();
            if(Vista.IsCurrentBeforeFirst)
                Vista.MoveCurrentToLast();
        }
        
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            WinAltaUser ua = new WinAltaUser();
            ua.ShowDialog();
            if (ua.DialogResult == true) 
            {
                listUsuarios.Add(ua.usuario);
                Vista.MoveCurrentToLast();
                this.Window_Loaded(this,new RoutedEventArgs());
                // Suscríbete al evento CollectionChanged de la colección de usuarios
               // listUsuarios.CollectionChanged += ListUsuarios_CollectionChanged;
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Usuario usu = cargaruser();
            //MessageBox.Show("es: "+listUsuarios.Count);
            MessageBoxResult result=MessageBox.Show("Esta seguro de eliminar al Usuario?","Confirmar",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                foreach (Usuario u in listUsuarios) {
                    if (u.UserName.Equals(usu.UserName))
                    {
                        listUsuarios.Remove(u);
                        break;
                    }
                }
               UsuarioABM.eliminarusuario(usu.UserName);
             //   MessageBox.Show("es: "+usu.Nombre+","+usu.Apellido+","+usu.UserName+","+usu.Password+","+usu.Rol);
                Vista.MoveCurrentToFirst();
                this.Window_Loaded(this, new RoutedEventArgs());
             //   CollectionViewSource.GetDefaultView(cvs_content.DataContext).Refresh();
                // Suscríbete al evento CollectionChanged de la colección de usuarios
                 
            }
        }

        private Usuario cargaruser()
        {
            return new Usuario(tBkusu.Text,tBkPass.Text,tBkNom.Text,tBkApe.Text,tBkRol.Text);
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            WinModificarUser wmu = new WinModificarUser();
            Usuario userMod = cargaruser();
            Usuario us = UsuarioABM.buscarUnUsuario(tBkusu.Text);
            userMod.User_id = us.User_id;
            wmu.UserDatos(userMod);
            wmu.ShowDialog();
            
                if(wmu.DialogResult==true){
                    for (int i = 0; i <= listUsuarios.Count;i++){
                        if (listUsuarios[i].UserName.Equals(userMod.UserName)){

                            listUsuarios[i] = wmu.usuModificado;
                            break;
                        }
                    }
                    Vista.MoveCurrentToLast();
                    this.Window_Loaded(this,new RoutedEventArgs());

                }
        }
    }
}
