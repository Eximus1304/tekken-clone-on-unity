using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    [Header("Character Prefabs")]
    public GameObject devilJinPrefab;
    public GameObject yakuzaPrefab;
    public GameObject shaktimaanPrefab;
    public GameObject modinhoPrefab;

    [Header("Spawn Points")]
    public Transform p1Spawn;
    public Transform p2Spawn;

    [Header("Health Bars")]
    public Slider p1HealthBar;
    public Slider p2HealthBar;

    private GameObject p1;
    private GameObject p2;

    private Health p1Health;
    private Health p2Health;

    void Start()
    {
        SpawnCharacters();
    }

    void SpawnCharacters()
    {
        // Get selected characters
        GameObject p1Prefab =
            GetCharacterPrefab(CharacterSelection.player1Character);

        GameObject p2Prefab =
            GetCharacterPrefab(CharacterSelection.player2Character);

        if (p1Prefab == null || p2Prefab == null)
        {
            Debug.LogError("Character prefab is missing!");
            return;
        }

        // Spawn P1
        p1 = Instantiate(
            p1Prefab,
            p1Spawn.position,
            p1Spawn.rotation
        );

        // Spawn P2
        p2 = Instantiate(
            p2Prefab,
            p2Spawn.position,
            p2Spawn.rotation
        );

        Debug.Log("P1 spawned: " + p1.name);
        Debug.Log("P2 spawned: " + p2.name);

        // =========================
        // HEALTH
        // =========================

        p1Health = p1.GetComponentInChildren<Health>(true);
        p2Health = p2.GetComponentInChildren<Health>(true);

        if (p1Health == null)
        {
            Debug.LogError("P1 has no Health component!");
            return;
        }

        if (p2Health == null)
        {
            Debug.LogError("P2 has no Health component!");
            return;
        }

        // Connect health bars
        p1Health.healthBar = p1HealthBar;
        p2Health.healthBar = p2HealthBar;

        p1Health.currentHealth = p1Health.maxHealth;
        p2Health.currentHealth = p2Health.maxHealth;

        if (p1HealthBar != null)
        {
            p1HealthBar.maxValue = p1Health.maxHealth;
            p1HealthBar.value = p1Health.currentHealth;
        }

        if (p2HealthBar != null)
        {
            p2HealthBar.maxValue = p2Health.maxHealth;
            p2HealthBar.value = p2Health.currentHealth;
        }

        // =========================
        // P1 ATTACK
        // =========================

        PlayerAttack p1Attack =
            p1.GetComponentInChildren<PlayerAttack>(true);

        if (p1Attack != null)
        {
            p1Attack.myHealth = p1Health;
            p1Attack.enemyHealth = p2Health;
            p1Attack.enabled = true;

            Debug.Log("P1 PlayerAttack connected.");
        }
        else
        {
            Debug.LogError("P1 has no PlayerAttack!");
        }

        // =========================
        // P2 ATTACK
        // =========================

        OpponentAttack p2Attack =
            p2.GetComponentInChildren<OpponentAttack>(true);

        if (p2Attack != null)
        {
            p2Attack.myHealth = p2Health;
            p2Attack.enemyHealth = p1Health;
            p2Attack.enabled = true;

            Debug.Log("P2 OpponentAttack connected.");
        }
        else
        {
            Debug.LogError("P2 has no OpponentAttack!");
        }

        // =========================
        // P1 MOVEMENT
        // =========================

        PlayerMovement p1Movement =
            p1.GetComponentInChildren<PlayerMovement>(true);

        OpponentMovement p1Opponent =
            p1.GetComponentInChildren<OpponentMovement>(true);

        if (p1Movement != null)
        {
            p1Movement.enabled = true;
        }

        if (p1Opponent != null)
        {
            p1Opponent.enabled = false;
        }

        // =========================
        // P2 MOVEMENT
        // =========================

        PlayerMovement p2Movement =
            p2.GetComponentInChildren<PlayerMovement>(true);

        OpponentMovement p2Opponent =
            p2.GetComponentInChildren<OpponentMovement>(true);

        if (p2Movement != null)
        {
            p2Movement.enabled = false;
        }

        if (p2Opponent != null)
        {
            p2Opponent.enabled = true;
        }

        // =========================
        // DONE
        // =========================

        Debug.Log("==============================");
        Debug.Log("FIGHT SETUP COMPLETE");
        Debug.Log("P1 = " + p1.name);
        Debug.Log("P2 = " + p2.name);
        Debug.Log("P1 HP = " + p1Health.currentHealth);
        Debug.Log("P2 HP = " + p2Health.currentHealth);
        Debug.Log("==============================");
    }

    GameObject GetCharacterPrefab(int characterIndex)
    {
        switch (characterIndex)
        {
            case 0:
                return devilJinPrefab;

            case 1:
                return yakuzaPrefab;

            case 2:
                return shaktimaanPrefab;

            case 3:
                return modinhoPrefab;

            default:
                Debug.LogError(
                    "Invalid character index: " + characterIndex
                );

                return null;
        }
    }
}