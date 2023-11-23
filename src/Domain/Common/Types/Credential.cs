namespace Domain.Common.Types;
/// <summary>
/// An enumeration value of the different types of Credentials
/// earned after finishing a selected program of study.
/// </summary>
public class Credential : SmartEnum<Credential>
{
    /// <summary>
    /// Certificate Credential
    /// </summary>
    /// <remarks>
    /// A Certificate Credential is for short programs that typically last a few
    /// weeks or months, but does not exceed 1 year.
    /// </remarks>
    public static readonly Credential Certificate = new Credential(nameof(Certificate), 1);
    
    /// <summary>
    /// Diploma Credential
    /// </summary>
    /// <remarks>
    /// A Diploma Credential is for programs that typically last a minimum of
    /// one year to 2 years
    /// </remarks>
    public static readonly Credential Diploma = new Credential(nameof(Diploma), 2);
    
    /// <summary>
    /// Undergraduate Credential
    /// </summary>
    /// <remarks>
    /// An Undergraduate Credential is for programs that last a minimum of
    /// 3 or 4 years with a maximum of 5
    /// </remarks>
    public static readonly Credential Undergraduate = new Credential(nameof(Undergraduate), 3);
    
    /// <summary>
    /// Graduate Credential
    /// </summary>
    /// <remarks>
    /// A Graduate Credential is for programs that build upon the Undergraduate Credential
    /// and typically lasts a minimum of 2 years
    /// </remarks>
    public static readonly Credential Graduate = new Credential(nameof(Graduate), 4);
    
    /// <summary>
    /// Parameterized Constructor
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public Credential(string name, int value) : base(name, value)
    {
    }
}