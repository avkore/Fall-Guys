using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] private GameObject ChoosePlayersPanel;
    [SerializeField] private TMP_Text botQuantityText;
    [SerializeField] private Animator anim;
    public bool hasStarted;
    public static Gamemanager Instance { get; private set; }

    public void PauseGame(){
        Time.timeScale = 0f;
    }

    public void BeginGame(){
        Time.timeScale = 1f;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void OpenChoosePlayersPanel()
    {
        ChoosePlayersPanel.SetActive(true);
    }

    public void CloseChoosePlayerPanel()
    {
        ChoosePlayersPanel.SetActive(false);
    }

    public void StartGame()
    {
        LoadNextLevel();
    }
    
}
