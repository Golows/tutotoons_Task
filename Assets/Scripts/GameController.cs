using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController instance { get; private set; }
    [SerializeField] public List<Level> levels;
    public GameObject button;
    private float boundarySize = 9;
    public GameObject spawnPoint;

    public int LastClicked = 0;

    private void Awake()
    {
        instance = this;
        levels = new List<Level>();
    }

    
    void Start()
    {
        BuildLevel();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.blue;
        Gizmos.DrawWireCube(spawnPoint.transform.position + new Vector3(boundarySize / 2f, -boundarySize / 2f, 0), new Vector3(boundarySize, boundarySize, 0));
    }

    private void BuildLevel()
    {
        for(int i = 0; i < levels[1].x.Count; i++)
        {
            Vector3 position = (new Vector3(levels[1].x[i], -levels[1].y[i], 0) * boundarySize / 1000f) + spawnPoint.transform.position;

            Instantiate(button, position, Quaternion.identity).gameObject.GetComponent<ButtonGem>().updateText((i+1).ToString());
        }
        
    }
}
