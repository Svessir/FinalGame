using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PatrolGraph : MonoBehaviour {
    [CustomEditor(typeof(PatrolGraph))]
    public class ObjectBuilderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            PatrolGraph myScript = (PatrolGraph)target;
            if (GUILayout.Button("Raycast Connect Nodes"))
            {
                myScript.ConnectNodes();
            }
        }
    }
    public List<Vector3> Nodes = new List<Vector3>();
    public List<List<int>> Edges = new List<List<int>>();
    public void ConnectNodes() {
        Transform[] children = GetComponentsInChildren<Transform>();
        Nodes = new List<Vector3>();
        Edges = new List<List<int>>();
        for (int i = 0; i < children.Length - 1; i++) {
            Edges.Add(new List<int>());
        }
        for (int i = 1; i < children.Length; i++) {
            Nodes.Add(children[i].position);
            for (int j = i + 1; j < children.Length; j++) {
                if (Physics.Linecast(children[i].position, children[j].position, ~(1 << 11))) {
                    Debug.Log("Connected: " + children[i].name + " to " + children[j].name);
                    Edges[i].Add(j);
                    Edges[j].Add(i);
                }
            }
        }
    }
    void Start()
    {
        MeshRenderer[] meshes = GetComponentsInChildren<MeshRenderer>();
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach(MeshRenderer m in meshes) {
            m.enabled = false;
        }
        foreach (Collider c in colliders) {
            Destroy(c);
        }
    }
}
