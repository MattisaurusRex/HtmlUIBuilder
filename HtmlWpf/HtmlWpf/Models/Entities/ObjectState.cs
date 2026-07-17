namespace HtmlWpf.Models.Entities
{
    /// <summary>
    /// Change-tracking state for an entity. Replaces the accidental
    /// Microsoft.Web.Administration.ObjectState dependency in the MVC project.
    /// </summary>
    public enum ObjectState
    {
        Unchanged = 0,
        Added,
        Modified,
        Deleted
    }
}
