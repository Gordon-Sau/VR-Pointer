using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class ClickDot : MonoBehaviour
{
    private MakeLine lineMaker;
    private Renderer dotRenderer;
    private bool isClicked = false;
    private Color originalColor;

    public void Awake() {
        dotRenderer = this.gameObject.GetComponent<Renderer>();
        originalColor = dotRenderer.material.GetColor("_Color");
    }

    public void SetLineMaker(MakeLine makeLine) {
        lineMaker = makeLine;
    }

    public void cancelClick() {
        isClicked = false;
        dotRenderer.material.SetColor("_Color", originalColor);
    }

    public void TriggerClick() {
        Debug.Log("Dot gets triggered by pointer");
        isClicked = !isClicked;
        if (isClicked) {
            dotRenderer.material.SetColor("_Color", Color.red);
            lineMaker.addPoint(this.transform);
        } else {
            cancelClick();
            lineMaker.cancelPoint(this.transform);
        }
    }
}
