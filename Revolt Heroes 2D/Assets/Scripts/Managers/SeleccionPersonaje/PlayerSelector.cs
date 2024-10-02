using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{
    public Button[] characterButtons; // Botones de selección de personajes
    public int currentPlayer = 1; // 1 para jugador 1 (por defecto)

    void Start()
    {
        foreach (Button button in characterButtons)
        {
            // Asigna la función de selección usando una función anónima (lambda)
            button.onClick.AddListener(() => OnCharacterSelected(button.name)); // button.name pasará el nombre del personaje
        }
    }

    void OnCharacterSelected(string characterName)
    {
        PlayerStorage.SetCharacter(currentPlayer, characterName); 
        Debug.Log($"Jugador {currentPlayer} seleccionó: {characterName}");
    }

    // Llama a este método cuando cambie de jugador
    public void SetCurrentPlayer(int player)
    {
        currentPlayer = player;
    }
}
