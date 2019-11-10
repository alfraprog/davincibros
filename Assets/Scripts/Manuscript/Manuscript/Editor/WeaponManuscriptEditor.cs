using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TankComponents;

[CustomEditor(typeof(WeaponManuscript))]
public class WeaponManuscriptEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        WeaponManuscript manuscript = (WeaponManuscript)target;

        manuscript.title = EditorGUILayout.TextField("Title", manuscript.title);
        manuscript.description = EditorGUILayout.TextField("Description", manuscript.description);
        manuscript.imagePath = EditorGUILayout.TextField("Image Path", manuscript.imagePath);
        manuscript.backgroundPath = EditorGUILayout.TextField("Background Path", manuscript.backgroundPath);

        EditorGUILayout.Space();

        manuscript.type = (WeaponManuscript.Type)EditorGUILayout.EnumPopup("Type", manuscript.type);
        manuscript.projectile = (GameObject)EditorGUILayout.ObjectField("Projectile", manuscript.projectile, typeof(GameObject), false);

        EditorGUILayout.Space();

        manuscript.muzzleVelocity = EditorGUILayout.Vector2Field("Muzzle Velocity", manuscript.muzzleVelocity);
        manuscript.recoil = EditorGUILayout.FloatField("Recoil Force", manuscript.recoil);
        manuscript.cooldown = EditorGUILayout.FloatField("Reload Time", manuscript.cooldown);


        EditorGUILayout.Space();

        if (manuscript.type == WeaponManuscript.Type.Kinetic)
        {
            manuscript.impactForce = EditorGUILayout.FloatField("Impact Force", manuscript.impactForce);
            manuscript.powerful = EditorGUILayout.Toggle("Powerful", manuscript.powerful);
        } else
        {
            manuscript.fuseTime = EditorGUILayout.FloatField("Fuse Time", manuscript.fuseTime);
            manuscript.explosionForce = EditorGUILayout.FloatField("Explosive Force", manuscript.explosionForce);
            manuscript.explosionRadius = EditorGUILayout.FloatField("Radius", manuscript.explosionRadius);
        }
        EditorUtility.SetDirty(target);

    }
}
