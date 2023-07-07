namespace DepositoHelados.Domain.Entities.UserAggregate;

public class UserToken : BaseAudit<Guid>
{
    public virtual Guid UserId { get; private set; }
    public virtual string Token { get; private set; } = string.Empty;
    public virtual DateTime TokenExpiredDate { get; private set; } 
    public virtual string RefreshToken { get; private set; } = string.Empty;
    public virtual DateTime RefreshTokenExpiredDate { get; private set; } 

    public void SetUserId(Guid userId) => UserId = userId;
    public void SetToken(string token) => Token = token;
    public void SetTokenExpiredDate(DateTime tokenExpiredDate) => TokenExpiredDate = tokenExpiredDate;
    public void SetRefreshToken(string refreshToken) => RefreshToken = refreshToken;
    public void SetRefreshTokenExpiredDate(DateTime refreshTokenExpiredDate) => RefreshTokenExpiredDate = refreshTokenExpiredDate;
}