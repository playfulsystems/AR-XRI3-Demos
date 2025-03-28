using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public Vector3 TargetPos; // (0,0,0)
    public float Speed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToTarget = TargetPos - transform.position;

        if (directionToTarget.magnitude < Speed * Time.deltaTime)    
        {
            transform.position = TargetPos;
        }
        else   
        {
            transform.position += directionToTarget.normalized * Speed * Time.deltaTime;
        }
    }
}
