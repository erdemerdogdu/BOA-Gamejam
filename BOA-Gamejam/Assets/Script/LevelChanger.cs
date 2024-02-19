using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public int eggCntToEnd = -1;
    public int killCntToEnd = -1;
    private int levelToLoad;

    public Animator animator;
    private GameObject player;
    private PlayerStats playerStats;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            playerStats = player.GetComponent<PlayerStats>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null && playerStats != null)
        {
            // If player coolects eggs
            if(playerStats.eggCnt == eggCntToEnd)
            {
                FadeToNextLevel();
            }
            // If player kills enough
            else if (playerStats.killCnt == killCntToEnd)
            {
                FadeToNextLevel();
            }
        }
    }

    public void FadeToNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            FadeToLevel(0);
        }
        else
        {
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
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
