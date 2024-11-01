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
using System.Windows.Shapes;
using ProjetoEscola.Views;

using Microsoft.Win32;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Diagnostics;

using ProjetoEscola.Helpers;


namespace ProjetoEscola
{
    /// <summary>
    /// Lógica interna para InicialWindow.xaml
    /// </summary>
    public partial class InicialWindow : Window
    {
        public InicialWindow()
        {
            InitializeComponent();
            Loaded += InicialWindow_Loaded;
        }

        private void InicialWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SessionHelper.Login("joao@ifro.edu.br", "joao1234");
            txtUserLogado.Text = SessionHelper.GetUsuario().Email;
        }

        private void Button_Menu_Click(object sender, RoutedEventArgs e)
        {
            //if (SessionHelper.Login("joao@ifro.edu.br", "joao1234"))
            //{
            //    MessageBox.Show("Login Okay");
            //} else
            //{
            //    MessageBox.Show("Login Ñ Okay");
            //}


            //MessageBox.Show("User: " + SessionHelper.GetNome());


            Button button = sender as Button;
            Window window;

            switch (button.Name)
            {
               case "MN_C_Curso":
                   window = new CursoFormWindow();
                   window.ShowDialog();
                   break;

               case "MN_L_Curso":
                   window = new CursoListWindow();
                   window.ShowDialog();
                   break;

               case "MN_C_Escola":
                   window = new EscolaFormWindow();
                   window.ShowDialog();
                   break;

               case "MN_L_Escola":
                   window = new EscolaListWindow();
                   window.ShowDialog();
                   break;
            }
        }

        private void Button_SendImage_Click(object sender, RoutedEventArgs e)
        {

            var pathImg = UploadFileHelper.Image("Images", true);
            MessageBox.Show(pathImg);
            imgPhoto.Source = UploadFileHelper.LoadImage(pathImg);
        }

        private string generatePassword(int length)
        {
            var addUpperCase = true;
            var addNumbers = true;
            var addSymbols = false;
            string validChars;

            // Check what checkboxes are ticked
            if (addUpperCase && addNumbers && addSymbols)
            {
                validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890?!@#$%^&*";
            }
            else if (addUpperCase && addNumbers)
            {
                validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            }
            else if (addUpperCase && addSymbols)
            {
                validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ?!@#$%^&*";
            }
            else if (addNumbers && addSymbols)
            {
                validChars = "abcdefghijklmnopqrstuvwxyz1234567890?!@#$%^&*";
            }
            else if (addUpperCase)
            {
                validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }
            else if (addNumbers)
            {
                validChars = "abcdefghijklmnopqrstuvwxyz1234567890";
            }
            else if (addSymbols)
            {
                validChars = "abcdefghijklmnopqrstuvwxyz?!@#$%^&*";
            }
            else
            {
                validChars = "abcdefghijklmnopqrstuvwxyz";
            }

            // Generate password
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(validChars[rnd.Next(validChars.Length)]);
            }
            return res.ToString();
        }
    }
}
