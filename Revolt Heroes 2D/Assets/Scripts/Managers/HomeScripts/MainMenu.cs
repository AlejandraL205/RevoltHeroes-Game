using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // M�todo para iniciar el juego en un jugador
    public void JugarUnJugador()
    {
        SceneManager.LoadScene("ElegirJugador");
    }

    // M�todo para iniciar el juego en dos jugadores
    public void JugarDosJugadores()
    {
        SceneManager.LoadScene("ElegirJugador");
        // Aqu� puedes agregar l�gica adicional si hay diferencias entre los modos
    }

    // M�todo para ir a la escena de Opciones
    public void IrAOpciones()
    {
        SceneManager.LoadScene("Opciones");
    }

    // M�todo para salir del juego
    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
