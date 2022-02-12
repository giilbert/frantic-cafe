using UnityEngine;

public enum Items
{
    InstantToastMix,
    Toast,
    Charcoal
}

public abstract class Item
{
    public abstract Items GetId();
    public abstract string GetName();
    public abstract string GetResourceName();
}

public class InstantToastMix : Item
{
    public override Items GetId() { return Items.InstantToastMix; }
    public override string GetName() { return "Instant Toast Mix"; }
    public override string GetResourceName() { return "instanttoastmix"; }
}

public class Toast : Item
{
    public override Items GetId() { return Items.Toast; }
    public override string GetName() { return "Toast"; }
    public override string GetResourceName() { return "toast"; }
}

public class Charcoal : Item
{
    public override Items GetId() { return Items.Charcoal; }
    public override string GetName() { return "Charcoal"; }
    public override string GetResourceName() { return "charcoal"; }
}