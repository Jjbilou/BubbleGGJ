using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
    }
}
