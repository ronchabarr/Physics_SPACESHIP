using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Canvas mainCanvas;
    public Button[] MovementButton;
    public enum PressedButton {W,A,S,D }
    public PressedButton CurrentPressed;
    void Start()
    {
        
       
    }
    public void ButtonDown(int ButtonDown)
    {
        MovementButton[ButtonDown].image.color = Color.grey;
    }
    public void ButtonUp(int ButtonUp)
    {
        MovementButton[ButtonUp].image.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
