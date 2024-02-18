using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger3 : MonoBehaviour
{
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
        if (player.GetComponent<PlayerStats>().killCnt == 30)
        {
            //lc.GetComponent<LevelChanger>().FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(120.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
