using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NVIDIA.Flex;

public class DrawLinesParticles : MonoBehaviour
{
    public FlexContainer fcContainer;
    public FlexSourceActor fsaFlexSourceActor;
    public GameObject goLineTraceByParticle;
    public int iNumberLines;
    private float fTimeBetweenPos = 0.1f;
    public int iParticleToSkip;
    public int iParticuleMeshNumber; //Fais référence au nombre de particules dans le mesh
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 1; i <= iNumberLines; i++)
        {
            GameObject instance = Instantiate(goLineTraceByParticle);
            instance.transform.parent = gameObject.transform;
            instance.GetComponent<ParticlePos>().SetValues(fcContainer, fsaFlexSourceActor, fTimeBetweenPos, iParticleToSkip*i + iParticuleMeshNumber);           
        }
    }

    // Update is called once per frame
    void Update()
    {
        //print("NBParticule: " + fcContainer.m_particleArray.Length);
        //print("NBFluidParticule: " + fcContainer.m_fluidIndices.Length);
    }
}
