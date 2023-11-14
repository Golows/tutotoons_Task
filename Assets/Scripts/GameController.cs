using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{

    public static GameController instance { get; private set; }
    [SerializeField] public List<Level> levels = new List<Level>();
    public GameObject button;
    private float boundarySize = 9;
    public GameObject spawnPoint;
    public JSONReader Reader;
    [SerializeField] public List<ButtonGem> buttonsList = new List<ButtonGem>();
    [SerializeField] public GameObject lineMovement;
    [SerializeField] public TMP_Dropdown uiListl;
    [SerializeField] public Canvas selectCanvas;
    private List<String> options = new List<String>();
    public UnityEngine.UI.Button startButton;
    public UnityEngine.UI.Button selectLvlButton;


    public int LastClicked = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Reader.LoadData();
        uiListl.ClearOptions();
        for (int i = 0; i < levels.Count; i++)
        {
            options.Add("Level " + (i + 1));
        }
        uiListl.AddOptions(options);
    }

    void Update()
    {
        if(lineMovement.GetComponent<LineMovement>().last && lineMovement.GetComponent<LineMovement>().movements.Count == 0)
        {
            lineMovement.GetComponent<LineMovement>().last = false;
            selectLvlButton.gameObject.SetActive(true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.blue;
        Gizmos.DrawWireCube(spawnPoint.transform.position + new Vector3(boundarySize / 2f, -boundarySize / 2f, 0), new Vector3(boundarySize, boundarySize, 0));
    }

    private void BuildLevel(int index)
    {
        for(int i = 0; i < levels[index].x.Count; i++)
        {
            Vector3 position = (new Vector3(levels[index].x[i], -levels[index].y[i], 0) * boundarySize / 1000f) + spawnPoint.transform.position;
            ButtonGem NewObject = Instantiate(button, position, Quaternion.identity).gameObject.GetComponent<ButtonGem>();
            NewObject.lineMovement = lineMovement;
            NewObject.updateText((i + 1).ToString());
            buttonsList.Add(NewObject);
        }
    }

    public void StartClicked()
    {
        selectCanvas.gameObject.SetActive(false);
        BuildLevel(uiListl.value);
        lineMovement.GetComponent<LineMovement>().oldPos = buttonsList[0].transform.position;
        lineMovement.GetComponent<LineMovement>().lineRenderer.SetPosition(0, new Vector3(buttonsList[0].transform.position.x, buttonsList[0].transform.position.y, 0.5f));
        lineMovement.GetComponent<LineMovement>().lineNumber.Enqueue(1);
    }

    public void SelectLvlClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
