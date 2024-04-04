using Microsoft.Maui.Controls;
using System;

namespace pruebaahorcado
{
    public partial class MainPage : ContentPage
    {
        private Random random = new Random();
        private int num1, num2, resultadoCorrecto;
        private int intentos = 0;
        private const int maxIntentos = 6;

        public MainPage()
        {
            InitializeComponent();

            resultado.IsEnabled = false;
            button2.IsEnabled = false;
            numero1.IsEnabled = false;
            numero2.IsEnabled = false;

            button1.Clicked += Button1_Click;
            button2.Clicked += Button2_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            LimpiarImagenes();
            resultado.IsEnabled = true;
            button2.IsEnabled = true;
            button1.IsEnabled = false;
            intentos = 0; 

            GenerarOperacion();
        }

        private void GenerarOperacion()
        {
            num1 = random.Next(1, 11);
            num2 = random.Next(1, 11);

            numero1.Text = num1.ToString();
            numero1.IsEnabled = false;

            numero2.Text = num2.ToString();
            numero2.IsEnabled = false;

            resultado.Text = "";
            resultadoCorrecto = num1 * num2;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (intentos >= maxIntentos)
            {
                DisplayAlert("Alert", "Has alcanzado el máximo de intentos", "OK");
                button1.IsEnabled = true;
                return;
            }

            if (int.TryParse(resultado.Text, out int resultadoIngresado))
            {
                if (resultadoIngresado == resultadoCorrecto)
                {
                    DisplayAlert("Correcto", "¡El resultado es correcto!", "OK");
                }
                else
                {
                    DisplayAlert("Incorrecto", $"El resultado es {resultadoCorrecto}.", "OK");
                    intentos++;

                    MostrarImagen(intentos);
                }

                if (intentos >= maxIntentos)
                {
                    DisplayAlert("Alert", "¡Se acabaron los intentos!", "OK");
                    button2.IsEnabled = false;
                    resultado.IsEnabled = false;

                    button1.IsEnabled = true;
                }
                else
                {
                    GenerarOperacion();
                }
            }

        }

        private void MostrarImagen(int intentos)
        {
            string nombreImagen;
            switch (intentos)
            {
                case 1:
                    nombreImagen = "perdio1.png";
                    break;
                case 2:
                    nombreImagen = "perdio2.png";
                    break;
                case 3:
                    nombreImagen = "perdio3.png";
                    break;
                case 4:
                    nombreImagen = "perdio4.png";
                    break;
                case 5:
                    nombreImagen = "perdio5.png";
                    break;
                case 6:
                    nombreImagen = "perdio6.png";
                    break;
                default:
                    nombreImagen = "base.png";
                    break;
            }
            imagen.Source = ImageSource.FromFile(nombreImagen); // Establecer la imagen en el control Image
        }

        private void LimpiarImagenes()
        {
            imagen.Source = null; // Limpiar la imagen
        }
    }
}
