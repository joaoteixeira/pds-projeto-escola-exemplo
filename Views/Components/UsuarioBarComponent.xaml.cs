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
using ProjetoEscola.Helpers;

namespace ProjetoEscola.Views.Components
{
    /// <summary>
    /// Interação lógica para UsuarioBarComponent.xam
    /// </summary>
    public partial class UsuarioBarComponent : UserControl
    {
        public UsuarioBarComponent()
        {
            InitializeComponent();
            Loaded += UsuarioBarComponent_Loaded;
        }

        private void UsuarioBarComponent_Loaded(object sender, RoutedEventArgs e)
        {
            var user = SessionHelper.GetUsuario();
            textNome.Text = user.Nome;
            textPerfil.Text = user.Perfil;
            imgBrush.ImageSource = UploadFileHelper.LoadImage(user.Image);
        }
    }
}
