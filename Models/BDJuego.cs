public static class BDJuego
{
private static Dictionary<string, (string pregunta, string respuestaCorrecta, bool respondido)> estado = new Dictionary<string, (string, string, bool)>();
    public static void GuardarPreguntaActiva(string token, string pregunta)
    {
        estado[token] = (pregunta, "clave primaria compuesta", false);
    }

    public static bool ValidarRespuesta(string token, string respuesta)
    {
        if (estado.ContainsKey(token) && respuesta.ToLower() == estado[token].respuestaCorrecta.ToLower())
        {
            estado[token] = (estado[token].pregunta, estado[token].respuestaCorrecta, true);
            return true;
        }
        return false;
    }

    public static bool FueRespondidoCorrectamente(string token)
    {
        if (string.IsNullOrEmpty(token) || estado == null)
            return false;

        return estado.ContainsKey(token) && estado[token].respondido;
    }
}
