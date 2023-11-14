using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

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

    public int LastClicked = 0;

    private void Awake()
    {
        instance = this;
    }

    
    void Start()
    {
        Reader.LoadData();
        BuildLevel();
        lineMovement.GetComponent<LineMovement>().oldPos = buttonsList[0].transform.position;
        lineMovement.GetComponent<LineMovement>().lineRenderer.SetPosition(0, new Vector3(buttonsList[0].transform.position.x, buttonsList[0].transform.position.y, 0.5f));
        lineMovement.GetComponent<LineMovement>().lineNumber.Enqueue(1);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.blue;
        Gizmos.DrawWireCube(spawnPoint.transform.position + new Vector3(boundarySize / 2f, -boundarySize / 2f, 0), new Vector3(boundarySize, boundarySize, 0));
    }

    private void BuildLevel()
    {
        for(int i = 0; i < levels[3].x.Count; i++)
        {
            Vector3 position = (new Vector3(levels[3].x[i], -levels[3].y[i], 0) * boundarySize / 1000f) + spawnPoint.transform.position;
            ButtonGem NewObject = Instantiate(button, position, Quaternion.identity).gameObject.GetComponent<ButtonGem>();
            NewObject.lineMovement = lineMovement;
            NewObject.updateText((i + 1).ToString());
            buttonsList.Add(NewObject);
        }
        
    }
}
