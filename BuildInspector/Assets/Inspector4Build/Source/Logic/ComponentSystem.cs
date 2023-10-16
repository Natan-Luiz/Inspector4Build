using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inspector4Build
{
    public enum ComponentType
    {
        Collider,
        System,
        Camera,
        Rigidbody,
        Light,
        UI,
        Script
    }

    public class ComponentSystem
    {
        string name;

        public ComponentType type;


        /// <summary>
        /// Process components to some specific types, removing the ones directly linked in the object
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static ComponentSystem GetComponent(Component original)
        {
            ComponentSystem component = new ComponentSystem();

            component.name = original.name;
            
            if(original.GetType() == typeof(Rigidbody))
                component.type = ComponentType.Rigidbody;
            else if (original.GetType() == typeof(Camera))
                component.type = ComponentType.Camera;
            else if (original.name.Contains("Collider"))
                component.type = ComponentType.Collider;
            else if (original.name.Contains("Light"))
                component.type = ComponentType.Light;


            return component;
        }
    }
}