using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour {

    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private Interact playerInteract;

    void Update(){
        Plot plot = playerInteract.GetInteractable();

        if (plot != null && !plot.IsPlanted) {
        Show();
        } 
        else {
            Hide();
        }
    }

    private void Show() {
        containerGameObject.SetActive(true);
    }

    private void Hide() {
        containerGameObject.SetActive(false);
    }
}
