using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    [SerializeField]
    bool usePowerups = true;

    public Coroutine scoreCoroutine;

    void Awake()
    {
        SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
    }

    void Start()
    {
        GameData.money = 0;
        GameData.score = 0;
        GameData.usePowerups = usePowerups;
    }
}
