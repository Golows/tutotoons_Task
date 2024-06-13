using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    private float boundarySize = 9;
    public int LastClicked = 0;
    public bool inStart = true;

    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private JSONReader Reader;
    [SerializeField] private GameObject buttonGem;
    [SerializeField] private LineRenderer lineRenderer;

    public List<ButtonGem> buttonsList = new List<ButtonGem>();
    public List<LineRenderer> lines = new List<LineRenderer>();
    public List<Level> levels = new List<Level>();
    public LineMovement lineMovement;

    private void Awake()
    {
        instance = this;
        Reader.LoadData();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(spawnPoint.transform.position + new Vector3(boundarySize / 2f, -boundarySize / 2f, 0), new Vector3(boundarySize, boundarySize, 0));
    }

    public void BuildLevel(int index)
    {
        inStart = false;
        for(int i = 0; i < levels[index].x.Count; i++)
        {
            Vector3 buttonPosition = (new Vector3(levels[index].x[i], -levels[index].y[i], 0) * boundarySize / 1000f) + spawnPoint.transform.position;
            Vector3 ropePosition = (new Vector3(levels[index].x[i], -levels[index].y[i], 0.5f) * boundarySize / 1000f) + spawnPoint.transform.position;
            ButtonGem NewObject = Instantiate(buttonGem, buttonPosition, Quaternion.identity).gameObject.GetComponent<ButtonGem>();
            lines.Add(Instantiate(lineRenderer, ropePosition, Quaternion.identity));
            lines[i].positionCount = 2;
            lines[i].SetPosition(0, ropePosition);
            lines[i].SetPosition(1, ropePosition);
            NewObject.updateText((i + 1).ToString());
            buttonsList.Add(NewObject);
        }
    }
}
