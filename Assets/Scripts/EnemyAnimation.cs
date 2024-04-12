using UnityEngine.U2D.Animation;

public class EnemyAnimation : SpriteLibraryForAnimation
{
    public EnemyAnimation(SpriteResolver spriteResolver, float timeperFrame) : base(spriteResolver, timeperFrame)
    {
        SetAnimation("Enemy_Boss", 3);
    }
}
