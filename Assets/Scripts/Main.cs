


using System;
using Core;
using Core.ComponentManager;
using Manager;
using UnityEngine;

public partial class Main:MonoBehaviour
{
    private void Awake()
    {
        SystemManager.Initialize();
        EntityManager.Initialize();
        ComponentManager.Initialize();
        
        SystemManager.SetupSystems();
        
        ComponentManager.CollectAllInjector();
        ComponentManager.InjectToEntities();
    }

    private void Update()
    {
        SystemManager.Tick();
    }
}
