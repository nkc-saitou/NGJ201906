using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Saitou.System
{
    public class FindInterface : MonoBehaviour
    {
        /// <summary>
        /// 単数
        /// </summary>
        /// <typeparam name="T">型</typeparam>
        /// <returns></returns>
        public static T FindObjectOfInterfaces<T>() where T : class
        {
            foreach (var n in FindObjectsOfType<Component>())
            {
                var component = n as T;

                if (component != null)
                {
                    return component;
                }
            }

            return null;
        }

        /// <summary>
        /// 複数
        /// </summary>
        /// <typeparam name="T">型</typeparam>
        /// <returns></returns>
        public static List<T> FindObjectsOfInterfaces<T>() where T : class
        {
            List<T> list = new List<T>();

            foreach (var n in FindObjectsOfType<Component>())
            {
                var component = n as T;

                if (component != null)
                {
                    list.Add(component);
                }
            }

            return list;
        }
    }
}