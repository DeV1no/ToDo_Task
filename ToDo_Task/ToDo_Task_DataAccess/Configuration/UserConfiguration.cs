using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo_Task_DataAccess.Entity;

namespace ToDo_Task_DataAccess.Configuration;

public class UserConfiguration
{
    public UserConfiguration(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.UserName).HasMaxLength(255).IsRequired();
        builder.HasMany(x => x.Tasks).WithOne(x => x.User).HasForeignKey(x=>x.UserId);
    }
}