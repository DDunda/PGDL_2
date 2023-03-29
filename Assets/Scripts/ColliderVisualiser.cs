using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteAlways]
public class ColliderVisualiser : MonoBehaviour {
	public BoxCollider2D boxCollider;
	public bool isLevel = true;

	public void Update()
	{
        transform.localPosition = boxCollider.offset;
        transform.localScale = boxCollider.size;

		if (!isLevel) return;

		var stage = PrefabStageUtility.GetCurrentPrefabStage();

		if (stage != null && stage.IsPartOfPrefabContents(gameObject)) return;

		Transform p = GameObject.FindWithTag("Level").transform;

		if(p == null) return;
		if(boxCollider.transform.parent == p) return;

        boxCollider.transform.SetParent(p, true);
	}
}