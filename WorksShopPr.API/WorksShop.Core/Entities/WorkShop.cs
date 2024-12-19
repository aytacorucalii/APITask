using WorksShop.Core.Entities.Base;

namespace WorksShop.Core.Entities;

public class WorkShop: BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }


    public ICollection<Participant>? Participants { get; set; }
}
