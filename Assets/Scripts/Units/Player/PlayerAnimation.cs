using UnityEngine.U2D.Animation;

public class PlayerAnimation : SpriteLibraryForAnimation
{
    public PlayerAnimation(SpriteResolver spriteResolver, float timeperFrame) : base(spriteResolver, timeperFrame)
    {

    }

    public void SetDirectionX(float directionX)
    {
        if(directionX > 0)
        {
            SetAnimation("Right", 4);
        }
        else if(directionX < 0)
        {
            SetAnimation("Left", 4);
        }
        else
        {
            SetAnimation("Foward", 4);
        }
    }
}
