using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private GameObject fishZone;
    [SerializeField] private float eachFishZoneRadius = 3f;
    [SerializeField] private GameObject[] obstackles;
    [SerializeField] private float eachObstackleRadius = 20f;
    [SerializeField] private float spawnDelay = 2f;
    [SerializeField] private float spawnRadius = 2f;
    [SerializeField] private GameObject player;

    private void Update()
    {
        if (GameManager.Instance.GetIsOver()) return;

        Vector2 playerPosition = player.transform.position;
        spawnDelay -= Time.deltaTime;
        if (spawnDelay <= 0f)
        {
            SpawnFishZone(playerPosition);
            SpawnFishZone(playerPosition);
            SpawnFishZone(playerPosition);
            SpawnFishZone(playerPosition);
            SpawnFishZone(playerPosition);
            spawnDelay = 2f;
            SpawnObstackle(playerPosition);
        }
    }

    private void SpawnObstackle(Vector2 _playerPosition)
    {
        Vector2 spawnPosition = Random.insideUnitCircle * eachObstackleRadius;
        spawnPosition += (_playerPosition * eachObstackleRadius) * spawnRadius * .5f;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, eachObstackleRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Obstackle"))
                return;
        }

        int randomIndex = Random.Range(0, obstackles.Length);
        GameObject instance = Instantiate(obstackles[randomIndex], spawnPosition, Quaternion.identity, transform);

        // Vector2 spawnPosition = _playerPosition;

        // Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, eachObstackleRadius);
        // foreach (Collider2D collider in colliders)
        // {
        //     if (collider.CompareTag("Obstackle"))
        //         return;
        // }

        // spawnPosition = Random.insideUnitCircle.normalized
        //  * spawnRadius;


        // int randomIndex = Random.Range(0, obstackles.Length);
        // Instantiate(obstackles[randomIndex], spawnPosition, Quaternion.identity);
    }

    private void SpawnFishZone(Vector2 _playerPosition)
    {
        // instantiate
        Vector2 spawnPosition = Random.insideUnitCircle * eachFishZoneRadius;

        spawnPosition *= _playerPosition * spawnRadius;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_playerPosition * spawnRadius, eachFishZoneRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Fish"))
                return;
        }

        Instantiate(fishZone, spawnPosition, Quaternion.identity, transform);



        // Vector2 spawnPosition = Random.insideUnitCircle * eachFishZoneRadius;
        // spawnPosition += _playerPosition;
        // // Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, eachObstackleRadius);
        // // foreach (Collider2D collider in colliders)
        // // {
        // //     if (collider.CompareTag("Fish"))
        // //         return;
        // //     if (collider.CompareTag("Obstackle"))
        // //         return;
        // // }

        // GameObject instance = Instantiate(fishZone, spawnPosition, Quaternion.identity, transform);

        // Vector2 spawnPosition = _playerPosition;

        // Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, eachFishZoneRadius);
        // foreach (Collider2D collider in colliders)
        // {
        //     if (collider.CompareTag("Fish"))
        //         return;
        // }

        // spawnPosition = Random.insideUnitCircle.normalized
        //  * spawnRadius;

        // Instantiate(fishZone, spawnPosition, Quaternion.identity, transform);
    }
}
