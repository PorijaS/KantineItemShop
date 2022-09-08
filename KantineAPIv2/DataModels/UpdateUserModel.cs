namespace KantineAPIv2.DataModels
{
    //Model class that has the properties we need in our calls, instead of calling the main entity we will use the model class instead.
    public class UpdateUserModel : UserModel
    {
        public string OldPassword { get; set; }
    }
}
