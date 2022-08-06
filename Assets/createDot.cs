using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createDot : MonoBehaviour
{
    public GameObject dotPrefab; // for instantiating the dot
    public void onClick(RaycastHit hit) {
        GameObject dot = Instantiate<GameObject>(dotPrefab, hit.point, Quaternion.identity);
    }

}
