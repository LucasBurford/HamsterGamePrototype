using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasp : MonoBehaviour
{
    #region Members
    [Header("Wasp Values")]

    [SerializeField]
    // Wasp health
    private float health;
    public float Health
    {
        get { return health; }
    }

    [SerializeField]
    private float damageInflict;
    public float DamageInflict
    {
        get { return damageInflict; }
        set { damageInflict = value; }
    }

    [SerializeField]
    // Wasp behaviour states
    private enum States
    {
        idle,
        attacking
    }
    [SerializeField]
    private States state;

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
        if (state == States.idle)
        {
            Hover();
        }
    }

    /// <summary>
    /// Hover up and down
    /// </summary>
    private void Hover()
    {
        //transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, 1), transform.position.z);
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
