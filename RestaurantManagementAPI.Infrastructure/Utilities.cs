namespace RestaurantManagementAPI.Infrastructure
{
    public static class Utilities
    {
        public const string createUserQuery = @"INSERT INTO ""User"" (ID, FirstName, LastName, EmailAddress, Password, PhoneNumber, Address, Role)
                                VALUES (:ID, :FirstName, :LastName, :EmailAddress, :Password, :PhoneNumber, :Address, :Role)";
        public const string getUserQuery = "SELECT * FROM \"User\" WHERE ID = :userId";
        public const string getUserByEmailQuery = "SELECT * FROM \"User\" WHERE EmailAddress = :EmailAddress";
        public const string UpdateUserQuery = "UPDATE \"User\" SET FirstName = :FirstName, LastName = :LastName, EmailAddress = :EmailAddress, Password = :Password, PhoneNumber = :PhoneNumber, Address = :Address, Role = :Role WHERE ID = :Id";



    }
}
