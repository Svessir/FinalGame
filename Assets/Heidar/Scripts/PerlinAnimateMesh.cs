using UnityEngine;
using System.Collections;

public class PerlinAnimateMesh : MonoBehaviour
{
	public float perlinScale = 4.56f;
	public float waveSpeed = 1f;
	public float waveHeight = 2f;

	private Mesh mesh;
	private Vector3[] originalMesh;

	void Start() {
		mesh = GetComponent< MeshFilter >().mesh;
		originalMesh = mesh.vertices;
	}

	void Update()
	{
		AnimateMesh();
	}

	void AnimateMesh()
	{


		Vector3[] vertices = mesh.vertices;

		float waveMagni = Time.timeSinceLevelLoad * waveSpeed;

		for (int i = 0; i < 11; i++) {
			
			for (int j = 0; j < 11; j++) {
				int place = i * 11 + j;
				float pY = ( vertices[place].y * perlinScale ) + ( waveMagni );
				float pZ = ( vertices[place].z * perlinScale ) + ( waveMagni );

				vertices[place].x = originalMesh[place].x + ( Mathf.PerlinNoise( pY, pZ ) - 0.5f ) * waveHeight;
			}
		}

//		for (int i = 0; i < 11; i++) {
//			for (int j = 0; j < 10; j++) {
//				int place = i * 11 + j;
//				float pX = ( vertices[place].x * perlinScale ) + ( Time.timeSinceLevelLoad * waveSpeed );
//				float pZ = ( vertices[place].z * perlinScale ) + ( Time.timeSinceLevelLoad * waveSpeed );
//
//				vertices[place].y = ( Mathf.PerlinNoise( pX, pZ ) - 0.5f ) * waveHeight;
//			}
//		}

//		for (int i = 0; i < vertices.Length; i++)
//		{
//			float pX = ( vertices[i].x * perlinScale ) + ( Time.timeSinceLevelLoad * waveSpeed );
//			float pZ = ( vertices[i].z * perlinScale ) + ( Time.timeSinceLevelLoad * waveSpeed );
//
//			vertices[i].y = ( Mathf.PerlinNoise( pX, pZ ) - 0.5f ) * waveHeight;
//		}

		mesh.vertices = vertices;
	}
}