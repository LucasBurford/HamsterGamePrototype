using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Main Player class
/// </summary>
public class PlayerHamster : MonoBehaviour
{
    #region Members

    #region References
    [Header("References")]

    // Reference to PlayerHealth text
    public TMP_Text playerHealth;

    // Reference to PlayerStamina text
    public TMP_Text playerStamina;
    #endregion

    #region Player Values
    [Header("Player Values")]

    // Player Health
    [SerializeField]
    private float health;
    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    // Player Damage
    [SerializeField]
    private float damageInflict;
    public float DamageInflict
    {
        get { return damageInflict; }
        set { damageInflict = value; }
    }

    // Player Stamina
    [SerializeField]
    private float stamina;
    public float Stamina
    {
        get { return stamina; }
        set { stamina = value; }

    }
    #endregion

    #region Gameplay
    [Header("Gameplay")]

    [SerializeField]
    private bool canBeDamaged;
    #endregion

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Initialise members
        health = 100;
        damageInflict = 25;
        stamina = 100;

        canBeDamaged = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerValues();
    }

    /// <summary>
    /// Update PlayerHealth and PlayerStamina text every frame
    /// </summary>
    private void UpdatePlayerValues()
    {
        playerHealth.text = health.ToString();
        playerStamina.text = stamina.ToString();
    }

    #region Health Methods
    /// <summary>
    /// Reduce health by passed in amount
    /// </summary>
    /// <param name="amount">Reduce health by this value</param>
    public void TakeDamage(float amount)
    {
        if (canBeDamaged)
        {
            health -= amount;

            // Play sound

            // Knockback

            canBeDamaged = false;
            StartCoroutine(TakeDamageReset(1.5f));
        }
    }

    /// <summary>
    /// Increase health by passed in amount
    /// </summary>
    /// <param name="amount">Increase health by this value</param>
    public void IncreaseHealth(float amount)
    {
        health += amount;
    }
    #endregion

    #region Stamina Methods
    /// <summary>
    /// Reduce stamina by passed in amount
    /// </summary>
    /// <param name="amount">Reduce stamina by this value</param>
    public void ReduceStamina(float amount)
    {
        stamina -= amount;
    }

    /// <summary>
    /// Increase stamina by passed in amount
    /// </summary>
    /// <param name="amount">Increase stamina by this value</param>
    public void IncreaseStamina(float amount)
    {
        stamina += amount;

        if (stamina >= 100)
        {
            stamina = 100;
        }
    }
    #endregion

    #region Coroutines
    IEnumerator TakeDamageReset(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        canBeDamaged = true;
    }
    #endregion
}
