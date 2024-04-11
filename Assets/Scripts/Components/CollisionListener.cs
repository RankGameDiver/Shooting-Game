using UnityEngine;

public class CollisionListener : MonoBehaviour
{
    private string _myTag;
    private UnitFacade _unitFacade;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Projectile"))
        {
            Bullet bullet =  collider.GetComponent<Bullet>();
            string bulletTag = bullet.GetMyTag();

            if(_myTag != bulletTag)
            {
                Debug.Log($"_myTag : {_myTag}");
                _unitFacade.OnHit();
            }
        }
    }

    public void Init(UnitFacade unitFacade, string myTag)
    {
        _unitFacade = unitFacade;
        _myTag = myTag;
    }
}
