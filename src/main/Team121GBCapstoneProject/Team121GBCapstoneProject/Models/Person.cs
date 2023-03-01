using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Team121GBCapstoneProject.Models;

[Table("Person")]
public partial class Person
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("AuthorizationID")]
    [StringLength(450)]
    public string AuthorizationId { get; set; }

    [Column("RoleID")]
    public int? RoleId { get; set; }

    [Column("CurrentlyPlayingListID")]
    public int? CurrentlyPlayingListId { get; set; }

    [Column("CompletedListID")]
    public int? CompletedListId { get; set; }

    [Column("WantToPlayListID")]
    public int? WantToPlayListId { get; set; }

    [ForeignKey("CompletedListId")]
    [InverseProperty("PersonCompletedLists")]
    public virtual List CompletedList { get; set; }

    [ForeignKey("CurrentlyPlayingListId")]
    [InverseProperty("PersonCurrentlyPlayingLists")]
    public virtual List CurrentlyPlayingList { get; set; }

    [InverseProperty("Person")]
    public virtual ICollection<List> Lists { get; } = new List<List>();

    [ForeignKey("WantToPlayListId")]
    [InverseProperty("PersonWantToPlayLists")]
    public virtual List WantToPlayList { get; set; }
}
