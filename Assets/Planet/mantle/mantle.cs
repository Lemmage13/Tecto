using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mantle : MonoBehaviour
{
    [Range(5, 1024)]
    public int pointNum = 100;
    public int radius = 1;

    public Vector3 core = new Vector3(0, 0, 0);

    public Vector3[] convectionPoints;

    public float globalBearing = Mathf.PI / 4;
    public float globalMag = 0.1F;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnValidate()
    {
        
    }
    //point in spherical coords on surface of sphere at iteration using fibonacci technique
    float[] FibonacciSphere(int n)
    {
        float angleIncrement = Mathf.PI * (1 + Mathf.Sqrt(5));
        float p = (float)n;

        float phi = Mathf.Acos(1 - 2 * p / pointNum);
        float theta = angleIncrement * p;

        return new float[] { phi, theta, radius };
    }
    float[] VectorDelta(float M, float b)
    {
        float c = Mathf.Tan(M / radius);                    //centre angle - basic trig
        float s_a = (Mathf.PI - c) / 2;                     //surface angle
        float s = Mathf.Sin(c) * radius / Mathf.Sin(s_a);   //surface chord length

        float Pphi = s * Mathf.Cos(b);                      //chord lengths associated with phi and theta angle deltas
        float Ptheta = s * Mathf.Sin(b);

        float dPhi = 2 * Mathf.Asin(Pphi / (2 * radius));   //simplified cosine rule for isoceles to find actual angle deltas
        float dTheta = 2 * Mathf.Asin(Ptheta / (2 * radius));

        float dRho = Mathf.Sqrt(M * M + radius * radius) - radius; //pythag for change in rho based on magnitude
        return new float[] {dPhi, dTheta, dRho};
    }
    Vector3 CartesianTransform(float phi, float theta, float rho)
    {
        float x = rho * Mathf.Sin(phi) * Mathf.Cos(theta);
        float y = rho * Mathf.Sin(phi) * Mathf.Sin(theta);
        float z = rho * Mathf.Cos(phi);

        return new Vector3(x, y, z);
    }
    Vector3[] TestTriangleMaker(float[] origin, float M, float b)
    {
        float[] F_v = VectorDelta(M, b);
        float[] L_v = VectorDelta(0.025F, b - Mathf.PI / 2);
        float[] R_v = VectorDelta(0.025F, b + Mathf.PI / 2);

        float[] headS = new float[3];
        float[] leftS = new float[3];
        float[] rightS = new float[3];
        for (int i = 0; i < origin.Length; i++)
        {
            headS[i] = origin[i] + F_v[i];
            leftS[i] = origin[i] + L_v[i];
            rightS[i] = origin[i] + R_v[i];
        }
        Vector3 head = CartesianTransform(headS[0], headS[1], headS[2]);
        Vector3 left = CartesianTransform(leftS[0], leftS[1], leftS[2]);
        Vector3 right = CartesianTransform(rightS[0], rightS[1], rightS[2]);

        return new Vector3[]{head, left, right};
    }
}


