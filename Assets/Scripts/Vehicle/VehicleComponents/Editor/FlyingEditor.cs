using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace TankComponents
{
    namespace Editor
    {
        [CustomEditor(typeof(Flying))]
        public class FlyingEditor : UnityEditor.Editor
        {
            public override void OnInspectorGUI()
            {
                Flying flying = (Flying)target;

                flying.flyMode = (Flying.FlyMode)EditorGUILayout.EnumPopup("Type", flying.flyMode);
                flying.force = EditorGUILayout.Vector2Field("Force Vector", flying.force);

                EditorGUILayout.Space();

                flying.maxStamina = EditorGUILayout.FloatField("Max Stamina", flying.maxStamina);
                flying.staminaUsage = EditorGUILayout.FloatField("Staminage usage", flying.staminaUsage);
                flying.staminaRecoveryRate = EditorGUILayout.FloatField("Stamina recovery/s", flying.staminaRecoveryRate);
                EditorGUILayout.LabelField("Current stamina: " + flying.currentStamina);

                EditorGUILayout.Space();

                if (flying.flyMode == Flying.FlyMode.Impulse || flying.flyMode == Flying.FlyMode.Continous)
                {
                    flying.cooldown = EditorGUILayout.FloatField("Cooldown", flying.cooldown);
                    EditorGUILayout.LabelField("Time until ready: " + flying.timeUntilReady);
                }

                if (flying.flyMode == Flying.FlyMode.RampUp)
                {
                    flying.rampUpTime = EditorGUILayout.FloatField("Ramp up time", flying.rampUpTime);
                    EditorGUILayout.LabelField("Ramp up Force Multiplier: " + flying.rampupParameter);
                }
                EditorUtility.SetDirty(target);

            }
        }


    }
}
