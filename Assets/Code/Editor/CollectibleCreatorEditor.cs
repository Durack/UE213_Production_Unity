using PathCreation;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CollectibleCreator))]
public class CollectibleCreatorEditor : Editor
{
    SerializedProperty prefabs;


    private void OnEnable()
    {
        prefabs = serializedObject.FindProperty("prefabs");
    }

    public override void OnInspectorGUI()
    {
        CollectibleCreator myScript = (CollectibleCreator)target;
        myScript.pathCreator = (PathCreator)EditorGUILayout.ObjectField("Path", myScript.pathCreator, typeof(PathCreator), true);
        myScript.vehicle = (GameObject)EditorGUILayout.ObjectField("Vehicle", myScript.vehicle, typeof(GameObject), true);

        serializedObject.Update();
        EditorGUILayout.PropertyField(prefabs, true);
        serializedObject.ApplyModifiedProperties();

        GUILayout.Space(20);

        EditorGUILayout.LabelField("Random Path Generator", EditorStyles.boldLabel);

        myScript.prefab = (GameObject)EditorGUILayout.ObjectField("Collectible", myScript.prefab, typeof(GameObject), true);
        myScript.beatsBeforeSpawning = EditorGUILayout.IntField("Starting spawn beat", myScript.beatsBeforeSpawning);
        myScript.beatsBetweenSpawn = EditorGUILayout.IntField("Beat gap between spawn", myScript.beatsBetweenSpawn);
        myScript.spawnGroupSize = EditorGUILayout.IntField("Spawn group size", myScript.spawnGroupSize);
        myScript.beatsBetweenGroup = EditorGUILayout.IntField("Beat gap between group", myScript.beatsBetweenGroup);
        if (GUILayout.Button("Generate Random Path"))
        {
            myScript.GenerateRandomPath();
        }

        GUILayout.Space(20);

        EditorGUILayout.LabelField("Saves Manager", EditorStyles.boldLabel);
        myScript.fileName = EditorGUILayout.TextField("File Name", myScript.fileName);

        if (GUILayout.Button("Save collectibles"))
        {
            myScript.Save();
        }

        if (GUILayout.Button("Load collectibles"))
        {
            myScript.Load();
        }

    }
}
