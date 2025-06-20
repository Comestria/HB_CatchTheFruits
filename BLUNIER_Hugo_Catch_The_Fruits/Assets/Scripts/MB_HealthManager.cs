using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class MB_HealthManager : MonoBehaviour
{
    [SerializeField] private float health = 3f;
    [SerializeField] private float maxHealth = 3f;
    public UnityEvent HealthLoss;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (health <= 0)
        {
            // gameover
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Fruit"))
        {
            HealthLoss.Invoke();
        }
    }

    public void HealthDown()
    {
        health -= 1;
    }
}
