using TMPro;
using UnityEngine;

public class ButtonGem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer blue;
    [SerializeField] private SpriteRenderer red;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Animator animator;
    private int buttonNumber;
    private LineMovement lineMovement;
    private GameController controller;

    private void Start()
    {
        controller = GameController.instance;
        lineMovement = GameController.instance.lineMovement;
    }

    public void Clicked()
    {
        if (controller.LastClicked == buttonNumber - 1)
        {
            animator.SetTrigger("Clicked");
            controller.LastClicked = buttonNumber;
            blue.enabled = true;
            red.enabled = false;
            lineMovement.AddToQueue(gameObject.transform.position, false);
            if (controller.buttonsList.Count == buttonNumber)
            {
                lineMovement.AddToQueue(controller.buttonsList[0].transform.position, true);
            }
        }
    }

    public void updateText(string number)
    {
        buttonNumber = int.Parse(number);
        text.SetText(number);
    }
}
