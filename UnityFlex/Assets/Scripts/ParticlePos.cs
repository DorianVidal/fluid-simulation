using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NVIDIA.Flex;

public class ParticlePos : MonoBehaviour
{
    public FlexContainer fcContainer;
    public LineRenderer lrLineRenderer;
    public float fTimer;
    public int iBeforeLastParticle;
    private float fChrono = 0;
    public FlexSourceActor fsaFlexSourceActor;
    int i;

    private void Start()
    {
        lrLineRenderer = GetComponent<LineRenderer>();
        lrLineRenderer.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        fChrono -= Time.deltaTime;
        if (fChrono <= 0)
        {
            if (fcContainer.m_particleArray[fcContainer.m_particleArray.Length - iBeforeLastParticle] != Vector4.zero && lrLineRenderer.positionCount < fsaFlexSourceActor.lifeTime*8)
            {
                lrLineRenderer.positionCount = lrLineRenderer.positionCount + 1;
                lrLineRenderer.SetPosition(i, fcContainer.m_particleArray[fcContainer.m_particleArray.Length - iBeforeLastParticle]);
                i++;
            }
            fChrono = fTimer;
        }
    }

    public void SetValues(FlexContainer container, FlexSourceActor flexsourceactor , float timer, int beforelastparticle)
    {
        fcContainer = container;
        fsaFlexSourceActor = flexsourceactor;
        fTimer = timer;
        iBeforeLastParticle = beforelastparticle;
    }
}
