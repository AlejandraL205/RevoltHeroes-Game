using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // M�todo para iniciar el juego en un jugador
    public void JugarUnJugador()
    {
        SceneManager.LoadScene("ElegirJugador"); // Lleva a la selecci�n de personaje
    }

    // M�todo para iniciar el juego en dos jugadores
    public void JugarDosJugadores()
    {
        // Seteamos personajes por defecto para los dos jugadores
        PlayerStorage.SetCharacter(1, "Personaje1");
        PlayerStorage.SetCharacter(2, "Personaje2");

        // Carga directamente la escena del nivel 1
        SceneManager.LoadScene("Nivel 1");
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
