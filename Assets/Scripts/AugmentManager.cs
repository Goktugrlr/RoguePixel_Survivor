using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AugmentManager : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public ShotgunShootController shotgunShootController;
    public RifleShootController rifleShootController;
    public GameObject augmentPanel;
    public Button augment1Button, augment2Button, augment3Button;
    public TMP_Text augment1Text, augment2Text, augment3Text;
    public class Augment {
        public string name;
        public string description;
        public Action action;
        public Augment(string name, string description, Action action) {
            this.name = name;
            this.description = description;
            this.action = action;
        }
    }

    private List<Augment> allAugments;
    private List<Augment> currentAugments;
    // Start is called before the first frame update
    void Start()
    {
        allAugments = new List<Augment> {
            new Augment("Increase Shotgun Damage", "Increases your shotgun's attack damage.", () => shotgunShootController.bulletDamage += 10),
            new Augment("Increase Rifle Damage", "Increases your rifle's attack damage.", () => rifleShootController.bulletDamage += 10),
            new Augment("Increase Speed", "Increases your movement speed.", () => characterMovement.moveSpeed += 1),
            new Augment("Increase Health", "Increases your max health.", () => characterMovement.maxHealth += 20),
        
        };
    }

    public void EndWave () {
        currentAugments = new List<Augment>();
        for (int i = 0; i < 3; i++) {
            Augment augment = allAugments[UnityEngine.Random.Range(0, allAugments.Count)];
            currentAugments.Add(augment);
            Debug.Log(i);
        }
        augment1Button.gameObject.SetActive(true);
        augment2Button.gameObject.SetActive(true);
        augment3Button.gameObject.SetActive(true);
        augment1Text.text = currentAugments[0].name + "\n" + currentAugments[0].description;
        augment2Text.text = currentAugments[1].name + "\n" + currentAugments[1].description;
        augment3Text.text = currentAugments[2].name + "\n" + currentAugments[2].description;
        Debug.Log("End Wave");
    }

    public void SelectAugment1 () {
        ApplyAugment(0);
        augment1Button.gameObject.SetActive(false);
        augment2Button.gameObject.SetActive(false);
        augment3Button.gameObject.SetActive(false);
        Debug.Log("Selected Augment 1");
    }

    public void SelectAugment2 () {
        ApplyAugment(1);
        augment1Button.gameObject.SetActive(false);
        augment2Button.gameObject.SetActive(false);
        augment3Button.gameObject.SetActive(false);
        Debug.Log("Selected Augment 2");
    }

    public void SelectAugment3 () {
        ApplyAugment(2);
        augment1Button.gameObject.SetActive(false);
        augment2Button.gameObject.SetActive(false);
        augment3Button.gameObject.SetActive(false);
        Debug.Log("Selected Augment 3");
    }

    // Update is called once per frame
    public void ApplyAugment(int index)
    {
        Debug.Log(shotgunShootController.bulletDamage);
        Debug.Log(rifleShootController.bulletDamage);
        Debug.Log(characterMovement.moveSpeed);
        currentAugments[index].action();
        Debug.Log(shotgunShootController.bulletDamage);
        Debug.Log(rifleShootController.bulletDamage);
        Debug.Log(characterMovement.moveSpeed);
    }
}
