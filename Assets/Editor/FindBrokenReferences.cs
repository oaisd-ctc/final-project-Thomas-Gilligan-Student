using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class DeepReferenceChecker
{
    [MenuItem("Tools/Deep Scan for Missing References")]
    static void ScanProject()
    {
        string[] assetPaths = AssetDatabase.GetAllAssetPaths();
        int missingCount = 0;

        foreach (string path in assetPaths)
        {
            if (path.StartsWith("Assets") && (path.EndsWith(".prefab") || path.EndsWith(".unity") || path.EndsWith(".asset")))
            {
                Object obj = AssetDatabase.LoadMainAssetAtPath(path);
                GameObject go = obj as GameObject;

                if (go != null)
                {
                    if (ScanGameObject(go, path)) missingCount++;
                }
                else
                {
                    SerializedObject serializedObject = new SerializedObject(obj);
                    SerializedProperty prop = serializedObject.GetIterator();

                    while (prop.NextVisible(true))
                    {
                        if (prop.propertyType == SerializedPropertyType.ObjectReference && prop.objectReferenceValue == null && prop.objectReferenceInstanceIDValue != 0)
                        {
                            Debug.LogWarning($"Missing reference in {path} at property: {prop.displayName}", obj);
                            missingCount++;
                        }
                    }
                }
            }
        }

        Debug.Log($"Scan complete. Found {missingCount} missing references.");
    }

    static bool ScanGameObject(GameObject go, string path)
    {
        bool foundMissing = false;

        Component[] components = go.GetComponentsInChildren<Component>(true);
        foreach (Component component in components)
        {
            if (component == null)
            {
                Debug.LogWarning($"Missing script in GameObject: {GetFullPath(go)} ({path})");
                foundMissing = true;
                continue;
            }

            SerializedObject so = new SerializedObject(component);
            SerializedProperty prop = so.GetIterator();
            while (prop.NextVisible(true))
            {
                if (prop.propertyType == SerializedPropertyType.ObjectReference && prop.objectReferenceValue == null && prop.objectReferenceInstanceIDValue != 0)
                {
                    Debug.LogWarning($"Missing reference in {GetFullPath(go)} > {component.GetType().Name}, property: {prop.displayName} ({path})", component);
                    foundMissing = true;
                }
            }
        }

        return foundMissing;
    }

    static string GetFullPath(GameObject obj)
    {
        string path = obj.name;
        Transform current = obj.transform;
        while (current.parent != null)
        {
            current = current.parent;
            path = current.name + "/" + path;
        }
        return path;
    }
}
