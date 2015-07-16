#pragma strict

var speed = 10;
var crawling = false;
var border=3000;

function Start () {
	crawling = true;
}

function Update ()
{
    if (!crawling)
        return;
    transform.Translate(Vector3.up * Time.deltaTime * speed);
    if (gameObject.transform.position.y > border)
    {
        gameObject.transform.position.y = 0;
    }
}