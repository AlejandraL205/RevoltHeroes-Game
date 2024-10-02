using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{
    public Button[] characterButtons; // Botones de selecci�n de personajes
    public int currentPlayer = 1; // 1 para jugador 1 (por defecto)

    void Start()
    {
        foreach (Button button in characterButtons)
        {
            // Asigna la funci�n de selecci�n usando una funci�n an�nima (lambda)
            button.onClick.AddListener(() => OnCharacterSelected(button.name)); // button.name pasar� el nombre del personaje
        }
    }

    void OnCharacterSelected(string characterName)
    {
        PlayerStorage.SetCharacter(currentPlayer, characterName); 
        Debug.Log($"Jugador {currentPlayer} seleccion�: {characterName}");
    }

    // Llama a este m�todo cuando cambie de jugador
    public void SetCurrentPlayer(int player)
    {
        currentPlayer = player;
    }
}
