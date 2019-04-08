namespace FulCode.IconLoader.Editor
{
    using UnityEditor;
    using UnityEngine;
    using System;

    [Serializable]
    [CustomEditor(typeof(IconLoader))]
    public class IconLoaderEditor: Editor
    {
        private SerializedProperty keys;
        private SerializedProperty data;

        void OnEnable() 
        {
            keys = serializedObject.FindProperty("keys");
            data = serializedObject.FindProperty("data");
        }

        public override void OnInspectorGUI() 
        {
            serializedObject.Update();
            //EditorGUILayout.PropertyField(objectsReference, true);
            IconLoaderList.Show(keys, data);

            serializedObject.ApplyModifiedProperties();
        }
    }
}