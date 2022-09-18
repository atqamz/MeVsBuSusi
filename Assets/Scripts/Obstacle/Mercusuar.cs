using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mercusuar : MonoBehaviour
{
    [Header("Detection")]
    [SerializeField] private float detectionRadius = 10f;
    [SerializeField] private SpriteRenderer detectionSprite;
    [SerializeField] private float detectionSpriteScala = 0.3f;
    [SerializeField] private Color32 detectedColor;
    [SerializeField] private Color32 undetectedColor;
    [SerializeField] private float detectionDamage = 0.2f;

    [Header("Detection Object")]
    [SerializeField] private GameObject player;

    private bool detected;

    private void Start()
    {
        detectionSprite.transform.localScale = new Vector3(detectionRadius * detectionSpriteScala, detectionRadius * detectionSpriteScala, 1f);
    }

    private void Update()
    {
        if (DetectPlayer())
        {
            detectionSprite.color = detectedColor;

            // if audio sfx is not playing
            // if (!AudioManager.Instance.IsSFXPlaying())
            AudioManager.Instance.PlaySFX(1);

        }
        else
        {
            detectionSprite.color = undetectedColor;
        }
    }

    private bool DetectPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                GameManager.Instance.GameOver();
                return true;
            }
        }

        detected = false;
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    public float GetDetectionDamage()
    {
        return detectionDamage;
    }

    public float GetDetectionRadius()
    {
        return detectionRadius;
    }

    public bool GetDetected()
    {
        return detected;
    }
}
