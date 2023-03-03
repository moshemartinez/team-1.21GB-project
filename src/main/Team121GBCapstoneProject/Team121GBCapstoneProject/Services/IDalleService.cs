namespace Team121GBCapstoneProject.Services
{
    public interface IDalleService
    {
        public Task<List<string>> GetImages(string prompt);
    }
}
