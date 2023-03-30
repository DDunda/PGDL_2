using UnityEngine;

[ExecuteAlways]
public class ColliderVisualiser : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    public bool isLevel = true;

    public void Start()
    {
        boxCollider = transform.parent.GetComponent<BoxCollider2D>();
    }

    public void Update()
	{
        if (boxCollider != null)
        {
            transform.localPosition = boxCollider.offset;
            transform.localScale = boxCollider.size;
        }

		if (!isLevel) return;

		Transform p = GameObject.FindWithTag("Level").transform;

		if(p == null) return;
        if(transform.parent.parent == p) return;
        if(p.gameObject.scene != gameObject.scene) return;

        transform.parent.SetParent(p, true);
	}
}