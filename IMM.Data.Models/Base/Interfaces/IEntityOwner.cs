namespace IMM.Data.Models.Base.Interfaces
{
    using IMM.Models;

    public interface IEntityOwner
    {
        User User { get; set; }

        string UserId { get; set; }
    }
}
