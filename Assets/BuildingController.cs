using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public int buildingPhase = 1;

    public AbstractManuscript[] manuscriptToBuild = new AbstractManuscript[2] {null, null};

    public string axisLayerSelection;
    public string axisDirectionSelection;

    public DockSelector dockselector_P1;
    public DockSelector dockselector_P2;

    private bool selectionMadeP1 = false;
    private bool selectionMadeP2 = false;


    // Start is called before the first frame update
    void Start()
    {
        //TODO only for debugging! remove later and do via GameManager
        startBuildingPhase(2, manuscriptToBuild[0], manuscriptToBuild[1]);
    }

    // Update is called once per frame
    void Update()
    {
        float threshold = 0.05f;

        float p1_layer = Input.GetAxis(axisLayerSelection + "_P1");
        float p1_dir = Input.GetAxis(axisDirectionSelection + "_P1");
        float p2_layer = Input.GetAxis(axisLayerSelection + "_P2");
        float p2_dir = Input.GetAxis(axisDirectionSelection + "_P2");

        if (!selectionMadeP1 &&
            ((Math.Abs(p1_layer) > threshold)
            || (Math.Abs(p1_dir) > threshold))) {
            if (Math.Abs(p1_layer) > threshold)
            {
                if (p1_layer > 0.0) dockselector_P1.layerUp(); else dockselector_P1.layerDown();
            }
            if (Math.Abs(p1_dir) > threshold)
            {
                if (p1_dir < 0.0) dockselector_P1.selectLeft(); else dockselector_P1.selectRight();
            }
            selectionMadeP1 = true;
        } else if ((Math.Abs(p1_layer) <= threshold)
                    && (Math.Abs(p1_dir) <= threshold)){
            selectionMadeP1 = false;
        }


        if (!selectionMadeP2 &&
        ((Math.Abs(p2_layer) > threshold)
        || (Math.Abs(p2_dir) > threshold)))
        {
            if (Math.Abs(p2_layer) > threshold)
            {
                if (p2_layer > 0.0) dockselector_P2.layerUp(); else dockselector_P2.layerDown();
            }
            if (Math.Abs(p2_dir) > threshold)
            {
                if (p2_dir < 0.0) dockselector_P2.selectLeft(); else dockselector_P2.selectRight();
            }
            selectionMadeP2 = true;
        }
        else if ((Math.Abs(p2_layer) <= threshold)
                  && (Math.Abs(p2_dir) <= threshold))
        {
            selectionMadeP2 = false;
        }
    }

    public void startBuildingPhase(int phase, AbstractManuscript player1Selection, AbstractManuscript player2Selection) {
        manuscriptToBuild[0] = player1Selection;
        manuscriptToBuild[1] = player2Selection;
        buildingPhase = phase;
        dockselector_P1.startSelection(phase, player1Selection);
        if (dockselector_P2 != null) dockselector_P2.startSelection(phase, player2Selection);
    }
}
