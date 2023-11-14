using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class LineMovement : MonoBehaviour
{
    [SerializeField] public LineRenderer lineRenderer;
    private float step;
    private Queue<Vector3> movements = new Queue<Vector3>();
    public Queue<int> lineNumber = new Queue<int>();
    private int LineCount = 2;
    public Vector3 oldPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        step = 2 * Time.deltaTime;
        
        if (movements.Count > 0)
        {
            Vector3 newPos = Vector3.MoveTowards(lineRenderer.GetPosition(lineNumber.Peek()-1), new Vector3(movements.Peek().x, movements.Peek().y, 0.5f), step);
            lineRenderer.SetPosition(lineNumber.Peek() - 1, newPos);
            if (movements.Peek().x == newPos.x && movements.Peek().y == newPos.y)
            {
                RemoveNumFromQueue();
                oldPos = new Vector3(movements.Peek().x, movements.Peek().y, 0.5f);
                lineNumber.Enqueue(LineCount);
                
                LineCount = LineCount + 1;

                lineRenderer.positionCount = lineNumber.Peek();

                if (lineNumber.Peek() > 0)
                {
                    lineRenderer.SetPosition(lineNumber.Peek() - 1, oldPos);
                }

                RemoveMoveFromQueue();
            }
        }
    }

    public void AddToQueue(Vector3 newLocation)
    {
        movements.Enqueue(newLocation);
    }

    private void RemoveMoveFromQueue()
    {
        movements.Dequeue();
    }
    private void RemoveNumFromQueue()
    {
        lineNumber.Dequeue();
    }
}
