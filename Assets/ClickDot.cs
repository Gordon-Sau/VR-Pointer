using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDot : MonoBehaviour
{
    private MakeLine lineMaker;
    private OnClick onClickController;
    private Renderer dotRenderer;
    private bool isClicked = false;
    private Color originalColor;

    public void Awake() {
        lineMaker = RefManager.getLineMaker();
        onClickController = RefManager.getOnClickController();
        onClickController.objs.Add(this.gameObject);
        dotRenderer = this.gameObject.GetComponent<Renderer>();
        originalColor = dotRenderer.material.GetColor("_Color");
    }

    public void onDestroy() {
        onClickController.objs.Remove(this.gameObject);
    }

    public void onClick(RaycastHit hit) {
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
