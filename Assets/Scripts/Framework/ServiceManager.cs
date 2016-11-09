// Marc King - mjking@umich.edu

using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows for the storage and management of service instances.
/// </summary>
public class Services
{
    #region Services Manager

    /// <summary>
    /// Provides methods to manage a collection of services.
    /// </summary>
    /// <returns>An instance of the services manager.</returns>
    public static Services Manager
    {
        get
        {
            // Lazy instantiation
            if (manager == null)
            {
                new Services();
            }
            return manager;
        }
    }
    private static Services manager;

    /// <summary>
    /// Constructor enforces singleton.
    /// </summary>
    public Services()
    {
        if (manager != null)
        {
            Debug.LogError("Cannot have two instances of the services manager.");
            return;
        }
        manager = this;
    }

    #endregion Services Manager

    #region Services Storage

    private Dictionary<Type, object> services = new Dictionary<Type, object>();

    /// <summary>
    /// Adds a service to be managed.
    /// </summary>
    /// <typeparam name="Service">Type of the service to add.</typeparam>
    /// <param name="service">An instance of the service to add.</param>
    public void Add<Service>(Service service) where Service : class
    {
        try
        {
            services.Add(typeof(Service), service);
        }
        catch (ArgumentException e)
        {
            Debug.LogError("Service instance already exists: " + typeof(Service).Name);
            Debug.LogException(e);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Service"></typeparam>
    public void Remove<Service>() where Service : class
    {
        if (services.ContainsKey(typeof(Service)))
        {
            Service instance = Get<Service>();
            services.Remove(typeof(Service));
            if (instance is UnityEngine.Object)
            {
                //UnityEngine.Object.Destroy((UnityEngine.Object)instance);
            }
        }
        else
        {
            Debug.LogError("Service instance not found: " + typeof(Service).Name);
        }
    }

    /// <summary>
    /// Gets an instance to a managed service.
    /// </summary>
    /// <typeparam name="Service">Type of the service to get.</typeparam>
    /// <returns>An instance of the requested service.</returns>
    public Service Get<Service>() where Service : class
    {
        Service service = null;
        try
        {
            service = services[typeof(Service)] as Service;
        }
        catch (KeyNotFoundException e)
        {
            Debug.LogError("Service instance not found: " + typeof(Service).Name);
            Debug.LogException(e);
        }
        return service;
    }

    /// <summary>
    /// Clears all existing services and attempt to destroy related GameObjects.
    /// </summary>
    public void Clear()
    {
        var instances = services.Values;

        Debug.Log("Clearing services from Service Manager.");
        services.Clear();

        foreach (var instance in instances)
        {
            if (instance is UnityEngine.Object)
            {
                UnityEngine.Object.Destroy((UnityEngine.Object)instance);
            }
        }

    }

    #endregion Services Storage
}
