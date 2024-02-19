using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneEnder : MonoBehaviour
{
    /*
    private GameObject player;
    [SerializeField] private GameObject lc;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindWithTag("Player");
        //if(condition)
        StartCoroutine(NextScene());
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerStats>().eggCnt == 4)
        {
            //lc.GetComponent<LevelChanger>().FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(30.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    */

    public float cutSceneTime;

    private void Start()
    {
        StartCoroutine(NextScene());
    }
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(cutSceneTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
