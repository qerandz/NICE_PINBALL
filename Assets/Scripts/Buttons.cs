using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    
    [SerializeField] public Buttons Knopochki;
    [SerializeField] public FlippersControl aye;
    [SerializeField] public FlippersControl aye2;
    public static Buttons instance { get; set; }
    private void Start()
    {
        instance = this;
    }
    
    public void startbutton()
    {
        aye.isActive = true;
        aye2.isActive = true;
       
    }    
}
