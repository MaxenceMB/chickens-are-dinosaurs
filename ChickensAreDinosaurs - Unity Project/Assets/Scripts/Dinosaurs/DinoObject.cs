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
    [SerializeField] private float movementSpeed;
    [Range(0, 100)][SerializeField] private int health = 50;
    [SerializeField] private bool alreadyDiscovered = false;

    [Header("Dinosaur - Real infos")]
    [SerializeField] private Era livingEra = Era.None;
    [SerializeField] private int eraStart  = -0;
    [SerializeField] private int eraEnd    = -0;
    [Space(20)]
    [SerializeField] private int lifeSpan = 0;
    [Space(20)]
    [SerializeField] private int weight = 0;
    [SerializeField] private int width  = 0;
    [SerializeField] private int height = 0;
    [Space(20)]
    [SerializeField] private Diet diet = Diet.None;


    // ----- Get Functions ----- \\
    public string getName() {
        return this.dinoName;
    }

    public float getSpeed() {
        return this.movementSpeed;
    }

    public int getHealth() {
        return this.health;
    }

    public Era getEra() {
        return this.livingEra;
    }

    public int[] getEraYears() {
        int[] years = {eraStart, eraEnd};
        return years;
    }

    public int getLifespan() {
        return this.lifeSpan;
    }

    public int getWeight() {
        return this.weight;
    }

    public int getWidth() {
        return this.width;
    }

    public int getHeight() {
        return this.height;
    }

    public Diet getDiet() {
        return this.diet;
    }


    // ----- Set Functions ----- \\
    public void setHealth(int newHealth) {
        this.health = newHealth;
    }

}
