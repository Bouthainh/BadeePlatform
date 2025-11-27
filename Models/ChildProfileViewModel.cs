using System;
using BadeePlatform.Models; 

public class ChildProfileViewModel
{
    public string ChildId { get; set; }
    public string ChildName { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string SchoolName { get; set; } 
    public string LoginCode { get; set; } 
    public bool IsAccessGrantedByParent { get; set; } 
    public string IconImgPath { get; set; }
}