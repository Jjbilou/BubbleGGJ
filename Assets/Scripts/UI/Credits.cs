using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("BGM"));
        StartCoroutine(DisplayCredits());
    }

    IEnumerator DisplayCredits()
    {
        yield return new WaitForSeconds(3.0f);

        transform.DOMoveY(11300f, 80.0f).SetEase(Ease.Linear);

        yield return new WaitForSeconds(85.0f);

        SceneManager.LoadScene("MainMenu");
    }
}