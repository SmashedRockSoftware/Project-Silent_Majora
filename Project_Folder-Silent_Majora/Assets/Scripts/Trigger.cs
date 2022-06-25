using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour {
    [Tooltip("Only objects with this tag will trigger this trigger, leave blank to allow anything to trigger this trigger")]
    [SerializeField] private string requiredTag = "Player";  //The tag we want to see to trigger
    [Tooltip("Unity event, which will execute when the required tag enters the collider")]
    [SerializeField] private UnityEvent OnEnter;
    [Tooltip("Unity event, which will execute when the required tag exits the collider")]
    [SerializeField] private UnityEvent OnExit;

    private void OnTriggerEnter(Collider other) {
        if (requiredTag == "") {
            OnEnter.Invoke();
        }
        else if (other.CompareTag(requiredTag)) {
            OnEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (requiredTag == "") {
            OnExit.Invoke();
        }
        else if (other.CompareTag(requiredTag)) {
            OnExit.Invoke();
        }
    }
}
