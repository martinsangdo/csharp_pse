
public class AccountService
{
    private readonly ApplicationDbContext _db;

    public AccountService(ApplicationDbContext db)
    {
        _db = db;
    }

    public int CreateAccount(CreateAccountDto dto)
    {
        var account = new Account
        {
            fullname = dto.fullname,
            email = dto.email,
            hashed_password = dto.hashed_password,
            phone = dto.phone,
            address = dto.address,
            status = dto.status,
            created_at = dto.created_at
        };

        _db.user_account.Add(account);
        return _db.SaveChanges();
    }

    public int CreateNonDuplicatedAccount(CreateAccountDto dto)
    {
        //check if email is duplicated or not
        bool emailExisted = _db.user_account.Any(a => a.email == dto.email);
        if (emailExisted)
            return 0;

        //
        var account = new Account
        {
            fullname = dto.fullname,
            email = dto.email,
            hashed_password = dto.hashed_password,
            phone = dto.phone,
            address = dto.address,
            status = "Active",
            created_at = DateTime.UtcNow
        };

        _db.user_account.Add(account);
        return _db.SaveChanges();
    }
}