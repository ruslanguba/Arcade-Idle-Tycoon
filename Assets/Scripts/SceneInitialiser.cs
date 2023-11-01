using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitialiser : MonoBehaviour
{
    public class ResourcesController
    {
        private static ResourcesController instance;

        public static ResourcesController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ResourcesController();
                }
                return instance;
            }
        }
    }
}
