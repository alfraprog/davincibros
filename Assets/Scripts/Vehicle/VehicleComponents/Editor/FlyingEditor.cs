using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace TankComponents
{
    namespace Editor
    {
        [CustomEditor(typeof(FlyingAttachment))]
        public class FlyingEditor : UnityEditor.Editor
        {
            public override void OnInspectorGUI()
            {
                DrawDefaultInspector();

                FlyingAttachment flying = (FlyingAttachment)target;

                if (flying.manuscript)
                {
                    if (GUILayout.Button("Init Manuscript"))
                    {
                        flying.InitFromManuscript(flying.manuscript);
                    }
                }
                if (flying.transform.childCount > 0)
                {
                    if (GUILayout.Button("Remove spawned sprites"))
                    {
                        foreach (Transform child in flying.transform)
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
