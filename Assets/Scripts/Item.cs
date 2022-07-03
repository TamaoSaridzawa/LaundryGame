using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
   
    [SerializeField] private float _speed;
    private float _offset = 0.1f;
    private float _offsetItem = 1.4f;
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    public void Move(Transform marshrut)
    {
        gameObject.transform.parent = null;
        StartCoroutine(Imove(marshrut));
    }

    public void WillMove(float offset)
    {
        StartCoroutine(IWillMove(offset));
    }

    public void SetParrent(GameObject parent)
    {
        gameObject.transform.position = parent.GetComponent<Bot>().StartPosition.position;
        gameObject.transform.parent = parent.gameObject.transform;
    }

    public void SetParrentPlayer(GameObject parent)
    {
        gameObject.transform.parent = parent.gameObject.transform;
    }

    private IEnumerator Imove(Transform marshrut)
    {
        while (true)
        {
            if (transform.position.y == marshrut.position.y)
            {
                yield break;
            }
            Debug.Log("–¿¡Œ“¿≈“");
            transform.position = Vector3.MoveTowards(transform.position, marshrut.position, _speed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator IWillMove(float offset)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z), _speed * Time.deltaTime);
        yield return null;
    }

}
