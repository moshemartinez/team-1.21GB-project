namespace Team121GBCapstoneProject.Models;

public class PersonListVM
{
    //public List PersonLists { get; set; }
    public string ListKind { get; set; }
    public PersonListVM(string listKind, List<Game> games)
    {
        
    }

    // public PersonListVM(List<PersonList> personLists)
    // {
    //     PersonLists = personLists.OrderBy(l => l.ListKindId)
    //                              .GroupBy(l => l.ListKind)
    //                              .Select(group => group.ToList())
    //                              .ToList();
    //     ListKind = personLists.Select(l => l.ListKind)
    //                           .Distinct()
    //                           .ToList();
    // }
}
// var distinctPeople = personLists.Distinct(p => new { p })
//                                         .ToList();