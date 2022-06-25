using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    [Tooltip("The length of the ray which checks for interactable objects")]
    [SerializeField] float maxDist = 3f;
    Interactable lastInteractObj;

    KeyCode InteractKey = KeyCode.E;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update() {
        if(lastInteractObj != null && Input.GetKeyDown(InteractKey)) {
            lastInteractObj.OnInteraction();
            lastInteractObj = null;  //prevents interaction next frame unless object is aquired, this plus key down should prevent double activations
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDist, layerMask)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            lastInteractObj = hit.collider.gameObject.GetComponent<Interactable>();
            if (lastInteractObj != null) {
                Interaction_text.instance.SetInteractionText(InteractKey, lastInteractObj.actionText);
                Interaction_text.instance.SetVisibility(true);
            }
        }
        else {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxDist, Color.white);
            lastInteractObj = null;
            Interaction_text.instance.SetVisibility(false);
        }
    }
}
