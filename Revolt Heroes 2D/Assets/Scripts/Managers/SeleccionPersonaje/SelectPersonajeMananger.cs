using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPersonajeManager : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        // Verificamos si el jugador 1 ha seleccionado un personaje
        if (!string.IsNullOrEmpty(PlayerStorage.player1Character))
        {
            // Solo cargamos el nivel si hay un jugador 1 seleccionado
            SceneManager.LoadScene("Nivel 1");
        }
        else
        {
            Debug.LogWarning("No se ha seleccionado ningún personaje.");
        }
    }
}
