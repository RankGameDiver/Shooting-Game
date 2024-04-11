using UnityEngine.U2D.Animation;

public class EnemyAnimation : SpriteLibraryForAnimation
{
    public EnemyAnimation(SpriteResolver spriteResolver, float time) : base(spriteResolver, time)
    {
        SetAnimation("Enemy_Boss", 3);
    }
}
