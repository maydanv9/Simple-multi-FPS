using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteractable : MonoBehaviour
{
    //[Header("BaseRaycastableItem: ")]
    //[SerializeField] protected Outline outline;

    public virtual void OnRaycastStay()
    {
    }

    public virtual void OnRaycastEnter()
    {
    }
    public virtual void OnRaycastExit()
    {
    }

    public virtual void OnInterract()
    {
    }
}
