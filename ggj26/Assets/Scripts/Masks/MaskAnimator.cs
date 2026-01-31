using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Renderer))]
public class MaskAnimator : MonoBehaviour {

	[HideInInspector]
	public Animator animator;
	public Mask mask;
    new private Renderer renderer;

    public bool cameraFollow=false;
	void OnEnable()
	{
		animator = GetComponent<Animator>();
		renderer = GetComponent<Renderer>();
		animator.Rebind();
		animator.enabled = true;
		renderer.enabled = true;
	}

	public void OnDisable()
	{
		animator.enabled = false;
		renderer.enabled = false;
	}
}