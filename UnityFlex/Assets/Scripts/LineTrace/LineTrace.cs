using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NVIDIA;
using NVIDIA.Flex;

public class LineTrace : MonoBehaviour
{
    public FlexContainer FCReference;
    FlexFluidRenderer fluidReference;
    public TrailRenderer TrailReference;
    [SerializeField]
    public FlexContainer.ParticleData ParticlesDatas;
    private TrailRenderer trail;
    private Vector4 particle;


   

    private void Update()
    {
        ParticlesDatas =  FCReference.m_particleData;
        //ParticulesDatas.GetParticle(1);
        if(ParticlesDatas.GetParticle(1) == null)
        {
            particle = ParticlesDatas.GetParticle(1);
            trail = Instantiate(TrailReference);            
        }
        else
        {
            trail.transform.position = particle;
        }
    }

}
