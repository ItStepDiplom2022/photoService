using System.ComponentModel;

namespace PhotoService.BLL.Enums
{
    public enum PhotoServiceExceptions
    {
        [Description("Wrong email or password")]
        WRONG_CREDENTIALS,

        [Description("Your email is not verified")]
        EMAIL_NOT_VERIFIED,

        [Description("This email does not exist")]
        EMAIL_NOT_EXIST,

        [Description("This email is already registered")]
        EMAIL_ALREADY_REGISTERED,

        [Description("This username is already registered")]
        USERNAME_ALREADY_REGISTERED,

        [Description("This email was already verified")]
        EMAIL_ALREADY_VERIFIED,

        [Description("You`ve already added this image to this collection")]
        COLLECTION_ALREADY_CONTAINS_IMAGE,

        [Description("This collection does not exist")]
        COLLECTION_DOES_NOT_EXIST

    }

    public enum SearchResultType
    {
        Author,
        Tag
    }
}
