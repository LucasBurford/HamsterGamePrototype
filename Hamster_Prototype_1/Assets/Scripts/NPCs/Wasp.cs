using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasp : MonoBehaviour
{
    #region Fields

    #region References
    [Header("References")]

    public Rigidbody rb;
    public GameManager gameManager;

    #endregion

    #region Gameplay and spec
    [Header("Gameplay and spec")]

    #region Behaviour states
    [Header("Behaviour states")]
    public States state;
    public enum States
    {
        idle,
        attacking
    }
    #endregion

    #region Floats and ints
    [Header("Floats and ints")]

    // Wasp health
    public float health;
    // Damage dealt to the player
    public float damageInflict;
    #endregion

    #endregion

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Initialise values
        health = 100;
        damageInflict = 15;
        // Set starting state to idle
        state = States.idle;
    }

    // Update is called once per frame
    void Update()
    {
        // Enact behaviour based on current state
        switch (state)
        {
            case States.idle:
                {
                    Hover();
                }
                break;
        }
    }

    /// <summary>
    /// Hover up and down
    /// </summary>
    private void Hover()
    {
        Vector3 move = new Vector3(transform.position.x, transform.position.y + Mathf.PingPong(Time.time, 1), transform.position.z);
        rb.MovePosition(move);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If Wasp collides with player
        if (collision.gameObject.name == "PlayerHamster")
        {
            // Call TakeDamage and pass through damageInflict to damage the player
            collision.gameObject.GetComponent<PlayerHamster>().TakeDamage(damageInflict);
        }
    }
}
