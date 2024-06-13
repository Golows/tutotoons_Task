using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    private GameController gameController;
    [SerializeField] private Button selectLvlButton;
    [SerializeField] private GameObject escapeMenu;
    [SerializeField] private GameObject backToStartButton;
    [SerializeField] private GameObject menu;
    [SerializeField] private TMP_Dropdown uiList;
    private List<String> dropDownStrings = new List<String>();

    private void Start()
    {
        gameController = GameController.instance;
        uiList.ClearOptions();
        for (int i = 0; i < gameController.levels.Count; i++)
        {
            dropDownStrings.Add("Level " + (i + 1));
        }
        uiList.AddOptions(dropDownStrings);
    }

    private void Update()
    {
        if (gameController.lineMovement.last && gameController.lineMovement.movements.Count == 0)
        {
            gameController.lineMovement.last = false;
            selectLvlButton.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!escapeMenu.activeSelf)
            {
                Time.timeScale = 0f;
                escapeMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                escapeMenu.SetActive(false);
            }
        }

        if (gameController.inStart && backToStartButton.activeSelf)
        {
            backToStartButton.SetActive(false);
        }
        else if (!gameController.inStart && !backToStartButton.activeSelf)
        {
            backToStartButton.SetActive(true);
        }
    }

    public void StartClicked()
    {
        menu.gameObject.SetActive(false);
        gameController.BuildLevel(uiList.value);
    }

    public void BackToStart()
    {
        Time.timeScale = 1f;
        escapeMenu.SetActive(false);
        SceneManager.LoadScene("MainScene");
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        escapeMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
