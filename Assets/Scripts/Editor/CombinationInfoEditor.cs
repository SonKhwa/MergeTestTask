using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace miniit.MERGE
{
    [CustomEditor(typeof(CombinationInfo))]
    [CanEditMultipleObjects]
    public class CombinationInfoEditor : ScriptableObjectEditor
    {
        private SerializedProperty serializedPropertyParts;
        private SerializedProperty serializedPropertyResult;

        private void OnEnable()
        {
            if (serializedPropertyParts == null)
            {
                serializedPropertyParts = serializedObject.FindProperty("parts");
            }
            if (serializedPropertyResult == null)
            {
                serializedPropertyResult = serializedObject.FindProperty("result");
            }
        }

        public override void DrawCustomInspector()
        {
            DrawColors();
            DrawDefaultInspector();
        }

        private void DrawColors()
        {
            if (serializedPropertyParts.arraySize < 2 || serializedPropertyResult.boxedValue is null)
                return;

            ItemInfo part1 = serializedPropertyParts.GetArrayElementAtIndex(0).boxedValue as ItemInfo;
            ItemInfo part2 = serializedPropertyParts.GetArrayElementAtIndex(1).boxedValue as ItemInfo;
            ItemInfo part3 = serializedPropertyResult.boxedValue as ItemInfo;

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.ColorField(part1.Color);
            EditorGUILayout.LabelField("+", GUILayout.Width(20));
            EditorGUILayout.ColorField(part2.Color);
            EditorGUILayout.LabelField("=", GUILayout.Width(20));
            EditorGUILayout.ColorField(part3.Color);
            EditorGUILayout.EndHorizontal();
        }
    }
}
