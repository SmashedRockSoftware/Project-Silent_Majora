using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateSwitcher : MonoBehaviour
{
    public static MenuStateSwitcher instance;
    [SerializeField] GameObject itemViewer;
    [SerializeField] GameObject levelViewer;
    [SerializeField] GameObject inventoryViewer;

    public enum MenuState {
        inGame,
        itemViewer,
        inventoryViewer,
        journalViewer,
        pauseViewer,
        settingsViewer
    }

    public MenuState currentMenuState = MenuState.inGame;

    private void Start() {
        instance = this;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.I)) SwitchMenuState(MenuState.inventoryViewer);
    }

    public void SwitchMenuByString(string newState) {
        switch (newState) {
            case "itemViewer": //true  //false
                SwitchMenuState(MenuState.itemViewer);
                break;
            case "inventoryViewer":
                SwitchMenuState(MenuState.inventoryViewer);
                break;
            case "journalViewer":
                SwitchMenuState(MenuState.journalViewer);
                break;
            case "pauseViewer":
                SwitchMenuState(MenuState.pauseViewer);
                break;
            case "settingsViewer":
                SwitchMenuState(MenuState.settingsViewer);
                break;
            default:
                SwitchMenuState(MenuState.inGame);
                break;
        }
    }

    public void SwitchMenuState(MenuState newMenuState) {
        currentMenuState = newMenuState;

        itemViewer.SetActive(false);
        levelViewer.SetActive(false);
        inventoryViewer.SetActive(false);

        switch (newMenuState) {
            case MenuState.itemViewer:
                itemViewer.SetActive(true);
                break;
            case MenuState.inventoryViewer:
                inventoryViewer.SetActive(true);
                break;
            case MenuState.journalViewer:
                Debug.LogError("No Journal yet!!!");
                break;
            case MenuState.pauseViewer:
                Debug.LogError("No pause yet!!!");
                break;
            case MenuState.settingsViewer:
                Debug.LogError("No settings yet!!!");
                break;
            default:
                levelViewer.SetActive(true);
                break;
        }
    }
}
