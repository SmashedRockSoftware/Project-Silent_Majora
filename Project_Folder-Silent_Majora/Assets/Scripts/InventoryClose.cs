using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryClose : MonoBehaviour
{
    KeyCode escapeKey = KeyCode.Escape;

    private void Update() {
        if (Input.GetKeyDown(escapeKey)) MenuStateSwitcher.instance.SwitchMenuState(MenuStateSwitcher.MenuState.inGame);
    }
}
