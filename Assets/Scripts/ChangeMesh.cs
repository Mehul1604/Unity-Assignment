using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMesh : MonoBehaviour
{
    // Start is called before the first frame update
    private MeshFilter mesh_filter;
    private Mesh cur_mesh;
    private Mesh new_mesh;
    
    void Start()
    {
        mesh_filter = GetComponent<MeshFilter>();
        cur_mesh = mesh_filter.mesh;
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        new_mesh = Instantiate(obj.GetComponent<MeshFilter>().mesh);
        Destroy(obj);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(mesh_filter.mesh);
    }

    void OnBecameVisible()
    {
        // Debug.Log("back to capsule");
        mesh_filter.mesh = new_mesh;
    }

    void OnBecameInvisible()
    {
        // Debug.Log("to Cube");
        mesh_filter.mesh = cur_mesh;
    }
}
