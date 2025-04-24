namespace TodoSQLite;

public static class Constants
{
    public const string DatabaseFilename = "TodoSQLite.db3";

    public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache |
        //  The file is encrypted until after the user has booted and unlocked the device.
        SQLite.SQLiteOpenFlags.ProtectionCompleteUntilFirstUserAuthentication;
    public static string DatabasePath => 
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
}
