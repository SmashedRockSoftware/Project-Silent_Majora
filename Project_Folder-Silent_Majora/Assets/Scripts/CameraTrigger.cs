using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraTrigger : MonoBehaviour
{
    [Tooltip("Only objects with this tag will trigger this trigger, leave blank to allow anything to trigger this trigger")]
    [SerializeField] private string requiredTag = "Player";  //The tag we want to see to trigger
    [Tooltip("Unity event, which will execute when the required tag enters the collider")]
    [SerializeField] private UnityEvent OnEnter;
    [Tooltip("Unity event, which will execute when the required tag exits the collider")]
    [SerializeField] private UnityEvent OnExit;

    [Tooltip("The camera that we are related to")]
    [SerializeField] private GameObject Camera;

    private void OnTriggerEnter(Collider other) {
        if (requiredTag == "" || other.CompareTag(requiredTag)) {
            OnEnter.Invoke();
            CameraManager.instance.SetCameraToVisible(Camera);
        }
    }

    //private void OnTriggerExit(Collider other) {
    //    if (requiredTag == "" || other.CompareTag(requiredTag)) {
    //        OnExit.Invoke();
    //        CameraManager.instance.SetCameraToVisible(Camera);
    //    }
    //}
}
