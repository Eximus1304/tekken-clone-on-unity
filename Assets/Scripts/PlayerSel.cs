using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject p1SelectPanel;
    [SerializeField] private GameObject p2SelectPanel;

    [Header("P1 Display Objects")]
    [SerializeField] private GameObject p1Jin;
    [SerializeField] private GameObject p1Modinho;
    [SerializeField] private GameObject p1Yakuza;
    [SerializeField] private GameObject p1Shaktimaan;

    [Header("P2 Display Objects")]
    [SerializeField] private GameObject p2Jin;
    [SerializeField] private GameObject p2Modinho;
    [SerializeField] private GameObject p2Yakuza;
    [SerializeField] private GameObject p2Shaktimaan;

    // Static character selection indices (-1 = unselected)
    public static int player1Character = -1;
    public static int player2Character = -1;

    private void Start()
    {
        // Reset values on start
        player1Character = -1;
        player2Character = -1;

        // Ensure Player 1 screen is ACTIVE and Player 2 screen is INACTIVE at start
        if (p1SelectPanel != null) p1SelectPanel.SetActive(true);
        if (p2SelectPanel != null) p2SelectPanel.SetActive(false);

        // Hide all character previews initially
        HideAllPreviews();
    }

    // ---------- PLAYER 1 SELECTIONS ----------

    public void P1DevilJin() => SelectP1(0, p1Jin);
    public void P1Yakuza() => SelectP1(1, p1Yakuza);
    public void P1Shaktimaan() => SelectP1(2, p1Shaktimaan);
    public void P1Modinho() => SelectP1(3, p1Modinho);

    private void SelectP1(int characterIndex, GameObject targetSprite)
    {
        player1Character = characterIndex;
        Debug.Log($"P1 selected character index: {characterIndex}");

        // Hide previous preview objects and activate the selected character's visual representation
        HideP1Previews();
        if (targetSprite != null) targetSprite.SetActive(true);

        // Automatically transition to Player 2's selection panel
        TransitionToPlayer2();
    }

    private void TransitionToPlayer2()
    {
        if (p1SelectPanel != null) p1SelectPanel.SetActive(false);
        if (p2SelectPanel != null) p2SelectPanel.SetActive(true);
    }

    // ---------- PLAYER 2 SELECTIONS ----------

    public void P2DevilJin() => SelectP2(0, p2Jin);
    public void P2Yakuza() => SelectP2(1, p2Yakuza);
    public void P2Shaktimaan() => SelectP2(2, p2Shaktimaan);
    public void P2Modinho() => SelectP2(3, p2Modinho);

    private void SelectP2(int characterIndex, GameObject targetSprite)
    {
        player2Character = characterIndex;
        Debug.Log($"P2 selected character index: {characterIndex}");

        // Hide previous preview objects and activate the selected character's visual representation
        HideP2Previews();
        if (targetSprite != null) targetSprite.SetActive(true);

        // Load scene automatically once both choices are confirmed
        ContinueToMapSelection();
    }

    public void ContinueToMapSelection()
    {
        if (player1Character == -1 || player2Character == -1)
        {
            Debug.LogWarning("Both players must select a character before proceeding!");
            return;
        }

        SceneManager.LoadScene("MapSelection");
    }

    // ---------- HELPER METHODS ----------

    private void HideP1Previews()
    {
        if (p1Jin != null) p1Jin.SetActive(false);
        if (p1Modinho != null) p1Modinho.SetActive(false);
        if (p1Yakuza != null) p1Yakuza.SetActive(false);
        if (p1Shaktimaan != null) p1Shaktimaan.SetActive(false);
    }

    private void HideP2Previews()
    {
        if (p2Jin != null) p2Jin.SetActive(false);
        if (p2Modinho != null) p2Modinho.SetActive(false);
        if (p2Yakuza != null) p2Yakuza.SetActive(false);
        if (p2Shaktimaan != null) p2Shaktimaan.SetActive(false);
    }

    private void HideAllPreviews()
    {
        HideP1Previews();
        HideP2Previews();
    }
}