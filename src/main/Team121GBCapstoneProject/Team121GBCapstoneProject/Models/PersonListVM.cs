namespace Team121GBCapstoneProject.Models;

public class PersonListVM
{
    public string ListKind { get; set; }
    public List<PersonGame> PersonGames { get; set; }
    public PersonListVM(string listKind, List<PersonGame> games)
    {
        ListKind = listKind;
        PersonGames = new List<PersonGame>();
        games.ForEach(g => PersonGames.Add(g));
    }
}