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
        float y = Mathf.PingPong(Time.time, 1);

        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
