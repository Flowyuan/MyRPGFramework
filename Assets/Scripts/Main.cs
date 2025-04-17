
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Systems.Interface;
using UnityEngine;

public partial class Main:MonoBehaviour
{
    private readonly Type[] _systemCollections =
    {
        typeof(Systems.MotionSystem)
    };
    
    private List<GameObject> _entities;

    private readonly List<ISystem> _systems = new();
    private readonly List<IInitializableSystem> _initializableSystems = new();
    private readonly List<ITickedSystem> _tickedSystems = new();
    
    private void Awake()
    {
        CollectAllEntities();
        CreateAllSystems();
        InitializeSystems();
    }

    private void CollectAllEntities()
    {
        _entities = GameObject.FindGameObjectsWithTag("Entity").ToList();
    }

    private void CreateAllSystems()
    {
        Type initSystemType = typeof(IInitializableSystem);
        Type tickedSystemType = typeof(ITickedSystem);
        foreach (var type in _systemCollections)
        {
            ISystem instance = Activator.CreateInstance(type) as ISystem;
            _systems.Add(instance);
            
            if (initSystemType.IsAssignableFrom(type))
            {
                IInitializableSystem tickedSystem = instance as IInitializableSystem;
                _initializableSystems.Add(tickedSystem);
            }
            
            if (tickedSystemType.IsAssignableFrom(type))
            {
                ITickedSystem tickedSystem = instance as ITickedSystem;
                _tickedSystems.Add(tickedSystem);
            }
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        TickSystems();
    }
    
    private void InitializeSystems()
    {
        foreach (var sys in _initializableSystems)
        {
            sys.Initialize();
        }
    }

    private void TickSystems()
    {
        foreach (var sys in _tickedSystems)
        {
            sys.Tick();
        }
    }
}
