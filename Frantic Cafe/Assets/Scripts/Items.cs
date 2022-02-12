using UnityEngine;

public abstract class Item
{
    public abstract string GetId();
    public abstract string GetName();
}

public class InstantToast : Item
{
    public override string GetId()
    {
        return "InstantToast";
    }

    public override string GetName()
    {
        return "Instant Toast";
    }
}