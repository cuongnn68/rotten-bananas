using System.Collections;

namespace UserManagerService.Dtos;

public class AuthRP {
    public IEnumerable Claims { get; set; }
}

public class ClaimRP {
    public string Type { get; set; }
    public string Value { get; set; }
}