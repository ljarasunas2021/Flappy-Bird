using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public void ReloadScene()
    {
        StartCoroutine(RetryGame());
    }

    private IEnumerator RetryGame()
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
