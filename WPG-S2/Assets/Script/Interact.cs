using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private void Update(){

        if (Input.GetKeyDown(KeyCode.E)){
            Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, 8f);
            foreach (Collider2D collider in colliderArray) {
                if (collider.TryGetComponent(out Plot plant)) {
                    plant.Plant();
                }
            } 
        }
    }

    public Plot GetInteractable() {
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, 8f);
        foreach (Collider2D collider in colliderArray) {
            if (collider.TryGetComponent(out Plot plant)) {
                return plant;
            }
        }
        return null;
    }
}