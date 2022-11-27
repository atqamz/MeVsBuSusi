using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance { get; private set; }

    [SerializeField] private Transform heatlhBar;
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    private float decreaseDamage = 0.05f;
    private bool isDetected;
    private bool isFull;

    private void Start()
    {
        currentHealth = 0f;
        heatlhBar.localScale = new Vector3(0f, 1f, 1f);
    }

    private void Update()
    {
        heatlhBar.localScale = new Vector3(currentHealth / maxHealth, 1f, 1f);

        if (isDetected)
        {
            if (currentHealth < maxHealth)
            {
                currentHealth += decreaseDamage;
            }
            else
            {
                isFull = true;
            }
        }
        else
        {
            // cap to 0
            currentHealth = Mathf.Max(0f, currentHealth - decreaseDamage);
        }
        // if no collider with
    }

    public void SetIncreaseDamage(float _damage)
    {
        if (currentHealth + _damage > maxHealth)
        {
            currentHealth = maxHealth;
            isFull = true;
        }
        else
        {
            currentHealth += _damage;
            isFull = false;
        }
    }

    public void SetDecreaseDamage()
    {
        if (currentHealth - decreaseDamage < 0f)
            currentHealth = 0f;
        else
            currentHealth -= decreaseDamage;
    }

    public bool GetIsFull()
    {
        return isFull;
    }

    public bool GetIsDetected()
    {
        return isDetected;
    }

    public void SetIsDetected(bool _isDetected)
    {
        isDetected = _isDetected;
    }
}
