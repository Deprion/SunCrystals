using UnityEngine;
using UnityEngine.SceneManagement;

public class Startup : MonoBehaviour
{
    [SerializeField] private DataManagerSO dataManager;
    private void Awake()
    {
        dataManager.Init();

        SceneManager.LoadScene("LoginScene");
    }
}
