using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa; // Botón para pausar
    [SerializeField] private GameObject menuPausa;   // Menú de pausa

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
        menuPausa.SetActive(true); // Muestra el menú de pausa
        botonPausa.SetActive(false); // Oculta el botón de pausa
        isPaused = true; // Cambia el estado a pausado
    }

    public void Reanudar()
    {
        Time.timeScale = 1f; // Reanuda el tiempo
        menuPausa.SetActive(false); // Oculta el menú de pausa
        botonPausa.SetActive(true); // Muestra el botón de pausa
        isPaused = false; // Cambia el estado a no pausado
    }

    // Método para reiniciar el nivel actual
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    // Método para salir a la página de inicio
    public void Salir()
    {
        // Cargar la escena de inicio
        UnityEngine.SceneManagement.SceneManager.LoadScene("Home");
    }
}
