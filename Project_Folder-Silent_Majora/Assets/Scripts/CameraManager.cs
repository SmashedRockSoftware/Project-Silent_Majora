using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject[] cameras;
    public static CameraManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void SetCameraToHidden(GameObject obj) {
        foreach (var cam in cameras) {
            if (cam == obj) {
                cam.SetActive(false);
                break;
            }
        }
    }

    public void SetCameraToVisible(GameObject obj) {
        foreach (var cam in cameras) {
            if (cam == obj)
                cam.SetActive(true);
            else
                cam.SetActive(false);
        }
    }
}
