using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{
    public Button[] characterButtons; // Botones de selecci�n de personajes
    public int currentPlayer; // 1 para jugador 1, 2 para jugador 2

    void Start()
    {
        foreach (Button button in characterButtons)
        {
            button.onClick.AddListener(() => OnCharacterSelected(button.name)); // Asigna la funci�n de selecci�n
        }
    }

    void OnCharacterSelected(string characterName)
    {
        PlayerStorage.SetCharacter(currentPlayer, characterName); // Guarda el personaje seleccionado
        Debug.Log($"Jugador {currentPlayer} seleccion�: {characterName}");
    }

    // Llama a este m�todo cuando cambie de jugador
    public void SetCurrentPlayer(int player)
    {
        currentPlayer = player;
    }
}
