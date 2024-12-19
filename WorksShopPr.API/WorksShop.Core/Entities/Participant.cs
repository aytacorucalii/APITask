using WorksShop.Core.Entities.Base;

namespace WorksShop.Core.Entities
{
    public class Participant: BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int WorkShopId { get; set; }
        public WorkShop? workshop { get; set; }

    }
}
