using UnityEngine;
using TMPro;

public class Interaction_text : MonoBehaviour
{
    public static Interaction_text instance;
    [SerializeField] TextMeshProUGUI interactionText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        SetVisibility(false);
    }

    public void SetInteractionText(string interactText) {
        if (interactionText == null) {
            Debug.Log("Interaction_text::SetInteractionText: No interaction text found");
            return;
        }

        interactionText.text = interactText;
    }

    public void SetInteractionText(KeyCode key, string actionText) {
        SetInteractionText("press '" + key.ToString() + "' to " + actionText);
    }

    public void SetVisibility(bool isVisible) {
        if(interactionText == null) {
            Debug.Log("Interaction_text::SetVisibility: No interaction text found");
            return;
        }

        interactionText.gameObject.SetActive(isVisible);
    }
}
