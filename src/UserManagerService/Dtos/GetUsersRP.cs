namespace UserManagerService.Dtos;

public class GetUsersRP {
    public IEnumerable<UserRP> Users { get; set; }
}