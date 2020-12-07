using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NVIDIA.Flex;

public class ParticlePos : MonoBehaviour
{
    public GameObject goLineRenderer;

    private FlexContainer fcContainer;
    private Gradient GGradientColor;
    private float fTimer;
    private int iBeforeLastParticle;
    private float fChrono = 0;
    private FlexSourceActor fsaFlexSourceActor;
    private int i = 0;

    private float fmaxSpeed = -Mathf.Infinity;
    private float fminSpeed = Mathf.Infinity;
    private List<float> Speeds;
    public List<LineRenderer> listlrLineRenderer;
    private float fLengthOfLine;

    bool bDoOnce = false;

    private void Start()
    {
        Speeds = new List<float>();
        listlrLineRenderer = new List<LineRenderer>();

        GameObject instance = Instantiate(goLineRenderer);
        instance.transform.parent = gameObject.transform;
        listlrLineRenderer.Add(instance.GetComponent<LineRenderer>());
    }


    void Update()
    {
        fChrono -= Time.deltaTime;

        if (fChrono <= 0)
        {
            bool CanStop = false;
            //print("Age = " + fsaFlexSourceActor.ages[iBeforeLastParticle]);
            //if (fsaFlexSourceActor.ages[iBeforeLastParticle] <= 5.0f)
            if (fsaFlexSourceActor.ages[iBeforeLastParticle] + 1 < fsaFlexSourceActor.lifeTime / 2)
            {
                CanStop = true;
            }
            if (!CanStop && fcContainer.m_particleArray[fsaFlexSourceActor.m_indices[iBeforeLastParticle]] != Vector4.zero && listlrLineRenderer.Count < fsaFlexSourceActor.lifeTime * 5)
            {
                 CreateLine();
                
                gameObject.GetComponentInParent<DrawLinesParticles>().StartOfLines();
                if (listlrLineRenderer.Count == 2)
                    listlrLineRenderer[0].SetPosition(0, fcContainer.m_particleArray[fsaFlexSourceActor.m_indices[iBeforeLastParticle]]);

                if (listlrLineRenderer.Count == fsaFlexSourceActor.lifeTime * 5)
                    listlrLineRenderer[listlrLineRenderer.Count - 1].SetPosition(1, fcContainer.m_particleArray[fsaFlexSourceActor.m_indices[iBeforeLastParticle]]);
                //lrLineRenderer.positionCount = lrLineRenderer.positionCount + 1;
                //lrLineRenderer.SetPosition(i, fcContainer.m_particleArray[fcContainer.m_particleArray.Length - iBeforeLastParticle]);
                //i++;
                //}
                //else if (listlrLineRenderer.Count >= fsaFlexSourceActor.lifeTime * 8 && !bDoOnce)
                //{

                if (listlrLineRenderer.Count <= fsaFlexSourceActor.lifeTime * 8)
                {
                    Speeds.Clear();
                    for (int i = 0; i < listlrLineRenderer.Count - 1; i++)
                    {
                        if (GetSpeed(listlrLineRenderer[i].GetPosition(0), listlrLineRenderer[i].GetPosition(1)) > fmaxSpeed)
                            fmaxSpeed = GetSpeed(listlrLineRenderer[i].GetPosition(0), listlrLineRenderer[i].GetPosition(1));
                        if (GetSpeed(listlrLineRenderer[i].GetPosition(0), listlrLineRenderer[i].GetPosition(1)) < fminSpeed)
                            fminSpeed = GetSpeed(listlrLineRenderer[i].GetPosition(0), listlrLineRenderer[i].GetPosition(1));
                    }
                    for (int i = 0; i < listlrLineRenderer.Count - 1; i++)
                    {
                        Speeds.Add(GetSpeed(listlrLineRenderer[i].GetPosition(0), listlrLineRenderer[i].GetPosition(1)));
                        fLengthOfLine += Vector4.Distance(listlrLineRenderer[i].GetPosition(0), listlrLineRenderer[i].GetPosition(1));
                    }
                    float fLengthOfPoint = 0;
                    for (int i = 0; i < listlrLineRenderer.Count - 1; i++)
                    {
                        fLengthOfPoint += Vector4.Distance(listlrLineRenderer[i].GetPosition(0), listlrLineRenderer[i].GetPosition(1));
                        if (i >= 1)
                            listlrLineRenderer[i].startColor = listlrLineRenderer[i - 1].endColor;//GGradientColor.Evaluate((Speeds[i] - fminSpeed) / (fmaxSpeed - fminSpeed));

                        listlrLineRenderer[i].endColor = GGradientColor.Evaluate((Speeds[i] - fminSpeed) / (fmaxSpeed - fminSpeed));

                        //listgoLineRenderer[i].GetComponent<LineRenderer>().endColor = new Color(Speeds[i] / fmaxSpeed, Speeds[i] / fmaxSpeed, 0, 1);
                    }
                    bDoOnce = true;
                }
            }
            fChrono = fTimer;
            
        }
        /*fChrono -= Time.deltaTime;

       if (fChrono <= 0)
       {
           if (fcContainer.m_particleArray[fcContainer.m_particleArray.Length - iBeforeLastParticle] != Vector4.zero && lrLineRenderer.positionCount < fsaFlexSourceActor.lifeTime*8)
           {
               lrLineRenderer.positionCount = lrLineRenderer.positionCount + 1;
               lrLineRenderer.SetPosition(i, fcContainer.m_particleArray[fcContainer.m_particleArray.Length - iBeforeLastParticle]);
               i++;
           }
           else if(lrLineRenderer.positionCount >= fsaFlexSourceActor.lifeTime * 8 && !bDoOnce)
           {
               for (int i = 0; i < lrLineRenderer.positionCount - 1; i++)
               {
                   if (GetSpeed(lrLineRenderer.GetPosition(i), lrLineRenderer.GetPosition(i + 1)) > fmaxSpeed)
                       fmaxSpeed = GetSpeed(lrLineRenderer.GetPosition(i), lrLineRenderer.GetPosition(i + 1));
                   if (GetSpeed(lrLineRenderer.GetPosition(i), lrLineRenderer.GetPosition(i + 1)) < fminSpeed)
                       fminSpeed = GetSpeed(lrLineRenderer.GetPosition(i), lrLineRenderer.GetPosition(i + 1));
               }
               for (int i = 0; i < lrLineRenderer.positionCount - 1; i++)
               {
                   Speeds.Add(GetSpeed(lrLineRenderer.GetPosition(i), lrLineRenderer.GetPosition(i + 1)) / fmaxSpeed);
                   fLengthOfLine += Vector4.Distance(lrLineRenderer.GetPosition(i), lrLineRenderer.GetPosition(i + 1));
               }
               float fLengthOfPoint = 0;
               GradientColorKey[] colorKey;
               GradientAlphaKey[] alphaKey;
               colorKey = new GradientColorKey[lrLineRenderer.positionCount - 1];
               alphaKey = new GradientAlphaKey[lrLineRenderer.positionCount - 1];
               for (int i = 0; i < lrLineRenderer.positionCount - 1; i++)
               {
                   fLengthOfPoint += Vector4.Distance(lrLineRenderer.GetPosition(i), lrLineRenderer.GetPosition(i + 1));
                   colorKey[i].time = fLengthOfPoint / fLengthOfLine;
                   colorKey[i].color = new Color(Speeds[i], 0, 0, 1);

                   alphaKey[i].alpha = 1.0f;
               }
               lrLineRenderer.colorGradient.SetKeys(colorKey, alphaKey);
               bDoOnce = true;
           }
           fChrono = fTimer;
       }*/
    }

    public void SetValues(FlexContainer container, FlexSourceActor flexsourceactor, Gradient gradient, float timer, int beforelastparticle)
    {
        fcContainer = container;
        fsaFlexSourceActor = flexsourceactor;
        GGradientColor = gradient;
        fTimer = timer;
        iBeforeLastParticle = beforelastparticle;
    }

    float GetSpeed(Vector4 pos1, Vector4 pos2)
    {
        float speed = Vector4.Distance(pos1, pos2) / fTimer;
        return speed;
    }

    

    void CreateLine()
    {        
            listlrLineRenderer[i].SetPosition(1, fcContainer.m_particleArray[fsaFlexSourceActor.m_indices[iBeforeLastParticle]]);

            GameObject instance = Instantiate(goLineRenderer);
            instance.transform.parent = gameObject.transform;
            listlrLineRenderer.Add(instance.GetComponent<LineRenderer>());
            listlrLineRenderer[i + 1].SetPosition(0, fcContainer.m_particleArray[fsaFlexSourceActor.m_indices[iBeforeLastParticle]]);
            listlrLineRenderer[i + 1].SetPosition(1, fcContainer.m_particleArray[fsaFlexSourceActor.m_indices[iBeforeLastParticle]]);
            i++; 
    }
}