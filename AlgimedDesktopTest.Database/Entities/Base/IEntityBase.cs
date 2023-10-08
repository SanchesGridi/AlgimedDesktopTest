namespace AlgimedDesktopTest.Database.Entities.Base;

public interface IEntityBase<TAny>
{
    public TAny Id { get; set; }
}