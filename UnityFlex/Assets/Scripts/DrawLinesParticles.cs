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

    private List<ParticlePos> listgoLines;
    private bool bEndLine = false;
    private float timer;



    private int iLines;
    private bool DoOnce;
    // Start is called before the first frame update
    void Start()
    {
        DoOnce = false;
        listgoLines = new List<ParticlePos>();

        for (int i = 1; i <= iNumberLines; i++)
        {
            GameObject instance = Instantiate(goLineTraceByParticle);
            listgoLines.Add(instance.GetComponent<ParticlePos>());
            instance.transform.parent = gameObject.transform;
            instance.GetComponent<ParticlePos>().SetValues(fcContainer, fsaFlexSourceActor, GGradientColor, fTimeBetweenPos, iParticleToSkip * i + iParticleMeshNumber);
        }
        timer = fsaFlexSourceActor.lifeTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (bEndLine && timer <= 0)
        {
            if (!DoOnce)
            {
                iLines = listgoLines[listgoLines.Count - 1].listlrLineRenderer.Count - 1;
                DoOnce = true;
            }
            if (Input.GetKey(KeyCode.KeypadPlus) && iLines < listgoLines[listgoLines.Count - 1].listlrLineRenderer.Count - 1)
            {
                //Time.timeScale = 0;
                //print("+");
                foreach (var item in listgoLines)
                {
                    item.listlrLineRenderer[iLines].gameObject.SetActive(true);
                }
                iLines++;
            }

            if (Input.GetKey(KeyCode.KeypadMinus) && iLines > 0)
            {
                //Time.timeScale = 0;
                //print("-");
                foreach (var item in listgoLines)
                {
                    item.listlrLineRenderer[iLines].gameObject.SetActive(false);
                }
                iLines--;
            }

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Time.timeScale = 1;
            }
        }
    }

    public void EndOfLines()
    {
        bEndLine = true;
    }
    public void StartOfLines()
    {
        bEndLine = true;
    }

    public void Calcule() {

        listgoLines.ForEach((Line) => { Destroy(Line); });
        Start();
    }

}

