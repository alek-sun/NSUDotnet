namespace task4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Builder b = new Builder();
            b.Build();
        }

        /*public enum UserType
        {
            Admin,
            User,
            Unknown
        }
        static class UserExtensions
        {   
            public static string ToFriendlyString(this UserType type)
            {
                if (type.Equals(UserType.Admin))
                {
                    return "Администратор";
                }
                if (type.Equals(UserType.User))
                {
                    return "Пользователь";
                }
                else
                {
                    return "Неизвестный";
                } 
            }
        }
        */
    }
}