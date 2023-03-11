namespace Team121GBCapstoneProject.Models;

public class PersonListVM
{
    public List<List<PersonList>> PersonLists { get; set; }

    public PersonListVM(List<PersonList> personLists)
    {
        PersonLists = new List<List<PersonList>>();
        var t = personLists.Distinct().ToList();
        // todo: construct 2d list
            // List<PersonList> temp = personLists.Where(l => l.ListKind == i)
            //                                    .ToList();
            // PersonLists.Add(temp);
        
    }
}