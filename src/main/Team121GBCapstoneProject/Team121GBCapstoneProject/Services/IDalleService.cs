namespace Team121GBCapstoneProject.Services
{
    public interface IDalleService
    {
        public Task<string> GetImages(string prompt);
        public Task<string> SetImageToProfilePicure(string imageURL);
    }
}
