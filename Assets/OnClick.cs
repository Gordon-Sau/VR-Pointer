using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnClick : MonoBehaviour
{
    public InputActionReference clickRef = null;
    public List<GameObject> objs;
    public float maxLen = 30f;

    private void Awake()
    {
        clickRef.action.started += onClick;
    }
    private void onDestroy() {
        clickRef.action.started -= onClick;
    }

    private void onClick(InputAction.CallbackContext context) {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxLen)) {
            foreach (GameObject obj in objs) {
                Debug.Log(obj.ToString());
                if (GameObject.ReferenceEquals(hit.transform.gameObject, obj)) {
                    Debug.Log("click " + obj.ToString());
                    obj.SendMessage("onClick", hit);
                    break;
                }
            }
        }
    }

}
