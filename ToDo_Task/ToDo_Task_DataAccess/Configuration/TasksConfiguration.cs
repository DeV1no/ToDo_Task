﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo_Task_DataAccess.Entity;

namespace ToDo_Task_DataAccess.Configuration;

public class TasksConfiguration
{
    public TasksConfiguration(EntityTypeBuilder<Tasks> builder)
    {
        builder.HasIndex(x => x.Id);
        builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(1500).IsRequired();
        builder.HasOne(x => x.User).WithMany(x => x.Tasks).HasForeignKey(x=>x.UserId);

    }
}