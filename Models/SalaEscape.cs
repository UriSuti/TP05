namespace TP05.Models;
using Newtonsoft.Json;

public class SalaEscape
{
    public int Nota = 10;
    public int Notificaciones = 0;
    [JsonProperty]
    private int EstadoJuego=1;
    [JsonProperty]
    private string[] Respuestas = new string[4] {"1001","7","ok", "jessi"}; 
    public int Respuesta(string input, int sala)
    {
        if (sala + 1 >= EstadoJuego || sala==4){

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