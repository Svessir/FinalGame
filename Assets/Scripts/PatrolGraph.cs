﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PatrolGraph : MonoBehaviour {
	#if UNITY_EDITOR
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
	#endif

    [System.Serializable]
    public class ListWrapper
    {
        public ListWrapper()
        {
            myList = new List<int>();
        }
        public List<int> myList;
    }
    public List<Vector3> Nodes = new List<Vector3>();
    public List<ListWrapper> Edges;
    public List<bool> Home = new List<bool>();
    public int test;
    public void ConnectNodes() {
        Transform[] children = GetComponentsInChildren<Transform>();
        Nodes = new List<Vector3>();
        Edges = new List<ListWrapper>();
        Home = new List<bool>();
        for (int i = 0; i < children.Length - 1; i++) {
            Edges.Add(new ListWrapper());
        }
        for (int i = 1; i < children.Length; i++) {
            Nodes.Add(children[i].position);
            Home.Add(children[i].tag == "Home");
            for (int j = i + 1; j < children.Length; j++) {
                Vector3 outside = children[i].position - children[j].position;
                //used so the raycast does not collide with itself
                outside.Normalize();
                outside *= 0.55f;
                if (!Physics.Linecast(children[i].position-outside, children[j].position+outside,~(3<<8 | 1 << 13))) {
                    Debug.Log("Connected: " + children[i].name + " to " + children[j].name);
                    Edges[i-1].myList.Add(j-1);
                    Edges[j-1].myList.Add(i-1);
                }
            }
        }
        test = Edges.Count;
        Debug.Log("connected edges inEditor " + Edges.Count);
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
        for (int i = 0; i < Nodes.Count; i++) {
            var el = Edges[i].myList;
            for (int j = 0; j < el.Count; j++) {
                //Debug.DrawLine(Nodes[i], Nodes[el[j]],Color.cyan,5);
            }
        }
    }
}
