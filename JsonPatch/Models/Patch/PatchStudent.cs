namespace JsonPatch.Models.Patch
{
    /// <summary>
    /// A class prefixed w/ "Patch" is one which specifies the Patch contract. 
    /// (these are the only properties that can be operated against)
    /// </summary>
    public class PatchStudent
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string FieldOfStudy { get; set; }
    }
}
