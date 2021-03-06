﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlabManager : MonoBehaviour {
    public static SlabManager thisManager;

    public Transform hand;
    public bool slabOpen = false;
    public bool toggling = true;

    Animator anim;
    Transform currentTab;
    Transform currentMenu;
    public GameObject[] tabs;
    public GameObject[] menus;
    
    public int tabOpen = 0;

    void Awake() {
        anim = transform.GetComponent<Animator>();
        thisManager = this;
        tabs = GameObject.FindGameObjectsWithTag("Tab");
        menus = GameObject.FindGameObjectsWithTag("Menu");

        if (tabs.Length != 0) {
            for (int a = 1; tabs.Length > a; a++) {
                tabs[a].GetComponent<CanvasGroup>().interactable = false;
                tabs[a].GetComponent<CanvasGroup>().alpha = 0;
                tabs[a].GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
            currentTab = tabs[0].transform;
        }

        if (menus.Length != 0) {
            for (int a = 1; menus.Length > a; a++) {
                menus[a].GetComponent<CanvasGroup>().interactable = false;
                menus[a].GetComponent<CanvasGroup>().alpha = 0;
                menus[a].GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
            currentMenu = menus[0].transform;
        }

    }
    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            SlabToggle();
        }
    }
    //Activated by a button to switch between menus
    public void ChangeTab(Transform tab) {

        if (currentTab != null) {
            currentTab.GetComponent<CanvasGroup>().interactable = false;
            currentTab.GetComponent<CanvasGroup>().blocksRaycasts = false;
            currentTab.GetComponent<CanvasGroup>().alpha = 0;
        }
        currentTab = tab;
        tabOpen = tab.GetSiblingIndex();
        print(tabOpen);
        //InventoryManager.thisManager.ResetSelected();
        currentTab.GetComponent<CanvasGroup>().interactable = true;
        currentTab.GetComponent<CanvasGroup>().blocksRaycasts = true;
        currentTab.GetComponent<CanvasGroup>().alpha = 1;

    }
    public void ChangeMenu(Transform menu) {
        if (currentMenu != null) {
            currentMenu.GetComponent<CanvasGroup>().interactable = false;
            currentMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
            currentMenu.GetComponent<CanvasGroup>().alpha = 0;
        }
        currentMenu = menu;
        currentMenu.GetComponent<CanvasGroup>().interactable = true;
        currentMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
        currentMenu.GetComponent<CanvasGroup>().alpha = 1;

    }
    // Temporary anim. Later on this will be activated in the arms
    public void SlabToggle() {
        if (toggling) {
            slabOpen = !slabOpen;
            GetComponent<Animator>().SetBool("Open", slabOpen);
            CursorLock.Lock();
        }
    }

}
