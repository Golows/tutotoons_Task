using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonGem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer blue;
    [SerializeField] private SpriteRenderer red;
    [SerializeField] public TextMeshProUGUI text;
    private int buttonNumber;
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked()
    {
        if(GameController.instance.LastClicked == buttonNumber-1)
        {
            animator.SetTrigger("Clicked");
            GameController.instance.LastClicked = buttonNumber;
            blue.enabled = true;
            red.enabled = false;
        }
    }

    public void updateText(string number)
    {
        buttonNumber = int.Parse(number);
        text.SetText(number);
    }
}
