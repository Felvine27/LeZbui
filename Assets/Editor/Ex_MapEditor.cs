using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//https://docs.unity3d.com/ScriptReference/EditorWindow.html
public class Ex_MapEditor : EditorWindow
{
    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;
    bool[,] map = new bool[50, 50];
    public GameObject m_prefab;

    // Add menu named "My Window" to the Window menu
    [MenuItem("Technifutur/Create Map")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        Ex_MapEditor window = (Ex_MapEditor)EditorWindow.GetWindow(typeof(Ex_MapEditor));
        window.Show();
    }
    public float buttonSize = 20;
    void OnGUI()
    {
        m_prefab = (GameObject) EditorGUILayout.ObjectField(m_prefab, typeof(GameObject), true);
        if (GUILayout.Button("Create")) {
            GameObject parent = new GameObject("Created Map");
            for (int x = 0; x < 50; x++)
            {
                for (int y = 0; y < 50; y++)
                {
                    if (map[x, y])
                    {
                    GameObject g = GameObject.Instantiate(m_prefab);
                    g.transform.parent = parent.transform;
                    g.transform.localPosition = new Vector3(x, 0, y);

                    }
                   
                }
            }
        }

        for (int x = 0; x < 50; x++)
        {
            GUILayout.BeginHorizontal();
            for (int y = 0; y < 50; y++)
            {
                if (GUILayout.Button(map[x, y] ? "#" : " ", GUILayout.Width(buttonSize), GUILayout.Height(buttonSize))) {
                    map[x, y] = !map[x, y];
                }
                
                //map[x, y] = EditorGUILayout.Toggle(map[x, y] ? "#" : " ", map[x, y], GUILayout.Width(buttonSize), GUILayout.Height(buttonSize)); 

            }
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();

        

    }
}