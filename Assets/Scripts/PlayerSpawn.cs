using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerPrefab;
    private PlayerController playerInst;
    public static PlayerSpawn inst; 
    private BoxCollider2D spawnArea;

    private void Awake()
    {
        if (inst == null)
            inst = this;
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        spawnArea = GetComponentInChildren<BoxCollider2D>();
        playerInst = Instantiate(playerPrefab, transform.position + Vector3.up, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerController>() == playerInst)
        {
            playerInst.InSpawnArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerController>() == playerInst)
        {
            playerInst.InSpawnArea = false;
        }
    }
}