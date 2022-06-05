using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace miniit.MERGE
{
    public abstract class ScriptableObjectEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            UpdateSerializedObject();
            DrawCustomInspector();
            ApplyChanges();
        }

        public virtual void UpdateSerializedObject()
        {
            serializedObject.Update();
        }

        public abstract void DrawCustomInspector();

        public virtual void ApplyChanges()
        {
            serializedObject.ApplyModifiedProperties();
            /*if (GUI.changed)
            {
                EditorUtility.SetDirty(target);
                EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
                AssetDatabase.SaveAssets();
                Repaint();
            }*/
        }
    }
}
