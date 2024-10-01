using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStorage : MonoBehaviour
{
    public static string player1Character; // Almacena el personaje del jugador 1
    public static string player2Character; // Almacena el personaje del jugador 2

    public static void SetCharacter(int playerIndex, string characterName)
    {
        if (playerIndex == 1)
        {
            player1Character = characterName; // Guarda el personaje del jugador 1
        }
        else if (playerIndex == 2)
        {
            player2Character = characterName; // Guarda el personaje del jugador 2
        }
    }

    // Método para resetear los personajes seleccionados (Opcional)
    public static void ResetCharacters()
    {
        player1Character = null;
        player2Character = null;
    }
}
