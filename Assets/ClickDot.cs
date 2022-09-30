using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void onDotClick(RaycastHit hit) {
        isClicked = !isClicked;
        if (isClicked) {
            dotRenderer.material.SetColor("_Color", Color.red);
            lineMaker.addPoint(this.transform);
        } else {
            cancelClick();
            lineMaker.cancelPoint(this.transform);
        }
    }

    public void cancelClick() {
        isClicked = false;
        dotRenderer.material.SetColor("_Color", originalColor);
    }
}
