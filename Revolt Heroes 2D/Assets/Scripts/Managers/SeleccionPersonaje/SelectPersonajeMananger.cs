using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPersonajeManager : MonoBehaviour
{
    public string defaultCharacter = "Leo"; // Nombre del personaje por defecto

    public void OnPlayButtonClicked()
    {
        // Si no se ha seleccionado ningún personaje, asignar Leo por defecto
        if (string.IsNullOrEmpty(PlayerStorage.player1Character))
        {
            Debug.Log("No se ha seleccionado personaje, asignando Leo como personaje por defecto.");
            PlayerStorage.SetCharacter(1, defaultCharacter); // Selecciona Leo como personaje por defecto
        }

        // Cargar la escena del nivel solo si hay un personaje seleccionado
        SceneManager.LoadScene("Nivel 1");
    }
}
