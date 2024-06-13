using System.Collections.Generic;
using UnityEngine;

public class LineMovement : MonoBehaviour
{
    private int lineCount = 0;
    public Queue<Vector3> movements = new Queue<Vector3>();
    private float step;
    private Vector3 newPos;
    public bool last = false;
    private bool first = true;
    private GameController controller;

    private void Start()
    {
        controller = GameController.instance;
    }

    private void Update()
    {
        if (movements.Count > 0)
        {
            step = 3 * Time.deltaTime;
            newPos = Vector3.MoveTowards(controller.lines[lineCount].GetPosition(1), new Vector3(movements.Peek().x, movements.Peek().y, 0.5f), step);
            controller.lines[lineCount].SetPosition(1, newPos);

            if (controller.lines[lineCount].GetPosition(1).x == movements.Peek().x && controller.lines[lineCount].GetPosition(1).y == movements.Peek().y)
            {
                if(first)
                {
                    movements.Dequeue();
                }
                else
                {
                    movements.Dequeue();
                    lineCount++;
                }
                first = false;
            }
        }
    }

    public void AddToQueue(Vector3 newLocation, bool lastCheck)
    {
        movements.Enqueue(newLocation);
        last = lastCheck;
    }
}
