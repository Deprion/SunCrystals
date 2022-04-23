using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene("MainScene");
    }
}
