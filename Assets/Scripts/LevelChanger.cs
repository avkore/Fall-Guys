using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private int levelToLoad;

    void Update()
    {
        // FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel(int levelIndex)
    {
        anim.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
