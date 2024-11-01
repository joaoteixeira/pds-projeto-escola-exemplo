using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using ProjetoEscola.Models;

namespace ProjetoEscola.Views
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class EscolaFormWindow : Window
    {
        private Escola _escola = new Escola();

        public EscolaFormWindow()
        {
            InitializeComponent();
            Loaded += EscolaFormWindow_Loaded;
        }

        public EscolaFormWindow(Escola escola)
        {
            InitializeComponent();
            _escola = escola;

            Loaded += EscolaFormWindow_Loaded;
        }

        private void EscolaFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
           
            txtNomeFantasia.Text = _escola.NomeFantasia;
            txtRazaoSocial.Text = _escola.RazaoSocial;
            txtCNPJ.Text = _escola.Cnpj;
            txtInscEstudal.Text = _escola.InscEstadual;

            if (_escola.Tipo == "Pública")
            {
                rdTipoPublica.IsChecked = true;
            } else
            {
                rdTipoPrivada.IsChecked = true;
            }

        }
        
        /*
         *  Método para salvar as informações do Formulário
         *  Verifica se o atribuito Id de Escola for maior que 0
         *  então chama o dao.Update, caso contrário chama o 
         *  dao.Insert.
         */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            _escola.NomeFantasia = txtNomeFantasia.Text;
            _escola.RazaoSocial = txtRazaoSocial.Text;
            _escola.Cnpj = txtCNPJ.Text;
            _escola.DataCriacao = dtCriacao.SelectedDate;
            _escola.Tipo = "Pública";

            if ((bool)rdTipoPrivada.IsChecked)
                _escola.Tipo = "Privada";

            try
            {
                var dao = new EscolaDAO();

                if (_escola.Id > 0)
                {
                    dao.Update(_escola);
                    MessageBox.Show("Registro de escola atualizado com sucesso.");
                } else
                {
                    dao.Insert(_escola);
                    MessageBox.Show("Registro de escola cadastrado com sucesso.");
                }

                this.Close();

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }

            

        }
    }
}
