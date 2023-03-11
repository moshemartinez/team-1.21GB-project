namespace Team121GBCapstoneProject.Models;

public class PersonListVM
{
    public string ListKind { get; set; }
    public PersonListVM(string listKind, List<PersonGame> games)
    {
        ListKind = listKind;
    }

}
// var distinctPeople = personLists.Distinct(p => new { p })
//                                         .ToList();
    //public List PersonLists { get; set; }
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
