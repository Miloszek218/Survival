using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectUsage : MonoBehaviour {


    [Header ("Eat and Drink Objects")]
    public LifeStats stats;
    public GameObject EatPanel;
    public Slider EatSlider;
    public GameObject DrinkPanel;


    [Header ("Punch Objects")]
    public HandInventory inventory;
    public Animator punchAnim;
    public GameObject pickaxeSparks;

    [Header ("Grabbing Objects")]
    public GameObject GrabIcon;
    public SpringJoint joint;
    bool grabbing = false;

    [Header("Generator Objects")]
    public GameObject GeneratorPanel;
    public GameObject RefillPanelGenerator;
    public Slider GenFuelSlider;
    public Text GeneratorStatus;

    [Header("Spotlight Objects")]
    public GameObject SpotlightPanel;
    public Slider SpotDistanceSlider;
    public Text SpotlightStatus;


    [Header ("Other objects")]
    public Camera PlayerCam;













	void Update ()
    {
        RaycastHit hit;
        Ray ray = PlayerCam.ScreenPointToRay(Input.mousePosition);

        if(Input.GetMouseButtonDown(0))
        {
            if (inventory.selected == 0)
            {
                punchAnim.SetTrigger("PunchTorch");
                if (Physics.Raycast(ray, out hit, 4f))
                {
                    if(hit.transform.tag == "AI")
                    {
                        AIController AI = hit.transform.GetComponent<AIController>();
                        AI.Health -= 20f;
                        AI.Agressive = true;
                        AI.PathFinder = false;
                        AI.DetectionRange += 5f;
                    }
                }
            }
            if (inventory.selected == 2)
            {

                punchAnim.SetTrigger("PunchPick");


                if (Physics.Raycast(ray, out hit, 4f))
                {

                    GameObject PickSpark = Instantiate(pickaxeSparks, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(PickSpark, 3f);
                    if(hit.transform.tag == "Mineable")
                    {
                        Mineable mine = hit.transform.GetComponent<Mineable>();

                        mine.Health -= 50f;
                        mine.MineRefresh();
                        mine.Save();

                    }



                    if (hit.transform.tag == "AI")
                    {
                        AIController AI = hit.transform.GetComponent<AIController>();
                        AI.Health -= 50f;
                        AI.Agressive = true;
                        AI.PathFinder = false;
                        AI.DetectionRange += 5f;
                    }
                }
            }
        }
        if(Physics.Raycast(ray, out hit, 2f))
        {
            if(hit.transform.tag == "SpotLight")
            {
                Spotlight spotlight = hit.transform.GetComponent<Spotlight>();
                SpotlightPanel.SetActive(true);
                SpotDistanceSlider.value = spotlight.distance;
                SpotDistanceSlider.maxValue = spotlight.MaxDistance;
                if(spotlight.Toggled == true)
                {
                    SpotlightStatus.text = "Enabled";
                    SpotlightStatus.color = Color.green;
                }
                else
                {
                    if(spotlight.distance > spotlight.MaxDistance)
                    {
                        SpotlightStatus.text = "Out of range";
                        SpotlightStatus.color = Color.red;
                    }
                }

                if(Input.GetKeyDown("e"))
                {
                    spotlight.Toggle();
                    spotlight.Save();
                }
            }
        }


        if(Physics.Raycast(ray, out hit, 2f))
        {
            if(hit.transform.tag == "Eatable" && hit.transform.GetComponent<Eatable>().FoodAmount > 1)
            {
                EatPanel.SetActive(true);
                EatSlider.maxValue = hit.transform.GetComponent<Eatable>().MaxFood;
                EatSlider.value = hit.transform.GetComponent<Eatable>().FoodAmount;
                if (Input.GetKeyDown("e"))
                {
                    if(hit.transform.GetComponent<Eatable>().FoodAmount > 1)
                    {
                        if(stats.Hunger < 950 || stats.Thirst < 950)
                        {
                            stats.Hunger += hit.transform.GetComponent<Eatable>().SaturationAmount;
                            stats.Thirst += hit.transform.GetComponent<Eatable>().WaterAmount;
                            stats.Health += 100;
                            hit.transform.GetComponent<Eatable>().FoodAmount--;
                            hit.transform.GetComponent<Eatable>().Save();
                        }

                        
                    }
                }
            }
        }



        if(Physics.Raycast(ray, out hit, 2f))
        {
            if(hit.transform.tag == "DrinkAble")
            {
                if(hit.transform.GetComponent<WaterDrinkable>().WaterAmount >= 1)
                {
                    DrinkPanel.SetActive(true);
                    if (Input.GetKeyDown("e"))
                    {
                        if(stats.Thirst <= 950)
                        {
                            stats.Thirst += 170;
                            hit.transform.GetComponent<WaterDrinkable>().WaterAmount -= 1;
                            hit.transform.GetComponent<WaterDrinkable>().Save();
                        }

                    }
                }
            }

        }


        if(Physics.Raycast(ray, out hit, 2f))
        {
            if (hit.transform.GetComponent<Rigidbody>() != null)
            {
                GrabIcon.SetActive(true);

                if (Input.GetMouseButton(1))
                {
                    joint.connectedBody = hit.transform.GetComponent<Rigidbody>();
                    grabbing = true;
                }
                if(Input.GetMouseButtonUp(1))
                {
                    joint.connectedBody = null;
                    GrabIcon.SetActive(false);
                    grabbing = false;
                }

            }

        }




        if(Physics.Raycast(ray, out hit))
        {
            if(hit.transform.tag != "SpotLight")
            {
                SpotlightPanel.SetActive(false);
            }
            if(hit.transform.tag != "Generator")
            {
                GeneratorPanel.SetActive(false);
            }
            if (hit.transform.tag != "DrinkAble")
            {
                DrinkPanel.SetActive(false);
            }
            if(hit.transform.tag != "Eatable")
            {
                EatPanel.SetActive(false);
            }

            if (Input.GetMouseButtonUp(1))
            {
                joint.connectedBody = null;
                GrabIcon.SetActive(false);
                grabbing = false;
            }        
            if (hit.transform.GetComponent<Rigidbody>() == null)
            {
                if(grabbing == false)
                {
                    GrabIcon.SetActive(false);
                }

            }
        }


            }



        }