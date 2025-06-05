namespace TP05.Models;
using Newtonsoft.Json;

public class SalaEscape
{
    [JsonProperty]
    private int EstadoJuego=1;
    [JsonProperty]
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