namespace RestaurantManagementAPI.Infrastructure
{
    public static class Utilities
    {
        public const string createUserQuery = @"INSERT INTO ""User"" (ID, FirstName, LastName, EmailAddress, Password, PhoneNumber, Address, Role)
                                VALUES (:ID, :FirstName, :LastName, :EmailAddress, :Password, :PhoneNumber, :Address, :Role)";
        public const string getUserQuery = "SELECT * FROM \"User\" WHERE ID = :userId";
        public const string getUserByEmailQuery = "SELECT * FROM \"User\" WHERE EmailAddress = :EmailAddress";
    }
}
