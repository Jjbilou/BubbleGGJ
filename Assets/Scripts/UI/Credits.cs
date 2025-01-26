using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisplayCredits());
    }

    IEnumerator DisplayCredits()
    {
        yield return new WaitForSeconds(3.0f);

        transform.DOMoveY(10.8f * Screen.height, 60.0f).SetEase(Ease.Linear);

        yield return new WaitForSeconds(63.0f);

        SceneManager.LoadScene("MainMenu");
    }
}