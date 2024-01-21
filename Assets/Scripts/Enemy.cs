using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    public Target Target { get; private set; }

    private void Update()
    {
        if (Target != null)
        {
            MoveTarget();
        }
    }

    public void SetTarget(Target target)
    {
        Target = target;
    }

    private void MoveTarget()
    {
        transform.LookAt(Target.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
    }
}
