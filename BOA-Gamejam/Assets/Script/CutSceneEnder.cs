using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneEnder : MonoBehaviour
{
    public float cutSceneTime;

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(cutSceneTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
