using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] characterPrefabs; // Prefabs de personajes

    public void SpawnCharacter()
    {
        // Instanciar el personaje del jugador 1
        string player1Character = PlayerStorage.player1Character;
        SpawnPlayer(player1Character, new Vector3(-1, 0, 0)); // Posición del jugador 1

        // Instanciar el personaje del jugador 2, si existe
        string player2Character = PlayerStorage.player2Character;
        if (!string.IsNullOrEmpty(player2Character))
        {
            SpawnPlayer(player2Character, new Vector3(1, 0, 0)); // Posición del jugador 2
        }
    }

    private void SpawnPlayer(string characterName, Vector3 spawnPosition)
    {
        foreach (GameObject characterPrefab in characterPrefabs)
        {
            if (characterPrefab.name == characterName)
            {
                Instantiate(characterPrefab, spawnPosition, Quaternion.identity); // Instancia el personaje en la posición específica
                break;
            }
        }
    }
}
