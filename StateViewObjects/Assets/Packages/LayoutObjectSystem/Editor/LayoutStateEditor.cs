namespace LayoutObjectSystem.Editor
{
    using UnityEditor;
    using UnityEngine;
    using System;

    [Serializable]
    [CustomEditor(typeof(LayoutState))]
    public class LayoutStateEditor: Editor
    {
        private SerializedProperty objectsReference;
        private SerializedProperty layouts;

        void OnEnable() 
        {
            objectsReference = serializedObject.FindProperty("objectsReference");
            layouts = serializedObject.FindProperty("layouts");
        }

        public override void OnInspectorGUI() 
        {
            serializedObject.Update();
            //EditorGUILayout.PropertyField(objectsReference, true);
            LayoutStateList.Show(objectsReference);
            LayoutObjectList.Show(layouts, LayoutListOptions.All);

            serializedObject.ApplyModifiedProperties();
        }
    }
}