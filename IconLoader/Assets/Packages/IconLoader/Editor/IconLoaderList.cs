namespace FulCode.IconLoader.Editor
{
    using UnityEditor;
    using UnityEngine;

    public static class IconLoaderList {
        private static GUIContent moveButtonContent = new GUIContent("\u21b4", "move down");
        private static GUIContent duplicateButtonContent = new GUIContent("+", "duplicate");
        private static GUIContent deleteButtonContent = new GUIContent("-", "delete");
        private static GUIContent addButtonContent = new GUIContent("+", "add element");

        private static GUILayoutOption miniButtonWidth = GUILayout.Width(20f);
        
        public static void Show (SerializedProperty keys, SerializedProperty data) 
        {
            if (!keys.isArray) {
                EditorGUILayout.HelpBox(keys.name + " is neither an array nor a list!", MessageType.Error);
                return;
            }

            //EditorGUILayout.PropertyField(keys);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Elements, insert key and sprite associated");
            EditorGUILayout.Space();
            EditorGUI.indentLevel += 1;

            ShowElements(keys, data);                

            if (keys.arraySize == 0 && GUILayout.Button(addButtonContent, EditorStyles.miniButton)) {
                keys.arraySize += 1;
                data.arraySize += 1;
            }

            EditorGUI.indentLevel -= 1;
        }

        private static void ShowElements (SerializedProperty keys, SerializedProperty data) {
            for (int i = 0; i < keys.arraySize; i++) 
            {
                EditorGUILayout.BeginHorizontal();

                GUILayoutOption keyOp = GUILayout.MinWidth(100);
                GUILayoutOption dataOp = GUILayout.MinWidth(100);

                SerializedProperty elementList = keys.GetArrayElementAtIndex(i);
                EditorGUILayout.PropertyField(keys.GetArrayElementAtIndex(i), GUIContent.none, keyOp);
                EditorGUILayout.PropertyField(data.GetArrayElementAtIndex(i), GUIContent.none, dataOp);

                ShowButtons(keys, data, i);
                EditorGUILayout.EndHorizontal();
            }
        }

        private static void ShowButtons (SerializedProperty keys, SerializedProperty data, int index) {
            if (GUILayout.Button(moveButtonContent, EditorStyles.miniButtonLeft, miniButtonWidth))
            {
                keys.MoveArrayElement(index, index + 1);
                data.MoveArrayElement(index, index + 1);
            }
            if (GUILayout.Button(duplicateButtonContent, EditorStyles.miniButtonMid, miniButtonWidth))
            {
                keys.InsertArrayElementAtIndex(index);
                data.InsertArrayElementAtIndex(index);
            }
            if (GUILayout.Button(deleteButtonContent, EditorStyles.miniButtonRight, miniButtonWidth))
            {
                keys.DeleteArrayElementAtIndex(index);
                data.DeleteArrayElementAtIndex(index);
            }
        }
    }
}