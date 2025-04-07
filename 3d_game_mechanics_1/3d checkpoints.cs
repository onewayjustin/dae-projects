using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Vector3 lastCheckpoint;
    public Transform player;

    void Start()
    {
        // Set initial checkpoint to the player's starting position
        lastCheckpoint = player.position;
    }

    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        lastCheckpoint = checkpointPosition;
        Debug.Log("Checkpoint updated: " + lastCheckpoint);
    }

    public void RespawnPlayer()
    {
        player.position = lastCheckpoint;
        Debug.Log("Player respawned at: " + lastCheckpoint);
    }
}

public class Checkpoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<CheckpointManager>().SetCheckpoint(transform.position);
        }
    }
}
