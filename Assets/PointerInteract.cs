using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PointerInteract: MonoBehaviour
{
    [SerializeField]
    private GameObject dotPrefab = null;

    [SerializeField]
    private MakeLine lineMaker = null;

    public void TriggerClick(XRBaseInteractor interactor) {
        if (interactor is XRRayInteractor) {
            XRRayInteractor rayInteractor = (XRRayInteractor)interactor;
            Debug.Log("get clicked by pointer");
            RaycastHit hit;
            if (rayInteractor.TryGetCurrent3DRaycastHit(out hit)) {
                // create dot
                GameObject dot = Instantiate<GameObject>(dotPrefab, hit.point, Quaternion.identity, this.transform);
                dot.GetComponent<ClickDot>().SetLineMaker(lineMaker);
            }
        }
    }
}
