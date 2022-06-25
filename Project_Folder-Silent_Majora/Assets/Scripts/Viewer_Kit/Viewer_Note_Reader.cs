using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Viewer_Note_Reader : MonoBehaviour
{
    public Viewer_object obj;
    [SerializeField] KeyCode toggleEasyReadBtn = KeyCode.Space;
    [SerializeField] GameObject noteReadingPanel;
    [SerializeField] TextMeshProUGUI noteText;

    void Start() {
        if (obj == null) obj = FindObjectOfType<Viewer_object>();
    }

    public void SetNoteTextVisibility(bool isShow) {
        if (obj.note == null && isShow) return;

        noteReadingPanel.SetActive(isShow);
        if(isShow) noteText.text = obj.note.note_text;
    }

    // Update is called once per frame
    void Update()
    {
        if (obj == null) obj = ItemViewer.instance.viewedItem.GetComponent<Viewer_object>();

        if (Input.GetKeyDown(toggleEasyReadBtn)) {
            SetNoteTextVisibility(!noteReadingPanel.activeInHierarchy);
        }
    }
}
