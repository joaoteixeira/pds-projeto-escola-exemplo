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
    public partial class CursoFormWindow : Window
    {
        private Curso _curso = new Curso();

        public CursoFormWindow()
        {
            InitializeComponent();
            Loaded += CursoFormWindow_Loaded;
        }

        public CursoFormWindow(Curso curso)
        {
            InitializeComponent();
            _curso = curso;

            Loaded += CursoFormWindow_Loaded;
        }

        private void CursoFormWindow_Loaded(object sender, RoutedEventArgs e)
        {

                     
        }

        /*
         *  Método para salvar as informações do Formulário
         *  Verifica se o atribuito Id de Escola for maior que 0
         *  então chama o dao.Update, caso contrário chama o 
         *  dao.Insert.
         */
        private void Button_Salvar_Click(object sender, RoutedEventArgs e)
        {

            _curso.Nome = txtNome.Text;
            _curso.CargaHoraria = txtCargaHoraria.Text;
            _curso.Descricao = txtDescricao.Text;

            if(cmbTurno.SelectedItem != null)
            {
                var item = cmbTurno.SelectedValue as ComboBoxItem;
                _curso.Turno = item.Content.ToString();
            }

            if(cmbEscola.SelectedItem != null)
            {
                //_curso.Escola = cmbEscola.SelectedItem as Escola;
            }

            try
            {
                var dao = new CursoDAO();

                if (_curso.Id > 0)
                {
                    dao.Update(_curso);
                    MessageBox.Show("Registro atualizado com sucesso.");
                } else
                {
                    dao.Insert(_curso);
                    MessageBox.Show("Registro cadastrado com sucesso.");
                }

                this.Close();

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }

            

        }
    }
}
