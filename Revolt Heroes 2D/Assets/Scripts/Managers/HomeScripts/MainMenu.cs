using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void EscenaJuego()
    {
        SceneManager.LoadScene("Nivel 1");
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
