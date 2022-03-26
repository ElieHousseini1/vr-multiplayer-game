using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomManager))]

public class RoomManagerEditScript : Editor
{
    public override void OnInspectorGUI(){
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This script is responsible for creating and joining rooms", MessageType.Info);

        RoomManager roomManager = (RoomManager) target;
        if(GUILayout.Button("Join Random Button")){
            roomManager.JoinRandomRoom();
        }
    }
}
