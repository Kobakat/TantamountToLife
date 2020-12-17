using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Player player = null;

    InputHandler input;
    enum Step
    {
        Move,
        Rotate,
        Reset,
        Attack,
    }

    Step state = Step.Move;

    Image image;
    TextMeshProUGUI text;

    #region Components

    public string move = "Use WASD to move around";
    public string rotate = "Use the arrow keys to rotate your camera";
    public string reset = "Press Shift to reset your camera";
    public string attack = "Press Space to attack";

    public Sprite wasd = null;
    public Sprite arrow = null;
    public Sprite shift = null;
    public Sprite space = null;

    bool complete;
    #endregion

    private void Start()
    {
        image = GetComponentInChildren<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        input = player.InputHandler;
    }
    void Update()
    {
        if(!complete)
        {
            switch (state)
            {
                case Step.Move:
                    image.sprite = wasd;
                    text.text = move;

                    if(input.Standard.Movement.ReadValue<Vector2>().sqrMagnitude > 0)
                    {
                        state = Step.Rotate;
                    }

                    break;
                case Step.Rotate:
                    image.sprite = arrow;
                    text.text = rotate;

                    if(input.Standard.FreeCam.ReadValue<Vector2>().sqrMagnitude > 0)
                    {
                        state = Step.Reset;
                    }

                    break;
                case Step.Reset:
                    image.sprite = shift;
                    text.text = reset;
                    image.transform.localScale = new Vector3(1, 0.5f, 1);
                    if(input.Standard.Target.ReadValue<float>() > 0)
                    {
                        state = Step.Attack;
                    }
                    break;
                case Step.Attack:
                    image.sprite = space;
                    text.text = attack;
                    image.transform.localScale = new Vector3(1, 0.5f, 1);
                    if (input.Standard.Attack.ReadValue<float>() > 0)
                    {
                        complete = true;
                        image.enabled = false;
                        text.enabled = false;
                    }
                    break;


            }
        }
        
    }
}
