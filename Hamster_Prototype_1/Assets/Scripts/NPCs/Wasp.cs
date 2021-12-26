using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasp : MonoBehaviour
{
    #region Fields

    #region References
    [Header("References")]
    public Rigidbody rb;
    public Transform visionOrigin;

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

    // Wait to reset attack time
    public float resetAttackTime;

    public float visionLength;
    #endregion

    #region Bools
    [Header("Bools")]
    public bool canAttack;
    #endregion

    #endregion

    #endregion

    // Start is called before the first frame update
    void Start()
    {

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
        float y = Mathf.PingPong(Time.time, 1);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    public void TakeDamage(object damage)
    {
        health -= (float)damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void CastVisionSphere()
    {
        // Cast sphere to act as vision and collect 'seen' objects
        Collider[] seenObjects = Physics.OverlapSphere(visionOrigin.position, visionLength);

        foreach (Collider col in seenObjects)
        {
            // If seen object is the player
            if (col.gameObject.CompareTag("Player"))
            {
                // Move towards the player using navmesh

            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionStay(Collision collision)
    {
        // If Wasp collides with player and can attack
        if (collision.gameObject.name == "PlayerHamster" && canAttack)
        {
            // Call TakeDamage and pass through damageInflict to damage the player
            collision.gameObject.GetComponent<PlayerHamster>().TakeDamage(damageInflict);

            // Reset attack
            canAttack = false;

            StartCoroutine(WaitToResetAttack());
        }
    }

    #region Coroutines
    IEnumerator WaitToResetAttack()
    {
        yield return new WaitForSeconds(resetAttackTime);

        canAttack = true;
    }
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(visionOrigin.position, visionLength);
    }
}
