using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GWorld
{
    private static readonly GWorld instance = new GWorld();
    private static WorldStates world;
    private static Queue<GameObject> patients;
    private static Queue<GameObject> treeFarmPlots;
    private static Queue<GameObject> cottonFarmPlots;
    private static Queue<GameObject> toilets;
    private static GameObject barn;
    private static GameObject truck;


    static GWorld()
    {
        world = new WorldStates();
        patients = new Queue<GameObject>();
        treeFarmPlots = new Queue<GameObject>();
        cottonFarmPlots = new Queue<GameObject>();
        toilets = new Queue<GameObject>();

        GameObject[] tfp = GameObject.FindGameObjectsWithTag("WoodFarmPlot");
        foreach (GameObject c in tfp)
            treeFarmPlots.Enqueue(c);
        if (tfp.Length > 0)
            world.ModifyState("freeTreeFarmPlots", tfp.Length);

        GameObject[] cfp = GameObject.FindGameObjectsWithTag("CottonFarmPlot");
        foreach (GameObject o in cfp)
            cottonFarmPlots.Enqueue(o);
        if (cfp.Length > 0)
            world.ModifyState("freeCottonFarmPlots", cfp.Length);

        barn = GameObject.FindGameObjectWithTag("Barn");
        truck = GameObject.FindGameObjectWithTag("Truck");
        Time.timeScale = 5;
    }

    private GWorld()
    {
    }

    public void AddPatient(GameObject p)
    {
        patients.Enqueue(p);
    }
    public GameObject RemovePatient()
    {
        if (patients.Count == 0) return null;
        return patients.Dequeue();
    }
    public void AddTreeFarmPlot(GameObject p)
    {
        treeFarmPlots.Enqueue(p);
    }
    public GameObject RemoveTreeFarmPlot()
    {
        if (treeFarmPlots.Count == 0) return null;
        return treeFarmPlots.Dequeue();
    }

    public void AddCottonFarmPlot(GameObject p)
    {
        cottonFarmPlots.Enqueue(p);
    }
    public GameObject RemoveCottonFarmPlot()
    {
        if (cottonFarmPlots.Count == 0) return null;
        return cottonFarmPlots.Dequeue();
    }

    public GameObject GetBarn() {
        return barn;
    }

    public GameObject GetTruck() {
        return truck;
    }

    public void AddToilet(GameObject p)
    {
        toilets.Enqueue(p);
    }
    public GameObject RemoveToilet()
    {
        if (toilets.Count == 0) return null;
        return toilets.Dequeue();
    }



    public static GWorld Instance
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return world;
    }
}
