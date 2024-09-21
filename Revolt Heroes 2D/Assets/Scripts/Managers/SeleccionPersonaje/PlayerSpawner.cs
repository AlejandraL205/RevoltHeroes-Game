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
        foreach (GameObject characterPrefab in characterPrefabs)
        {
            if (characterPrefab.name == player1Character)
            {
                Instantiate(characterPrefab, new Vector3(-1, 0, 0), Quaternion.identity); // Instancia el personaje 1 en una posición específica
                break;
            }
        }

        // Instanciar el personaje del jugador 2, si existe
        string player2Character = PlayerStorage.player2Character;
        if (!string.IsNullOrEmpty(player2Character))
        {
            foreach (GameObject characterPrefab in characterPrefabs)
            {
                if (characterPrefab.name == player2Character)
                {
                    Instantiate(characterPrefab, new Vector3(1, 0, 0), Quaternion.identity); // Instancia el personaje 2 en otra posición
                    break;
                }
            }
        }
    }
}
