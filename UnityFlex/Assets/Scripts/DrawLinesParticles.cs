using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NVIDIA.Flex;

public class DrawLinesParticles : MonoBehaviour
{
    public FlexContainer fcContainer;
    public GameObject goLineTraceByParticle;
    public int iNumberLines;
    public float fTimeBetweenPos;
    public int iParticleToSkip;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < iNumberLines; i++)
        {
            GameObject instance = Instantiate(goLineTraceByParticle);
            instance.GetComponent<ParticlePos>().SetValues(fcContainer, fTimeBetweenPos, iParticleToSkip*i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        print("NBParticule: " + fcContainer.m_particleArray.Length);
        print("NBFluidParticule: " + fcContainer.m_fluidIndices.Length);
    }
}
