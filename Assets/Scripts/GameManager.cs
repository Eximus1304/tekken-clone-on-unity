using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject charSelectUI;
    public GameObject healthBarsUI;

    [Header("Fighters")]
    public GameObject player1;
    public GameObject player2;

    private int p1CharacterIndex = -1;
    private int p2CharacterIndex = -1;

    void Start()
    {
        // Start in Character Selection mode
        if (charSelectUI != null) charSelectUI.SetActive(true);
        if (healthBarsUI != null) healthBarsUI.SetActive(false);

        // Optionally disable fighters during character selection
        if (player1 != null) player1.SetActive(false);
        if (player2 != null) player2.SetActive(false);
    }

    // Call this from your P1 selection buttons in UI
    public void SelectPlayer1Character(int characterID)
    {
        p1CharacterIndex = characterID;
        CheckSelectionComplete();
    }

    // Call this from your P2 selection buttons in UI
    public void SelectPlayer2Character(int characterID)
    {
        p2CharacterIndex = characterID;
        CheckSelectionComplete();
    }

    private void CheckSelectionComplete()
    {
        // Wait until both players have made a selection
        if (p1CharacterIndex != -1 && p2CharacterIndex != -1)
        {
            StartMatch();
        }
    }

    private void StartMatch()
    {
        // Hide character selection screen
        if (charSelectUI != null) charSelectUI.SetActive(false);

        // Enable HUD / Gameplay UI
        if (healthBarsUI != null) healthBarsUI.SetActive(true);

        // Enable fighters
        if (player1 != null) player1.SetActive(true);
        if (player2 != null) player2.SetActive(true);

        Debug.Log($"Match Started: P1 Selected ID {p1CharacterIndex}, P2 Selected ID {p2CharacterIndex}");
    }
}