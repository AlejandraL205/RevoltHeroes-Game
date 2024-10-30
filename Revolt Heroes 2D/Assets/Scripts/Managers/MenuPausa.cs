using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa; // Bot�n para pausar
    [SerializeField] private GameObject menuPausa;   // Men� de pausa

    private bool isPaused = false; // Estado del juego

    void Start()
    {
        menuPausa.SetActive(false);
    }

    public void TogglePausa()
    {
        if (isPaused)
        {
            Reanudar();
        }
        else
        {
            Pausa();
        }
    }

    public void Pausa()
    {
        Time.timeScale = 0f; // Pausa el tiempo
        menuPausa.SetActive(true); // Muestra el men� de pausa
        botonPausa.SetActive(false); // Oculta el bot�n de pausa
        isPaused = true; // Cambia el estado a pausado
    }

    public void Reanudar()
    {
        Time.timeScale = 1f; // Reanuda el tiempo
        menuPausa.SetActive(false); // Oculta el men� de pausa
        botonPausa.SetActive(true); // Muestra el bot�n de pausa
        isPaused = false; // Cambia el estado a no pausado
    }

    // M�todo para reiniciar el nivel actual
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    // M�todo para salir a la p�gina de inicio
    public void Salir()
    {
        // Cargar la escena de inicio
        UnityEngine.SceneManagement.SceneManager.LoadScene("Home");
    }
}
