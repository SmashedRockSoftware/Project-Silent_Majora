using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewer_object : MonoBehaviour
{
    public bool isRotateable, isZoomable;
    public Viewer_note note;

    private void Start() {
        note = gameObject.GetComponent<Viewer_note>();
    }
}
