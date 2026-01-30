using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MaskAnimator : MonoBehaviour {

	[HideInInspector]
	public Animator animator;
	public Mask mask;
	void OnEnable()
	{
		animator = GetComponent<Animator>();
	}
}