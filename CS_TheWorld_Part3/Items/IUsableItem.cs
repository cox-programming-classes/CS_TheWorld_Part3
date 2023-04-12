namespace CS_TheWorld_Part3.Items;

public interface IUsableItem
{
    /// <summary>
    /// A function that takes a target object and returns
    /// the text message that should be printed after this
    /// item is used on that target.
    ///
    /// This may take into account that the target could be
    /// different kinds of things
    /// </summary>
    public Func<object, string>? TargetedAction 
        { get; init; }
    
    /// <summary>
    /// Function that returns the text that should be printed
    /// when this item is used without a target.
    /// </summary>
    public Func<string>? BasicAction 
        { get; init; }
}