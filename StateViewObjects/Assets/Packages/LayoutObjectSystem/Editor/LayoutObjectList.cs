namespace LayoutObjectSystem.Editor
{
    using UnityEditor;
    using UnityEngine;
    
    public static class LayoutObjectList {
        private static GUIContent moveButtonContent = new GUIContent("\u21b4", "Move down");
        private static GUIContent duplicateButtonContent = new GUIContent("+", "Duplicate");
        private static GUIContent deleteButtonContent = new GUIContent("-", "Delete");
        private static GUIContent addButtonContent = new GUIContent("+", "Add element");

        private static GUIContent showButtonContent = new GUIContent("Show", "Show layout");
        private static GUIContent applyButtonContent = new GUIContent("Apply", "Save layout");

        private static GUILayoutOption miniButtonWidth = GUILayout.Width(20f);
        private static GUILayoutOption actionButtonWidth = GUILayout.Width(50f);
        
        public static void Show (SerializedProperty list, LayoutListOptions options = LayoutListOptions.Default) 
        {
            if (!list.isArray) {
                EditorGUILayout.HelpBox(list.name + " is neither an array nor a list!", MessageType.Error);
                return;
            }

            EditorGUILayout.PropertyField(list);
            EditorGUI.indentLevel += 1;

            if (list.isExpanded) {
                if ((options & LayoutListOptions.Size) != 0)
                {
                    EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"), true);
                }
                
                ShowElements(list, options);
            }

            EditorGUI.indentLevel -= 1;
        }

        private static void ShowElements (SerializedProperty list, LayoutListOptions options) {
            for (int i = 0; i < list.arraySize; i++) 
            {
                EditorGUILayout.BeginHorizontal();

                SerializedProperty elementList = list.GetArrayElementAtIndex(i);
                EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i), true);

                ShowButtons(list, i, options);
                EditorGUILayout.EndHorizontal();
            }

            if (list.arraySize == 0 && GUILayout.Button(addButtonContent, EditorStyles.miniButton)) {
                list.arraySize += 1;
                
            }
        }

        
        private static void ShowButtons (SerializedProperty list, int index, LayoutListOptions options) {
            if (GUILayout.Button(moveButtonContent, EditorStyles.miniButtonLeft, miniButtonWidth))
            {
                list.MoveArrayElement(index, index + 1);
            }
            if (GUILayout.Button(duplicateButtonContent, EditorStyles.miniButtonMid, miniButtonWidth))
            {
                list.InsertArrayElementAtIndex(index);
                
            }
            if (GUILayout.Button(deleteButtonContent, EditorStyles.miniButtonRight, miniButtonWidth))
            {
                list.DeleteArrayElementAtIndex(index);
            }

            GUI.backgroundColor = Color.green;
            if(GUILayout.Button(applyButtonContent, EditorStyles.miniButton, actionButtonWidth))
            {
                LayoutState layoutState = list.serializedObject.targetObject as LayoutState;
                layoutState.layouts[index].Save(layoutState.objectsReference);
            }

            GUI.backgroundColor = Color.yellow;
            if(GUILayout.Button(showButtonContent, EditorStyles.miniButton, actionButtonWidth))
            {
                LayoutState layoutState = list.serializedObject.targetObject as LayoutState;
                layoutState.layouts[index].Load(layoutState.objectsReference);
            }
            GUI.backgroundColor = Color.white;
        }
 
    }
}