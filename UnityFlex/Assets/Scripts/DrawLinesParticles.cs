using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NVIDIA.Flex;

public class DrawLinesParticles : MonoBehaviour
{
    public FlexContainer fcContainer;
    public FlexSourceActor fsaFlexSourceActor;
    public GameObject goLineTraceByParticle;
    public Gradient GGradientColor;
    public int iNumberLines;
    public float fTimeBetweenPos;
    public int iParticleToSkip;
    public int iParticleMeshNumber;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= iNumberLines; i++)
        {
            GameObject instance = Instantiate(goLineTraceByParticle);
            instance.transform.parent = gameObject.transform;
            instance.GetComponent<ParticlePos>().SetValues(fcContainer, fsaFlexSourceActor, GGradientColor, fTimeBetweenPos, iParticleToSkip * i + iParticleMeshNumber);
        }
    }
}
