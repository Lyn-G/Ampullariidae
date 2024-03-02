using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class VerticalPlane: MonoBehaviour
{
    void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        // Define the vertices of the vertical plane
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-0.5f, 0.0f, 0.0f), // Bottom left
            new Vector3(0.5f, 0.0f, 0.0f), // Bottom right
            new Vector3(-0.5f, 1.0f, 0.0f), // Top left
            new Vector3(0.5f, 1.0f, 0.0f) // Top right
        };

        // Define the triangles (two triangles form a square plane)
        int[] triangles = new int[]
        {
            0, 2, 1, // First triangle
            2, 3, 1 // Second triangle
        };

        // Define the normals
        Vector3[] normals = new Vector3[]
        {
            -Vector3.forward, // Bottom left
            -Vector3.forward, // Bottom right
            -Vector3.forward, // Top left
            -Vector3.forward // Top right
        };

        // Define UVs for the texture mapping
        Vector2[] uv = new Vector2[]
        {
            new Vector2(0, 0), // Bottom left
            new Vector2(1, 0), // Bottom right
            new Vector2(0, 1), // Top left
            new Vector2(1, 1) // Top right
        };

        // Assign arrays to the mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;

        // Optional: Optimize the mesh for performance
        mesh.Optimize();
    }
}
