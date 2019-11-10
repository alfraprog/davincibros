using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DockSelector : MonoBehaviour
{
    public AbstractManuscript manuscriptToPlace;

    //TODO replace by manuscript illustration!
    public Text ManuscriptName;

    public GameObject dockIndicatorPrefab;  // available spots
    public GameObject dockIndicatorSelectablePrefab; // selectable slots
    public GameObject dockIndicatorSelectedPrefab; // currently selected slot

    public Transform armor_L0;
    public Transform weapon_L0_Right;
    public Transform weapon_L0_Left;

    public Transform armor_L1;
    public Transform weapon_L1_Right;
    public Transform weapon_L1_Left;

    public Transform armor_L2;
    public Transform weapon_L2_Right;
    public Transform weapon_L2_Left;

    public Transform flying;

    public Transform wheel_Left;
    public Transform wheel_Right;

    public List<Transform> availableSlots;
    public List<Transform> selectableSlots;
    public Transform selectedSlotIndicator;

    public List<GameObject> indicators;

    public int selectedSlot = 0;  // 0 = left else right
    public int selectedLayer = 0;
    public int selectionPhase = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void startSelection(int phase, AbstractManuscript selectedManuscript) {
        manuscriptToPlace = selectedManuscript;
        selectionPhase = phase;
        refreshSlots(true);
        setupManuscript(selectedManuscript);
    }

    public void setupManuscript(AbstractManuscript manuscript)
    {
        ManuscriptName.text = "To be Placed: \n" + manuscript.title;
    }

    public void layerUp()
    {
        if (selectedLayer <= selectionPhase - 1)
            selectedLayer = (selectedLayer + 1);
        refreshSlots(false);
    }

    public void layerDown()
    {
        if (selectedLayer >= 1)
            selectedLayer = (selectedLayer - 1);
        refreshSlots(false);
    }

    public void selectLeft()
    {
        selectedSlot = 0;
        refreshSlots(false);
    }

    public void selectRight()
    {
        selectedSlot = 1;
        refreshSlots(false);
    }

    public GameObject createMarker(Transform t, string type, int layer, int dir, ref bool first) {
        GameObject go = null;
        bool appropriateType = false;

        if (type.Equals("w") && (manuscriptToPlace is WeaponManuscript))
        {
            appropriateType = true;
        }
        else if (type.Equals("f") && (manuscriptToPlace is FlyingManuscript))
        {
            appropriateType = true;
        }
        else if (type.Equals("p") && (manuscriptToPlace is PropulsionManuscript))
        {
            appropriateType = true;
        }
        else if (type.Equals("a") && (manuscriptToPlace is ArmorManuscript))
        {
            appropriateType = true;
        }

        if (appropriateType) {
            if (first)
            {
                go = GameObject.Instantiate(dockIndicatorSelectedPrefab);
                selectedLayer = layer;
                selectedSlot = dir;
                first = false;
            }
            else
            {
                if (type.Equals("f")) {
                    go = GameObject.Instantiate(dockIndicatorSelectedPrefab);
                } else if (((selectedLayer < 0) || (selectedLayer == layer)) && ((dir < 0) || (selectedSlot == dir)))
                    go = GameObject.Instantiate(dockIndicatorSelectedPrefab);
                else
                    go = GameObject.Instantiate(dockIndicatorSelectablePrefab);
            }
        } else {
            go = GameObject.Instantiate(dockIndicatorPrefab);
        }

        go.transform.SetParent(t);
        go.transform.position = t.position;
        go.transform.localScale = go.transform.localScale*0.5f;
  
        return go;

    }

    public void refreshSlots(bool first) {
        foreach (GameObject i in indicators) {
            i.SetActive(false);
            Destroy(i);
        }
        indicators.Clear();
        indicators.Add(createMarker(armor_L0, "a", 0, -1, ref first));
        indicators.Add(createMarker(weapon_L0_Left, "w", 0, 0, ref first));
        indicators.Add(createMarker(weapon_L0_Right, "w", 0, 1, ref first));
        if (selectionPhase >= 1)
        {
            indicators.Add(createMarker(armor_L1, "a", 1, -1, ref first));
            indicators.Add(createMarker(weapon_L1_Left, "w", 1, 0, ref first));
            indicators.Add(createMarker(weapon_L1_Right, "w", 1, 1, ref first));
        }
        if (selectionPhase >= 2)
        {
            indicators.Add(createMarker(armor_L2, "a", 2, -1, ref first));
            indicators.Add(createMarker(weapon_L2_Left, "w", 2, 0, ref first));
            indicators.Add(createMarker(weapon_L2_Right, "w", 2, 1, ref first));
        }
        indicators.Add(createMarker(flying, "f", 3, -1, ref first));
        indicators.Add(createMarker(wheel_Left, "p", -1, 0, ref first));
        indicators.Add(createMarker(wheel_Right, "p", -1, 1, ref first));
    }

    public void placeManuscript(GameManager.TankConfig tconf) {
        if (manuscriptToPlace is WeaponManuscript)
        {
            if (selectedLayer == 0)
            {
                if (selectedSlot == 0) tconf.weapon_L0_left = manuscriptToPlace; else tconf.weapon_L0_right = manuscriptToPlace;
            }
            else if(selectedLayer == 1)
            {
                if (selectedSlot == 0) tconf.weapon_L1_left = manuscriptToPlace; else tconf.weapon_L1_right = manuscriptToPlace;
            } else if (selectedLayer == 2)
            {
                if (selectedSlot == 0) tconf.weapon_L2_left = manuscriptToPlace; else tconf.weapon_L2_right = manuscriptToPlace;
            }
        }
        else if (manuscriptToPlace is FlyingManuscript)
        {
            tconf.flight = manuscriptToPlace;
        }
        else if (manuscriptToPlace is PropulsionManuscript)
        {
                if (selectedSlot == 0) tconf.wheel_left = manuscriptToPlace; else tconf.wheel_right = manuscriptToPlace;
        }
        else if (manuscriptToPlace is ArmorManuscript)
        {
            if (selectedLayer == 0)
            {
                tconf.armor_L0 = manuscriptToPlace;
            }
            else if (selectedLayer == 1)
            {
                tconf.armor_L1 = manuscriptToPlace;
            }
            else if (selectedLayer == 2)
            {
                tconf.armor_L2 = manuscriptToPlace;
            }
        }
    }
}
