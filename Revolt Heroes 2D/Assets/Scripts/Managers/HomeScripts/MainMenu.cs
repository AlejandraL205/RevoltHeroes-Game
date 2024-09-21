using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Método para iniciar el juego en un jugador
    public void JugarUnJugador()
    {
        SceneManager.LoadScene("ElegirJugador");
    }

    // Método para iniciar el juego en dos jugadores
    public void JugarDosJugadores()
    {
        SceneManager.LoadScene("ElegirJugador");
        // Aquí puedes agregar lógica adicional si hay diferencias entre los modos
    }

    // Método para ir a la escena de Opciones
    public void IrAOpciones()
    {
        SceneManager.LoadScene("Opciones");
    }

    // Método para salir del juego
    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
