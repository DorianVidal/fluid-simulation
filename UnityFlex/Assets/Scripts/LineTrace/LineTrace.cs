using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NVIDIA.Flex;

public class LineTrace : MonoBehaviour
{
    List<Vector3> ParticulePosArray;
    public FlexContainer container;
    public FlexContainer.ParticleData particleData;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetParticlesPos(particleData);
    }
    void GetParticlesPos(FlexContainer.ParticleData particle)
    {
        print(particle.GetParticle(container.fluidIndices[1]));
        //for(int i = 0; i < flexContainer.count)
        //print(flexContainer.fluidIndices);
        
        //flexContainer.FreeParticles(flexContainer.fluidIndices);
    }
}
