using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace miniit.MERGE
{
    [CustomEditor(typeof(ItemInfo))]
    [CanEditMultipleObjects]
    public class ItemInfoEditor : ScriptableObjectEditor
    {
        private ItemInfo targetInfo;

        private void OnEnable()
        {
            if (targetInfo == null)
            {
                targetInfo = target as ItemInfo;
            }
        }

        public override void DrawCustomInspector()
        {
            SerializedProperty serializedPropertyList = serializedObject.FindProperty("combinations");

            Editor.DrawPropertiesExcluding(serializedObject, "combinations");
            DrawList(serializedPropertyList);
        }

        private void DrawList(SerializedProperty list)
        {
            EditorGUILayout.PropertyField(list);
            if (list.isExpanded)
            {
                EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
                ShowElements(list);
            }
            HandleAddButton(list);
            base.serializedObject.ApplyModifiedProperties();
        }

        private void ShowElements(SerializedProperty list, bool isNotHiddenElementLabels = false)
        {
            for (int i = 0; i < list.arraySize; i++)
            {
                EditorGUILayout.BeginHorizontal();
                if (isNotHiddenElementLabels)
                {
                    EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i));
                }
                else
                {
                    EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i), GUIContent.none);
                }
                HandleDeleteButton(list, i);
                EditorGUILayout.EndHorizontal();
            }
        }

        private void HandleDeleteButton(SerializedProperty list, int elementIndex)
        {
            if (GUILayout.Button("Delete", EditorStyles.miniButtonRight, GUILayout.ExpandWidth(false)))
            {
                Object.DestroyImmediate(list.GetArrayElementAtIndex(elementIndex).objectReferenceValue, true);
                targetInfo.combinations.RemoveAt(elementIndex);
                AssetDatabase.SaveAssets();
            }
        }

        private void HandleAddButton(SerializedProperty list)
        {
            if (GUILayout.Button("Add new combination", GUILayout.ExpandWidth(false)))
            {
                if (list.isExpanded == false)
                {
                    list.isExpanded = true;
                }
                CombinationInfo combination = ScriptableObject.CreateInstance<CombinationInfo>();
                targetInfo.combinations.Add(combination);

                AssetDatabase.AddObjectToAsset(combination, targetInfo);
                AssetDatabase.SaveAssets();
            }
        }
    }
}