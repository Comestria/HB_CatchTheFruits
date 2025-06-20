using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MB_HealthManager : MonoBehaviour
{
    [SerializeField] private float health = 5f;
    [SerializeField] private float maxHealth = 5f;
    public TextMeshProUGUI healthText;
    public UnityEvent HealthLoss;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        healthText.text = "Health: " + health;
        if (health <= 0)
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
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

    public void HealthUp()
    {
        if (health < maxHealth)
        {
            health += 1;
        }
    }
}
