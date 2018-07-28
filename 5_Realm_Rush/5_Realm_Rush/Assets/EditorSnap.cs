using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour {

    [SerializeField] [Range(1, 100)] int gridSize = 10;

	
	void Update () {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
	}
}
