using System;
using Microsoft.Maui.Controls;

namespace IMC.Contador
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void CalcularButton_Clicked(object sender, EventArgs e)
        {
            if (!double.TryParse(PesoEntry.Text, out double peso) || peso <= 0)
            {
                ResultadoLabel.Text = "Por favor, ingresa un peso válido. ";
                return;
            }
            if (!double.TryParse(EstaturaEntry.Text, out double estatura) || estatura <= 0)
            {
                ResultadoLabel.Text = "Por favor, ingresa una estatura válida. ";
            }

            double imc = peso / (estatura * estatura);

            string estado;
            if (imc < 18.5)
            {
                estado = "Bajo peso";
            }
            else if (imc < 25)
            {
                estado = "Normal";
            }
            else if (imc < 30)
            {
                estado = "Sobrepeso";
            }
            else
            {
                estado = "Obesidad";
            }

            ResultadoLabel.Text = $"Su IMC es {imc:F2}\nEstado nutricional: {estado}";

        }

        private void LimpiarButton_Clicked(object sender, EventArgs e)
        {
            PesoEntry.Text = "";
            EstaturaEntry.Text = "";
            ResultadoLabel.Text = "";
        }
    }
}
