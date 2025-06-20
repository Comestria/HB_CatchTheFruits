using UnityEngine;
using UnityEngine.SceneManagement;

public class MB_UIManager : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
