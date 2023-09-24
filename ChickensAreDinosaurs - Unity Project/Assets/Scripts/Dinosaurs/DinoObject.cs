using UnityEngine;
using System;

public enum Era  { None, Triassic, Jurassic, Cretaceous }
public enum Diet { None, Carnivore, Herbivore }

[CreateAssetMenu(fileName = "New Dinooooo", menuName = "Special Game Objects/New Dinosaur")]   
public class DinoObject : ScriptableObject {

    [Header("Dinosaur")]
    [SerializeField] private string dinoName;
    [SerializeField] private Sprite sprite;

    [Header("Dinosaur - Game infos")]
    [SerializeField] private bool alreadyDiscovered = false;
    [SerializeField] private int numberDiscovered = 0;

    [Header("Dinosaur - Real infos")]
    [SerializeField] private Era livingEra = Era.None;
    [SerializeField] private string eraYears = "-000M to -000M BC";
    [Space(20)]
    [SerializeField] private string lifeSpan = "000 Years";
    [Space(20)]
    [SerializeField] private string weight = "0kg";
    [SerializeField] private string width  = "0m";
    [SerializeField] private string height = "0m";
    [Space(20)]
    [SerializeField] private Diet diet = Diet.None;


    // ----- Get Functions ----- \\
    public string getName() {
        return this.dinoName;
    }

    public Sprite getSprite() {
        return this.sprite;
    }

    public bool isDiscovered() {
        return this.alreadyDiscovered;
    }

    public int getNumberDiscovered() {
        return this.numberDiscovered;
    }

    public Era getEra() {
        return this.livingEra;
    }

    public string getEraYears() {
        return this.eraYears;
    }

    public string getLifespan() {
        return this.lifeSpan;
    }

    public string getWeight() {
        return this.weight;
    }

    public string getWidth() {
        return this.width;
    }

    public string getHeight() {
        return this.height;
    }

    public Diet getDiet() {
        return this.diet;
    }

}
