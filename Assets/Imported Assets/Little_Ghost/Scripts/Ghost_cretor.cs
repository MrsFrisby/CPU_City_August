using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Ghost_cretor : MonoBehaviour
{
    public enum Objects { Axe, Devil, Hat, No_props }
    public Objects Ghost_props;
    public GameObject[] props_obj;

    public Renderer body1, body2;
    public Material[] my_body_materials;
    [Range(0,14)]
    public int Body_Materials;

    public Renderer Hat_mesh;
    public Material[] My_Hat_materials;
    [Range(0, 2)]
    public int Hat_materials;

    public GameObject[] body_types;
    public enum bodys { Body1, Body2}
    public bodys Body_Type = bodys.Body1;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //body type............//
       if(Body_Type == bodys.Body1)
        {
            body_types[0].SetActive(true);
        }
        else
        {
            body_types[0].SetActive(false);
        }

        if (Body_Type == bodys.Body2)
        {
            body_types[1].SetActive(true);
        }
        else
        {
            body_types[1].SetActive(false);
        }

        //body material..........//
        Hat_mesh.material = My_Hat_materials[Hat_materials];
      

        //body material..........//
        body1.material = my_body_materials[Body_Materials];
        body2.material = my_body_materials[Body_Materials];
        //props..................//
        if (Ghost_props == Objects.No_props)
        {
            props_obj[0].SetActive(false);
            props_obj[1].SetActive(false);
            props_obj[2].SetActive(false);

        }
        if (Ghost_props == Objects.Axe)
        {
            props_obj[0].SetActive(true);
        }
        else
        {
            props_obj[0].SetActive(false);
        }
        if (Ghost_props == Objects.Devil)
        {
            props_obj[1].SetActive(true);
        }
        else
        {
            props_obj[1].SetActive(false);
        }
        if (Ghost_props == Objects.Hat)
        {
            props_obj[2].SetActive(true);
        }
        else
        {
            props_obj[2].SetActive(false);
        }

    }

}
