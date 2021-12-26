using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region Fields

    #region References
    [Header("References")]
    public Transform attackPoint;
    public LayerMask enemyLayers;
    #endregion

    #region Gameplay and spec
    [Header("Gameplay and spec")]
    public float attackDamage;
    public float attackRange;
    #endregion


    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        // If player presses left mouse button
        if (Input.GetButtonDown("Fire1")) 
        {
            // Gather hitboxes by casting a sphere and storing all hit objects
            Collider[] hitObjects = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

            foreach(Collider col in hitObjects)
            {
                print(col.gameObject.name);

                // If sphere hits an enemy (object with Enemy tag)
                if (col.gameObject.CompareTag("Enemy"))
                {
                    // Send a message to parent game object that holds the script and call TakeDamage and passin attackDamage
                    col.gameObject.SendMessageUpwards("TakeDamage", attackDamage);

                    // Lunge towards the target
                    FindObjectOfType<ThirdPersonMovement>().AttackLunge(col.gameObject);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
