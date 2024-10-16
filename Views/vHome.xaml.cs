namespace jdiazT2B.Views;

public partial class vHome : ContentPage
{
	public vHome()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		    try
            {
                // Obtener los valores de las entradas
                string nombre = NombreE.Text;
                double seguimiento1 = double.Parse(Seguimiento1.Text);
                double examen1 = double.Parse(Examen1.Text);
                double seguimiento2 = double.Parse(Seguimiento2.Text);
                double examen2 = double.Parse(Examen2.Text);
                DateTime fecha = FechaPicker.Date;

                // Validar que las notas están en el rango correcto
                if (!ValidarNotas(seguimiento1, examen1, seguimiento2, examen2))
                {
                    DisplayAlert("Error", "Las notas deben estar entre 0 y 10.", "OK");
                    return;
                }

                // Calcular las notas parciales
                double notaParcial1 = (seguimiento1 * 0.3) + (examen1 * 0.2);
                double notaParcial2 = (seguimiento2 * 0.3) + (examen2 * 0.2);
                double notaFinal = notaParcial1 + notaParcial2;

                // Determinar el estado
                string estado = ObtenerEstado(notaFinal);

                // Mostrar los resultados
                ResultadoLabel.Text = $"Nombre: {nombre}\nFecha: {fecha.ToShortDateString()}\n" +
                                      $"Nota Parcial 1: {notaParcial1:F2}\n" +
                                      $"Nota Parcial 2: {notaParcial2:F2}\n" +
                                      $"Nota Final: {notaFinal:F2}\n" +
                                      $"Estado: {estado}";
                ResultadoLabel.IsVisible = true;
            }
            catch (FormatException)
            {
                DisplayAlert("Error", "Por favor, ingresa valores numéricos válidos.", "OK");
            }
    }

        private bool ValidarNotas(params double[] notas)
        {
            foreach (var nota in notas)
            {
                if (nota < 0 || nota > 10)
                {
                    return false;
                }
            }
            return true;
        }

        private string ObtenerEstado(double notaFinal)
        {
            if (notaFinal >= 7)
                return "Aprobado";
            else if (notaFinal >= 5)
                return "Complementario";
            else
                return "REPROBADO";
        }
    
}