using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TankComponents;

[CustomEditor(typeof(FlyingManuscript))]
public class FlyingEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        FlyingManuscript manuscript = (FlyingManuscript)target;

        manuscript.title = EditorGUILayout.TextField("Title", manuscript.title);
        manuscript.description = EditorGUILayout.TextField("Description", manuscript.description);
        manuscript.imagePath = EditorGUILayout.TextField("Image Path", manuscript.imagePath);
        manuscript.backgroundPath = EditorGUILayout.TextField("Background Path", manuscript.backgroundPath);

        EditorGUILayout.Space();

        manuscript.flyMode = (Flying.FlyMode)EditorGUILayout.EnumPopup("Type", manuscript.flyMode);
        manuscript.force = EditorGUILayout.Vector2Field("Force Vector", manuscript.force);

        EditorGUILayout.Space();

        manuscript.maxStamina = EditorGUILayout.FloatField("Max Stamina", manuscript.maxStamina);
        manuscript.staminaUsage = EditorGUILayout.FloatField("Staminage usage", manuscript.staminaUsage);
        manuscript.staminaRecoveryRate = EditorGUILayout.FloatField("Stamina recovery/s", manuscript.staminaRecoveryRate);


        EditorGUILayout.Space();

        if (manuscript.flyMode == Flying.FlyMode.Impulse || manuscript.flyMode == Flying.FlyMode.Continous)
        {
            manuscript.cooldown = EditorGUILayout.FloatField("Cooldown", manuscript.cooldown);
        }

        if (manuscript.flyMode == Flying.FlyMode.RampUp)
        {
            manuscript.rampUpTime = EditorGUILayout.FloatField("Ramp up time", manuscript.rampUpTime);
        }
        EditorUtility.SetDirty(target);

    }
}
