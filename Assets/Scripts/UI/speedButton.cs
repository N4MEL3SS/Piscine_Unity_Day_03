using UnityEngine;

public class speedButton : MonoBehaviour
{
    public gameManager manager;
    
    public void Pause()
    {
        manager.changeSpeed(0);
    }
    
    public void NormalSpeed()
    {
        manager.changeSpeed(1);
    }
    
    public void DoubleSpeed()
    {
        manager.changeSpeed(2);
    }
    
    public void DoubleDoubleSpeed()
    {
        manager.changeSpeed(4);
    }

}
