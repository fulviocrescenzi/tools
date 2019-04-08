using UnityEngine;
using LayoutObjectSystem;

public class StoreItemBehavior : MonoBehaviour
{
    private LayoutState layoutState;

    void Awake() {
        layoutState = GetComponentInChildren<LayoutState>();
    }

    public void ShowState(string stateName)
    {
        layoutState.Show(stateName);
    }
}