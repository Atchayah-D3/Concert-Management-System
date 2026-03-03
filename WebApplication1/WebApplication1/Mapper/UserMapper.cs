using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;

namespace WebApplication1.Mapper
{
    public class UserMapper
    {
        public static User ToEntity(UserReqDto dto)
        {
            return new User
            {
                UserName = dto.UserName,
                HashedPassword = dto.Password,
                Email=dto.Email,
                Role=dto.Role
            };
        }
        public static UserResDto ToResponse(User user)
        {
            return new UserResDto
            {
                UserId=user.UserId,
                UserName = user.UserName,                
                Email=user.Email,
                Role=user.Role
            };
         }
    }
}
