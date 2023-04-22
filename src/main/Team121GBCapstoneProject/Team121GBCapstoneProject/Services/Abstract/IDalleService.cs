namespace Team121GBCapstoneProject.Services.Abstract
{
    public interface IDalleService
    {
        public Task<string> GetImages(string prompt);
        public Task<string> SetImageToProfilePicure(string imageURL);
        public Task<string> TurnImageUrlIntoByteArray(string imageURL);
    }
}
