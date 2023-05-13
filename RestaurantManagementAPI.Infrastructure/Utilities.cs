namespace RestaurantManagementAPI.Infrastructure
{
    public static class Utilities
    {
        public const string createUserQuery = @"INSERT INTO ""User"" (ID, FirstName, LastName, EmailAddress, Password, PhoneNumber, Address, Role)
                                VALUES (:ID, :FirstName, :LastName, :EmailAddress, :Password, :PhoneNumber, :Address, :Role)";
    }
}
