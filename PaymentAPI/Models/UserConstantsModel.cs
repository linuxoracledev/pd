namespace PaymentAPI.Models
{
    public class UserConstantsModel
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() {
            UserName ="azad",
            Password ="123456",
            EmailAddress ="azad.ocp@gmail.com",
            RoleName = "Administrator"
            },
            new UserModel() {
            UserName ="khan",
            Password ="123456",
            EmailAddress ="khan@gmail.com",
            RoleName = "User"
            }
        };
    }
}
