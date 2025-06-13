namespace TP05.Models;
using Newtonsoft.Json;

public class SalaEscape
{
    [JsonProperty]
    public int Nota { get; private set; } = 10;

    [JsonProperty]
    public int Notificaciones = 0;
    [JsonProperty]
    private int EstadoJuego=1;
    [JsonProperty]
    private string[] Respuestas = new string[4] {"1001","7","ok","NM"}; 
    public int Respuesta(string input, int sala)
    {
        if (sala + 1 >= EstadoJuego){

            if (input == Respuestas[sala])
            {
                EstadoJuego++;
                return 1;
            }
            else
            {
                Nota--;
                return 2;
            }

        }
        else{

            return 3;

        }
    }
}