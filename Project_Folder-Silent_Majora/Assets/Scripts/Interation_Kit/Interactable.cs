using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [Tooltip("Unity event, which executes when the interact key is pressed, if this object is the current interactable object")]
    [SerializeField] UnityEvent OnInteration;

    [Tooltip("Used for the interaction text.  e.g. ('pickup', 'open', etc.)")]
    public string actionText = "Fix_Me";
    // Start is called before the first frame update

    public void OnInteraction() {
        OnInteration.Invoke();
    }
}
