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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for VistaPreviaDeImpresion.xaml
    /// </summary>
    public partial class VistaPreviaDeImpresion : Window
    {
        public VistaPreviaDeImpresion()
        {
            InitializeComponent();
        }

        private void bntPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pdlg = new PrintDialog();
            if (pdlg.ShowDialog() == true)
            {
                pdlg.PrintDocument(((IDocumentPaginatorSource)DocMain).DocumentPaginator, "Imprimir");
            }
        }

        private void filterUser(object sender, FilterEventArgs e)
        {
            // Implementa la lógica de filtrado aquí.
        }
    }
}
