#pragma strict

var zoom: int = 20;
var normal: int = 60;
var smooth: float = 5;
private var isZoomed = false;

function Start () {

}

function Update () {
    if(Input.GetKeyDown("z")){
        isZoomed = !isZoomed; 
    }


    if(isZoomed == true){
        GetComponent.<Camera>().fieldOfView = Mathf.Lerp(GetComponent.<Camera>().fieldOfView,zoom,Time.deltaTime*smooth);
    }
    else{
        GetComponent.<Camera>().fieldOfView = Mathf.Lerp(GetComponent.<Camera>().fieldOfView,normal,Time.deltaTime*smooth);
    }
}