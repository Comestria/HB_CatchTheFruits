using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MB_ElementManager : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            Destroy(gameObject);
        }
    }
}
