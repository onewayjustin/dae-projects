using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    // Enum to track different states of the player
    public enum PlayerState
    {
        Idle,
        Walking,
        Jumping,
        Attacking,
        Dead
    }

    // Player stats
    public float speed = 5f;
    public float jumpHeight = 7f;
    public int health = 100;
    private PlayerState currentState;
    
    // A simple inventory system to store items
    private List<string> inventory = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        // Initialize player state
        currentState = PlayerState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        // Check current state and act accordingly
        switch (currentState)
        {
            case PlayerState.Idle:
                IdleState();
                break;
            case PlayerState.Walking:
                WalkState();
                break;
            case PlayerState.Jumping:
                JumpState();
                break;
            case PlayerState.Attacking:
                AttackState();
                break;
            case PlayerState.Dead:
                DeadState();
                break;
        }

        // Handle player movement (transition from idle to walking)
        HandleMovement();
    }

    // Player idle behavior
    void IdleState()
    {
        Debug.Log("Player is idle");
    }

    // Player walking behavior
    void WalkState()
    {
        Debug.Log("Player is walking");
    }

    // Player jumping behavior
    void JumpState()
    {
        Debug.Log("Player is jumping");
        // Simulate jump mechanic
        transform.Translate(Vector3.up * jumpHeight * Time.deltaTime);
    }

    // Player attacking behavior
    void AttackState()
    {
        Debug.Log("Player is attacking");
        // Simulate attack animation or action
    }

    // Player dead behavior
    void DeadState()
    {
        Debug.Log("Player is dead");
        // Handle death behavior, game over, respawn, etc.
    }

    // Handle movement input
    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            currentState = PlayerState.Walking;
            // Move player based on input
            Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
            transform.Translate(movement);
        }
        else
        {
            currentState = PlayerState.Idle;
        }

        // Jump if spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentState = PlayerState.Jumping;
        }
    }

    // A simple function to handle damage
    void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player took damage! Health: " + health);

        // Check if the player is dead
        if (health <= 0)
        {
            currentState = PlayerState.Dead;
            health = 0;
        }
    }

    // Function to add items to the inventory
    void AddToInventory(string item)
    {
        inventory.Add(item);
        Debug.Log(item + " added to inventory.");
    }

    // Check if player is alive
    bool IsAlive()
    {
        return health > 0;
    }
}
