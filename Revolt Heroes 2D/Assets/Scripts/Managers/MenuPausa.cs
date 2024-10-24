using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;

    public void Pausa ()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        botonPausa.SetActive(true);
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        botonPausa.SetActive(false);
    }

    // Método para reiniciar el nivel actual
    public void Reiniciar()
    {
        Time.timeScale = 1f; 
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    // Método para salir del juego
    public void Salir()
    {
        Application.Quit(); // Cierra la aplicación (no funcionará en el editor de Unity)
    }

}
