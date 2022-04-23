using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCone : MonoBehaviour
{
    [SerializeField] private StateManager state;
    [SerializeField] private Material mat;
    
    void Start()
    {
        CreateCameraCone();
    }

    void CreateCameraCone()
    {
        var cameras = state.cameras;
        Debug.Log("LOL" + cameras.Count);

        foreach (var cameraObj in cameras.Values)
        {
            Camera cam = cameraObj.transform.Find("Camera").GetComponent<Camera>();
            GameObject root = new GameObject();
            Mesh mesh = new Mesh();
            root.transform.position = Vector3.zero;
            root.AddComponent<MeshFilter>();
            root.AddComponent<MeshRenderer>();
            root.AddComponent<Renderer>();
            root.GetComponent<Renderer>().material = mat;
            root.GetComponent<MeshFilter>().mesh = mesh;
            root.name = cameraObj.name;
            root.transform.parent = gameObject.transform;
            root.SetActive(false);
            

            Vector3[] vertices = new Vector3[5];
            vertices[0] = cameraObj.transform.Find("Camera").transform.position;
            Plane[] cameraPlanes = GeometryUtility.CalculateFrustumPlanes(cam);
            Plane temp = cameraPlanes[1]; cameraPlanes[1] = cameraPlanes[2]; cameraPlanes[2] = temp;

            for (int i = 0; i < 4; i++)
            {
                vertices[i + 1] = Plane3Intersect(cameraPlanes[5], cameraPlanes[i], cameraPlanes[(i + 1) % 4]) -
                transform.position;
            }

            mesh.vertices = vertices;
            mesh.triangles = new int[]
            {
                1, 2, 3,
                1, 3, 4,
                0, 1, 4,
                0, 1, 2,
                0, 2, 3,
                0, 3, 4
            };
        }
        //
        // Vector3[] vertices = new Vector3[5];
        // vertices[0] = Vector3.zero;
        // Plane[] cameraPlanes = GeometryUtility.CalculateFrustumPlanes(cam);
        // Plane temp = cameraPlanes[1]; cameraPlanes[1] = cameraPlanes[2]; cameraPlanes[2] = temp;
        //
        // for ( int i = 0; i < 4; i++ )
        // {
        //     vertices[i + 1] = Plane3Intersect(cameraPlanes[5], cameraPlanes[i], cameraPlanes[(i + 1) % 4]) -
        //                       transform.position;
        // }
        //
        // mesh.vertices = vertices;
        // mesh.triangles = new int[]
        // {
        //     1, 2, 3,
        //     1, 3, 4,
        //     0, 1, 4,
        //     0, 1, 2,
        //     0, 2, 3,
        //     0, 3, 4
        // };
    }
    
    Vector3 Plane3Intersect ( Plane p1, Plane p2, Plane p3 ) { 
        return ( ( -p1.distance * Vector3.Cross( p2.normal, p3.normal ) ) +
                 ( -p2.distance * Vector3.Cross( p3.normal, p1.normal ) ) +
                 ( -p3.distance * Vector3.Cross( p1.normal, p2.normal ) ) ) /
               ( Vector3.Dot( p1.normal, Vector3.Cross( p2.normal, p3.normal ) ) );
    }
}
