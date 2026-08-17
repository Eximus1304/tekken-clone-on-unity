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
        GameObject p1Prefab =
            GetCharacterPrefab(CharacterSelection.player1Character);

        GameObject p2Prefab =
            GetCharacterPrefab(CharacterSelection.player2Character);

        if (p1Prefab == null || p2Prefab == null)
        {
            Debug.LogError("Character prefab is missing!");
            return;
        }

        // =========================
        // SPAWN
        // =========================

        p1 = Instantiate(
            p1Prefab,
            p1Spawn.position,
            p1Spawn.rotation
        );

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

        if (p1Health == null || p2Health == null)
        {
            Debug.LogError("Health component missing!");
            return;
        }

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
        // P1 MOVEMENT
        // =========================

        PlayerMovement p1PlayerMovement =
            p1.GetComponentInChildren<PlayerMovement>(true);

        OpponentMovement p1OpponentMovement =
            p1.GetComponentInChildren<OpponentMovement>(true);

        if (p1PlayerMovement != null)
            p1PlayerMovement.enabled = true;

        if (p1OpponentMovement != null)
            p1OpponentMovement.enabled = false;

        // =========================
        // P2 MOVEMENT
        // =========================

        PlayerMovement p2PlayerMovement =
            p2.GetComponentInChildren<PlayerMovement>(true);

        OpponentMovement p2OpponentMovement =
            p2.GetComponentInChildren<OpponentMovement>(true);

        if (p2PlayerMovement != null)
            p2PlayerMovement.enabled = false;

        if (p2OpponentMovement != null)
            p2OpponentMovement.enabled = true;

        // =========================
        // P1 ATTACK
        // =========================

        PlayerAttack p1Attack =
            p1.GetComponentInChildren<PlayerAttack>(true);

        OpponentAttack p1OpponentAttack =
            p1.GetComponentInChildren<OpponentAttack>(true);

        if (p1Attack != null)
        {
            p1Attack.myHealth = p1Health;
            p1Attack.enemyHealth = p2Health;
            p1Attack.enabled = true;
        }

        if (p1OpponentAttack != null)
        {
            p1OpponentAttack.myHealth = p1Health;
            p1OpponentAttack.enemyHealth = p2Health;
            p1OpponentAttack.enabled = false;
        }

        // =========================
        // P2 ATTACK
        // =========================

        PlayerAttack p2Attack =
            p2.GetComponentInChildren<PlayerAttack>(true);

        OpponentAttack p2OpponentAttack =
            p2.GetComponentInChildren<OpponentAttack>(true);

        if (p2Attack != null)
        {
            p2Attack.myHealth = p2Health;
            p2Attack.enemyHealth = p1Health;
            p2Attack.enabled = false;
        }

        if (p2OpponentAttack != null)
        {
            p2OpponentAttack.myHealth = p2Health;
            p2OpponentAttack.enemyHealth = p1Health;
            p2OpponentAttack.enabled = true;
        }

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