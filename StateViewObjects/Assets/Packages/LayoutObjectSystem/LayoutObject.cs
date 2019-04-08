namespace LayoutObjectSystem
{
    using UnityEngine;
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class LayoutObject
    {
        public string stateName = "abc";

        [HideInInspector]
        public bool[] enables;

        [HideInInspector]
        public Vector3[] positions;

        [HideInInspector]
        public Vector3[] scales;

        [HideInInspector]
        public Vector2[] sizeDeltas;

        [HideInInspector]
        public Quaternion[] rotations;

        public void Save(List<GameObject> objectReferences)
        {
            enables = new bool[objectReferences.Count];
            positions = new Vector3[objectReferences.Count];
            scales = new Vector3[objectReferences.Count];
            sizeDeltas = new Vector2[objectReferences.Count];
            rotations = new Quaternion[objectReferences.Count];

            for (int i = 0; i < objectReferences.Count; i++)
            {
                enables[i] = objectReferences[i].activeInHierarchy;
                positions[i] = objectReferences[i].transform.localPosition;

                if (objectReferences[i].transform is RectTransform)
                {
                    Vector2 sizeDelta = (objectReferences[i].transform as RectTransform).sizeDelta;
                    sizeDeltas[i] = sizeDelta;
                }
                else
                {
                    scales[i] = objectReferences[i].transform.localScale;
                }
                
                rotations[i] = objectReferences[i].transform.rotation;
            }
        }

        public void Load(List<GameObject> objectReferences)
        {
            if (objectReferences != null)
            {
                for (int i = 0; i < objectReferences.Count; i++)
                {
                    if (i < enables.Length)
                    {
                        objectReferences[i].SetActive(enables[i]);
                    }

                    if (i < positions.Length)
                    {
                        objectReferences[i].transform.localPosition = positions[i];
                    }

                    if (i < scales.Length)
                    {
                        if (objectReferences[i].transform is RectTransform)
                        {
                            (objectReferences[i].transform as RectTransform).sizeDelta = sizeDeltas[i];
                        }
                        else
                        {
                            objectReferences[i].transform.localScale = scales[i];
                        }
                    }

                    if (i < rotations.Length)
                    {
                        objectReferences[i].transform.rotation = rotations[i];
                    }
                }
            }
        }
    }
}