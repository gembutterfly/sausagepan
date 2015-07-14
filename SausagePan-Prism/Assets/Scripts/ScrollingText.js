#pragma strict

var speed = 10;
var crawling = false;

function Start () {
	crawling = true;
}

function Update ()
{
    if (!crawling)
        return;
    transform.Translate(Vector3.up * Time.deltaTime * speed);
    if (gameObject.transform.position.y > 2000)
    {
        gameObject.transform.position.y = 0;
    }
}