using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPersonajeManager : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        // Verifica cuántos jugadores hay
        if (!string.IsNullOrEmpty(PlayerStorage.player1Character))
        {
            if (string.IsNullOrEmpty(PlayerStorage.player2Character))
            {
                // Si solo hay un jugador
                PlayerSpawner playerSpawner = FindObjectOfType<PlayerSpawner>();
                playerSpawner.SpawnCharacter(); // Spawnea el personaje
                SceneManager.LoadScene("Nivel 1"); // Carga la escena
            }
            else
            {
                // Si hay dos jugadores
                PlayerSpawner playerSpawner = FindObjectOfType<PlayerSpawner>();
                playerSpawner.SpawnCharacter(); // Spawnea los personajes
                SceneManager.LoadScene("Nivel 1"); // Carga la escena
            }
        }
        else
        {
            Debug.LogWarning("No se ha seleccionado ningún personaje.");
        }
    }
}
