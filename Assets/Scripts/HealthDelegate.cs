using UnityEngine;

public class HealthDelegate
{
    public delegate void EventParam(float amount);
    EventParam myEvent;

    public void BindToEvent(EventParam function)
    {
        myEvent += function;
    }
    public void CallEvent(float param)
    {
        if(myEvent == null)
        {
            return;
        }
        myEvent.Invoke(param);
    }
}
