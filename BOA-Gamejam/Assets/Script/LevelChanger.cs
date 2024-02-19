using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public int eggCntToEnd = -1;
    public int killCntToEnd = -1;
    public Animator animator;
    private int levelToLoad;
    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerStats != null)
        {
            if(playerStats.eggCnt == eggCntToEnd)
            {
                FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (playerStats.killCnt == killCntToEnd)
            {
                if(SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
                {
                    FadeToLevel(0);
                }
                else
                {
                    FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
    }

    public void FadeToLevel(int levelNo)
    {
        levelToLoad = levelNo;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
