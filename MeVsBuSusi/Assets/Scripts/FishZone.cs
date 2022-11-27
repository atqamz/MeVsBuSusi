using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishZone : MonoBehaviour
{
    [SerializeField] private int score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(score);
            Destroy(gameObject);
        }
    }
}
