using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NVIDIA.Flex;

public class DrawParticlesSoft : MonoBehaviour
{
    public FlexContainer fcContainer;
    public FlexSoftActor fsaFlexSoftActor;
    public GameObject goLineRenderer;
    public Gradient GGradientColor;
    public float fTimeBetweenPos;

    private List<LineRenderer> listLineRenderer;
    private List<float> listDistance;
    private int iParticleMeshNumber;
    private bool bEndLine = false;
    private float timer;
    private float maxDistance;


    private void Start()
    {
        iParticleMeshNumber = fsaFlexSoftActor.indices.Length - 1;
        print("Nombre de particule " + iParticleMeshNumber);

        listLineRenderer = new List<LineRenderer>();
        listDistance = new List<float>();
        for (int i = 0; i < iParticleMeshNumber; i++)
        {
            GameObject instance = Instantiate(goLineRenderer);
            instance.transform.parent = gameObject.transform;
            listLineRenderer.Add(instance.GetComponent<LineRenderer>());
            listLineRenderer[i].GetComponent<LineRenderer>();
            listLineRenderer[i].positionCount = 2;
            listLineRenderer[i].SetPosition(0, fcContainer.m_particleArray[fsaFlexSoftActor.indices[i]]);
            listLineRenderer[i].SetPosition(1, fcContainer.m_particleArray[fsaFlexSoftActor.indices[i]]);
            listDistance.Add(0);
        }

    }

    public void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = fTimeBetweenPos;

            for (int i = 0; i < iParticleMeshNumber; i++)
            {
                //if (Vector3.Distance(listLineRenderer[i].GetPosition(0), listLineRenderer[i].GetPosition(1)) < Vector3.Distance(listLineRenderer[i].GetPosition(0), fcContainer.m_particleArray[fsaFlexSoftActor.indices[i]]))
                {
                    listLineRenderer[i].SetPosition(1, fcContainer.m_particleArray[fsaFlexSoftActor.indices[i]]);
                    listDistance[i] = Vector3.Distance(listLineRenderer[i].GetPosition(0), listLineRenderer[i].GetPosition(1));
                }
            }
            maxDistance = 0;
            for (int i = 0; i < iParticleMeshNumber; i++)
            {
                if (maxDistance < listDistance[i])
                {
                    maxDistance = listDistance[i];
                }
            }

            for (int i = 0; i < iParticleMeshNumber; i++)
            {

                Color color = GGradientColor.Evaluate((listDistance[i] - 0) / (maxDistance - 0));

                listLineRenderer[i].startColor = color;
                listLineRenderer[i].endColor = color;
            }

        }

       
    }



}

