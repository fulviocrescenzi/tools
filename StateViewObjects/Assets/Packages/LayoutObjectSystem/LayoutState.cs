namespace LayoutObjectSystem
{
    using UnityEngine;
    using System.Collections.Generic;

    public class LayoutState : MonoBehaviour {
        
        public List<GameObject> objectsReference = new List<GameObject>();
        public List<LayoutObject> layouts = new List<LayoutObject>();

        void Awake()
        {
        }

        public void Show(string stateName)
        {
            for (int i = 0; i < layouts.Count; i++)
            {
                if (layouts[i].stateName == stateName)
                {
                    layouts[i].Load(objectsReference);
                    break;
                }
            }
        }
    }
}