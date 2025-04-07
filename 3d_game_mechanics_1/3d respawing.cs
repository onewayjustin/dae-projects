using System.Collections;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public Transform player;
    public Vector3 respawnPoint;
    public float respawnDelay = 3f;

    void Start()
    {
        respawnPoint = player.position; // Initial spawn point
    }

    public void SetRespawnPoint(Vector3 newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
        Debug.Log("Respawn point updated: " + respawnPoint);
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCoroutine());
    }

    private IEnumerator RespawnCoroutine()
    {
        Debug.Log("Player defeated! Respawning in " + respawnDelay + " seconds...");
        yield return new WaitForSeconds(respawnDelay);
        player.position = respawnPoint;
        Debug.Log("Player respawned at: " + respawnPoint);
    }
}
