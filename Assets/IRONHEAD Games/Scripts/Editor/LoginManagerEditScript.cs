using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LoginManager))]
public class LoginManagerEditScript : Editor
{
    public override void OnInspectorGUI(){
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This script is responsible for connecting to Photon servers", MessageType.Info);

        LoginManager loginManager = (LoginManager)target;

        if(GUILayout.Button("Connect Anynomously")){
            loginManager.connectAnynomously();
        }
        }
}
