using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MaskAnimator : MonoBehaviour {

	[HideInInspector]
	public Animator animator;
	public Mask mask;

    public bool cameraFollow=false;
	void OnEnable()
	{
		animator = GetComponent<Animator>();
	}
}