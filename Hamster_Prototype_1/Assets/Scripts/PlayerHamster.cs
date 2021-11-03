﻿using System.Collections;
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

    // Player Damage
    [SerializeField]
    private float damageInflict;

    // Player Stamina
    [SerializeField]
    private float stamina;
    #endregion

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        // Initialise members
        health = 100;
        damageInflict = 25;
        stamina = 100;
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
}
