using UnityEngine;

/// <summary>
/// 오브젝트 충돌 감지 스크립트
/// </summary>
public class CollisionListener : MonoBehaviour
{
    private string _myTag;
    private UnitFacade _unitFacade;

    // Collider끼리 충돌이 일어날 때 OnTriggerEnter2D 함수가 유니티에서 호출됨
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Projectile"))
        {
            Bullet bullet =  collider.GetComponent<Bullet>();
            string bulletTag = bullet.GetMyTag();

            if(_myTag != bulletTag)
            {
                // Debug.Log($"_myTag : {_myTag}");
                _unitFacade.OnHit();
            }
        }
    }

    // 초기 설정시 호출되어야 함
    public void Init(UnitFacade unitFacade, string myTag)
    {
        _unitFacade = unitFacade;
        _myTag = myTag;
    }
}
