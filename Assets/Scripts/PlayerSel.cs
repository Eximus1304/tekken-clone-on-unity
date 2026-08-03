using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public static int player1Character = -1;
    public static int player2Character = -1;

    // ---------- PLAYER 1 ----------

    public void P1DevilJin()
    {
        player1Character = 0;
        Debug.Log("P1 selected Devil Jin");
    }

    public void P1Yakuza()
    {
        player1Character = 1;
        Debug.Log("P1 selected Yakuza Guy");
    }

    public void P1Shaktimaan()
    {
        player1Character = 2;
        Debug.Log("P1 selected Shaktimaan");
    }

    public void P1Modinho()
    {
        player1Character = 3;
        Debug.Log("P1 selected Modinho");
    }

    // ---------- PLAYER 2 ----------

    public void P2DevilJin()
    {
        player2Character = 0;
        Debug.Log("P2 selected Devil Jin");
    }

    public void P2Yakuza()
    {
        player2Character = 1;
        Debug.Log("P2 selected Yakuza Guy");
    }

    public void P2Shaktimaan()
    {
        player2Character = 2;
        Debug.Log("P2 selected Shaktimaan");
    }

    public void P2Modinho()
    {
        player2Character = 3;
        Debug.Log("P2 selected Modinho");
    }
    public void ContinueToMapSelection()
    {
        if (player1Character == -1 || player2Character == -1)
        {
            Debug.Log("Both players must select a character!");
            return;
        }

        SceneManager.LoadScene("MapSelection");
    }
}