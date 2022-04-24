using Common.Output;

using Service.System.Auth.Dto;

namespace Service.System.Auth
{
    public interface IAuthService : IService
    {
        IResponseOutput Login(AuthLoginPDto input);
    }
}
