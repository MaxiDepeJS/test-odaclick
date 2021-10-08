using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGame : MonoBehaviour
{
    public int points;
    public int clicks;

    public bool isSubstract;
    public string name;

    private int clicksCounter;
    [HideInInspector] public bool isClicked = false;

    private void Start()
    {
        clicksCounter = 0;
    }

    void Update()
    {
        this.transform.Rotate(0, 0.3f, 0);
    }

    private void OnMouseDown()
    {
        isClicked = true;
        clicksCounter++;

        if (isSubstract)
        {
            ControllerGame.INS.SubtractPoints(points);
            Destroy(this.gameObject);
        }

        if (clicksCounter == clicks)
        {
            ControllerGame.INS.AddPoints(points);
            Destroy(this.gameObject);
        }
    }
}
