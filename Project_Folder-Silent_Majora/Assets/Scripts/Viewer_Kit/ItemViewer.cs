using UnityEngine;

public class ItemViewer : MonoBehaviour
{
    public static ItemViewer instance;
    [SerializeField] GameObject item_pivot;
    public GameObject viewedItem;
    [SerializeField] Viewer_Note_Reader reader;

    [SerializeField] MenuStateSwitcher.MenuState lastMenuState;
    KeyCode escapeKey = KeyCode.Escape;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //reader = gameObject.GetComponent<Viewer_Note_Reader>();
    }

    public void ViewItem(GameObject itemToBeViewed) {
        lastMenuState = MenuStateSwitcher.instance.currentMenuState;
        MenuStateSwitcher.instance.SwitchMenuState(MenuStateSwitcher.MenuState.itemViewer);
        viewedItem = Instantiate(itemToBeViewed, item_pivot.transform.position, itemToBeViewed.transform.rotation) as GameObject;
    }

    public void HideItemViewer() {
        MenuStateSwitcher.instance.SwitchMenuState(lastMenuState);
        reader.SetNoteTextVisibility(false);
        Destroy(viewedItem);
    }

    private void Update() {
        if (Input.GetKeyDown(escapeKey)) HideItemViewer();
    }
}
