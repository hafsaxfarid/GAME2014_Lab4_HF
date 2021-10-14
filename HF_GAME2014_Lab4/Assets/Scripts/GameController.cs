using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Rect safeArea;
    public Rect screen;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Rect screenRect = new Rect(0.0f, 0.0f, Screen.width, Screen.height);

        screen = screenRect;
        safeArea = Screen.safeArea;
    }
}