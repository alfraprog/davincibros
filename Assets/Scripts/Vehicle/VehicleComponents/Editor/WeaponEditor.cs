using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace TankComponents
{
    namespace Editor
    {
        [CustomEditor(typeof(WeaponAttachment))]
        public class WeaponEditor : UnityEditor.Editor
        {
            public override void OnInspectorGUI()
            {


                DrawDefaultInspector();

                WeaponAttachment weapon = (WeaponAttachment)target;

                if (weapon.manuscript)
                {
                    if (GUILayout.Button("Init Manuscript"))
                    {
                        weapon.InitFromManuscript(weapon.manuscript);
                    }
                }
                if (weapon.transform.childCount > 0)
                {
                    if (GUILayout.Button("Remove spawned sprites"))
                    {
                        foreach (Transform child in weapon.transform)
                        {
                            if (Application.isEditor)
                            {
                                GameObject.DestroyImmediate(child.gameObject);
                            }
                            else
                            {
                                GameObject.Destroy(child.gameObject);
                            }

                        }
                    }
                }


            }
        }


    }
}
