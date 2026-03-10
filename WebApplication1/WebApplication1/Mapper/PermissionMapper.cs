using WebApplication1.DTO.Response;

namespace WebApplication1.Mapper
{
    public class PermissionMapper
    {
        public static PermissionResDto ToDto(List<Permission> permissions)
        {
            return new PermissionResDto
            {
                Permissions = permissions
            };
        }
    }
}
