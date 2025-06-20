using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class MB_PlayerController : MonoBehaviour
{
    [SerializeField] private float score = 0f;

    [Header("Speed Values")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float basespeed = 5f;

    [Header("Dash Values")]
    [SerializeField] private float dashspeed = 9f;
    [SerializeField] private float TimerDash = 2f;
    [SerializeField] private float baseTimer = 2f;
    public UnityEvent HealthLoss;
    public UnityEvent HealthGain;
    public TextMeshProUGUI scoreText;
    private Vector2 moveInput;

    private void Start()
    {
        speed = basespeed;
        TimerDash = baseTimer;
    }

    void Update()
    {
        scoreText.text = "Score: " + score;

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (TimerDash < 0)
            {
                speed = dashspeed;
                TimerDash = baseTimer;
            }
        }

        TimerDash -= Time.deltaTime;
        if (TimerDash < 0)
        {
            speed = basespeed;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Fruit"))
        {
            score += 1;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Trap"))
        {
            HealthLoss.Invoke();
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("BonusFruit"))
        {
            score += 3;
            HealthGain.Invoke();
        }
    }
}
