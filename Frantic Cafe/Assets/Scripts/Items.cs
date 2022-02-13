public enum Items
{
    InstantToastMix,
    Toast,
    Charcoal,
    ToastWithPeanutJam,
    ToastWithStrawberryJam,
    ToastWithPeanutAndStrawberryJam,
    Glass,
    GlassOfWater,
    CoffeeGrounds,
    GlassOfCoffee
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

public class ToastWithPeanutJam : Item
{
    public override Items GetId() { return Items.ToastWithPeanutJam; }
    public override string GetName() { return "Toast With Peanut Jam"; }
    public override string GetResourceName() { return "toastwithpeanutjam"; }
}

public class ToastWithStrawberryJam : Item
{
    public override Items GetId() { return Items.ToastWithStrawberryJam; }
    public override string GetName() { return "Toast With Strawberry Jam"; }
    public override string GetResourceName() { return "toastwithstrawberryjam"; }
}

public class ToastWithPeanutAndStrawberryJam : Item
{
    public override Items GetId() { return Items.ToastWithPeanutAndStrawberryJam; }
    public override string GetName() { return "Toast With Peanut and Strawberry Jam"; }
    public override string GetResourceName() { return "toastwithpeanutandstrawberryjam"; }
}

public class Glass : Item
{
    public override Items GetId() { return Items.Glass; }
    public override string GetName() { return "Glass"; }
    public override string GetResourceName() { return "glass"; }
}

public class GlassOfWater : Item
{
    public override Items GetId() { return Items.GlassOfWater; }
    public override string GetName() { return "Glass Of Water"; }
    public override string GetResourceName() { return "glassofwater"; }
}

public class CoffeeGrounds : Item
{
    public override Items GetId() { return Items.CoffeeGrounds; }
    public override string GetName() { return "Coffee Grounds"; }
    public override string GetResourceName() { return "coffeegrounds"; }
}

public class GlassOfCoffee : Item
{
    public override Items GetId() { return Items.GlassOfCoffee; }
    public override string GetName() { return "Glass Of Coffee"; }
    public override string GetResourceName() { return "glassofcoffee"; }
}