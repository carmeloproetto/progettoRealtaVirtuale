using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Interactable : MonoBehaviour
{
    public Sprite icon;

    public abstract void Interact(GameObject caller);
    public abstract string GetDescription();

    public Sprite getImageIcon()
    {
        return icon; 
    }
}
