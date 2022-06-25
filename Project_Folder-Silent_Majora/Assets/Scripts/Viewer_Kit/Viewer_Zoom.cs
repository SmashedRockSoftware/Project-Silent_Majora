using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewer_Zoom : MonoBehaviour
{
    [SerializeField] GameObject camera_out;
    [SerializeField] GameObject camera_in;
    [SerializeField] KeyCode zoomKey = KeyCode.Mouse1;
    public Viewer_object obj;


    // Start is called before the first frame update
    void Start()
    {
        if (obj == null) obj = FindObjectOfType<Viewer_object>();
    }

    void SetZoom(bool isZoomed) {
        if (isZoomed) {
            //if (camera_in.activeInHierarchy) return;
            camera_in.SetActive(true);
            camera_out.SetActive(false);
            //TODO play sound
        }
        else {
            //if (camera_out.activeInHierarchy) return;
            camera_in.SetActive(false);
            camera_out.SetActive(true);
            //TODO play sound
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (obj == null) obj = ItemViewer.instance.viewedItem.GetComponent<Viewer_object>();

        if (obj.isZoomable) {
            if (Input.GetKey(zoomKey)) {
                SetZoom(true);
            }
            else {
                SetZoom(false);
            }
        } else {
            SetZoom(false);
        }
    }
}
