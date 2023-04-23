namespace Team121GBCapstoneProject.ProjectDataBase;

/// <summary>
/// Helper class to hold information we need for users in our project databases.
/// </summary>
public class UserInfoData
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool EmailConfirmed { get; set; } = true;
    public int DalleCreditsCount { get; set; } = 5;
}
public class SeedData
{
    /// <summary>
    /// Data to be used to see the FujiUsers and ASPNetUsers Tables
    /// </summary>
    public static readonly UserInfoData[] UserSeedData = new UserInfoData[]
    {
            new UserInfoData { UserName = "TaliaK", Email = "knott@example.com", FirstName = "Talia", LastName = "Knott" },
            new UserInfoData { UserName = "ZaydenC", Email = "clark@example.com", FirstName = "Zayden", LastName = "Clark", DalleCreditsCount = 0},
            new UserInfoData { UserName = "DavilaH", Email = "hareem@example.com", FirstName = "Hareem", LastName = "Davila" },
            new UserInfoData { UserName = "KrzysztofP", Email = "krzysztof@example.com", FirstName = "Krzysztof", LastName = "Ponce" }
    };
}
