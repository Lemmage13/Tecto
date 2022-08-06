using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mantle : MonoBehaviour
{
    public GameObject pointBall;

    [Range(5,256)]
    public float pointNum;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < pointNum; i++)
        {

        }
    }
    private void OnValidate()
    {
        Start();
    }
    Vector3 FibonacciSphere(int n)
    {
        float angleIncrement = Mathf.PI * (1 + Mathf.Sqrt(5));


        float phi = Mathf.Acos(1 - 2 * n / pointNum);
        float theta = angleIncrement * n;

        float x = Mathf.Sin(phi)*Mathf.Cos(theta);
        float y = Mathf.Sin(phi)*Mathf.Sin(theta);
        float z = Mathf.Cos(phi);

        return new Vector3(x, y, z);
    }
    
}
