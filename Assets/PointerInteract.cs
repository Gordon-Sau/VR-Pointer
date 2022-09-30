using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PointerInteract: MonoBehaviour
{
    [SerializeField]
    private XRRayInteractor interactor = null;

    [SerializeField]
    private GameObject dotPrefab = null;

    [SerializeField]
    private MakeLine lineMaker = null;

    public void TriggerClick() {
        Debug.Log("get clicked by pointer");
        RaycastHit hit;
        if (interactor.TryGetCurrent3DRaycastHit(out hit)) {
            if (hit.transform.gameObject == this.gameObject) {
                // create dot
                GameObject dot = Instantiate<GameObject>(dotPrefab, hit.point, Quaternion.identity, this.transform);
                dot.GetComponent<ClickDot>().SetLineMaker(lineMaker);
            }
        }
    }
}
