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
            if (fcContainer.m_particleArray[fcContainer.m_particleArray.Length - iBeforeLastParticle] != Vector4.zero && lrLineRenderer.positionCount < 50)
            {
                lrLineRenderer.positionCount = lrLineRenderer.positionCount + 1;
                lrLineRenderer.SetPosition(i, fcContainer.m_particleArray[fcContainer.m_particleArray.Length - iBeforeLastParticle]);
                i++;
            }
            fChrono = fTimer;
        }
    }

    public void SetValues(FlexContainer container, float timer, int beforelastparticle)
    {
        fcContainer = container;
        fTimer = timer;
        iBeforeLastParticle = beforelastparticle;
    }
}
