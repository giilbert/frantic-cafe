using UnityEngine;

public abstract class Item
{
    public abstract string GetId();
    public abstract string GetName();
    public abstract string GetResourceName();
}

public class InstantToastMix : Item
{
    public override string GetId() { return "InstantToastMix"; }
    public override string GetName() { return "Instant Toast Mix"; }
    public override string GetResourceName() { return "instanttoastmix"; }
}