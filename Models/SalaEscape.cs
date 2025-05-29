namespace TP05.Models;

public class SalaEscape
{
    private int EstadoJuego=1;
    private string[] Respuestas = new string[4] {"1001","7","NM","D"}; 
    public int Respuesta(string input, int sala)
    {
        if (sala > EstadoJuego){

            if (input == Respuestas[sala])
            {
                EstadoJuego++;
                return 1;
            }
            else
            {
                return 2;
            }

        }
        else{

            return 3;

        }
    }
}