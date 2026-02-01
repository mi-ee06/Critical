using UnityEngine;

public class SlimeTest:MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform slime;
    [SerializeField] private Transform target;

    private SlimeMovement slimeMovement;
    private void Start()
    {
        slimeMovement = new SlimeMovement(slime, animator);
        slimeMovement.Rush(target);
    }
}
