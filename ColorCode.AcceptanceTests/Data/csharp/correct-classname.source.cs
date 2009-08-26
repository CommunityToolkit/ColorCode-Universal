public class IntermediateProject :
        IIntermediateProject,
        IAttributeDeclarationTarget
{
    #region IntermediateProject data members.
    /// <summary>
    /// Data member for <see cref="Classes"/>.
    /// </summary>
    private IClassTypes classes;
    /// <summary>
    /// Data member for <see cref="Delegates"/>.
    /// </summary>
    private IDelegateTypes delegates;
    #endregion
}