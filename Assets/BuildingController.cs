using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingController : MonoBehaviour
{
    public int buildingPhase = 1;

    public AbstractManuscript[] manuscriptToBuild = new AbstractManuscript[2] { null, null };
    public AbstractManuscript[] manuscriptToBuild2 = new AbstractManuscript[2] { null, null };
    public int P1Assigned = 0;
    public int P2Assigned = 0;

    public string axisLayerSelection;
    public string axisDirectionSelection;
    public string p1_assign_button;
    public string p2_assign_button;


    public DockSelector dockselector_P1;
    public DockSelector dockselector_P2;

    private bool selectionMadeP1 = false;
    private bool selectionMadeP2 = false;

    public int duration;
    private long started;
    public Text timerText;


    // Start is called before the first frame update
    void Start()
    {
        P1Assigned = 0;
        P2Assigned = 0;
        manuscriptToBuild[0] = GameManager.Instance.selectedManuscripts[0].manuscripts[0];
        manuscriptToBuild[1] = GameManager.Instance.selectedManuscripts[1].manuscripts[0];
        manuscriptToBuild2[0] = GameManager.Instance.selectedManuscripts[0].manuscripts[1];
        manuscriptToBuild2[1] = GameManager.Instance.selectedManuscripts[1].manuscripts[1];
        buildingPhase = GameManager.Instance.fightStage;

        startBuildingPhase(buildingPhase, manuscriptToBuild[0], manuscriptToBuild[1]);

        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        float threshold = 0.05f;

        float p1_layer = Input.GetAxis(axisLayerSelection + "_P1");
        float p1_dir = Input.GetAxis(axisDirectionSelection + "_P1");
        float p2_layer = Input.GetAxis(axisLayerSelection + "_P2");
        float p2_dir = Input.GetAxis(axisDirectionSelection + "_P2");

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown(p1_assign_button))
            FinishBuildP1();
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown(p2_assign_button))
            FinishBuildP2();
        
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


        if ((started > -1) &&  (timerText != null))
        {
            long diff = duration - (System.DateTime.Now.Ticks - started) / 10000000;
            timerText.text = diff.ToString();
            if (diff < 0)
            {
                EndPhase();
            }
        }
    }

    public void StartTimer() {
        started = System.DateTime.Now.Ticks;
    }

    public void EndPhase() {
        started = -1;
        GameManager.Instance.EndBuildPhase();
    }

    public void startBuildingPhase(int phase, AbstractManuscript player1Selection, AbstractManuscript player2Selection) {
        manuscriptToBuild[0] = player1Selection;
        manuscriptToBuild[1] = player2Selection;
        buildingPhase = phase;
        dockselector_P1.startSelection(phase, player1Selection);
        if (dockselector_P2 != null) dockselector_P2.startSelection(phase, player2Selection);
    }

    public void FinishBuildP1()
    {
        if (P1Assigned == 2)
        {
            if (P2Assigned == 2)
                EndPhase();
            return;
        }
            
        P1Assigned = P1Assigned + 1;
        dockselector_P1.placeManuscript(GameManager.Instance.tankConfigP1);
        if (P1Assigned < 2)
            dockselector_P1.startSelection(buildingPhase, manuscriptToBuild2[0]);
    }

    public void FinishBuildP2()
    {
        if (P2Assigned == 2)
        {
            if (P1Assigned == 2)
                EndPhase();
            return;
        }
        P2Assigned = P2Assigned + 1;
        dockselector_P2.placeManuscript(GameManager.Instance.tankConfigP2);
        if (P2Assigned < 2)
            dockselector_P2.startSelection(buildingPhase, manuscriptToBuild2[1]);
    }
}
