using Microsoft.EntityFrameworkCore;
using Clean2025.Domain.Employees;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Clean2025.Domain.ValueObjects;

namespace Clean2025.Infrastrucrure.Configurations;

public sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employees");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.TCNo).IsUnique();
        builder.Property(x => x.Id).IsRequired()
            .ValueGeneratedNever();
        builder.Property(x => x.FirstName).IsRequired()
            .HasConversion(x=>x.Value,value => new FirstName(value));
        builder.Property(x => x.LastName).IsRequired()
            .HasConversion(ln => ln.Value, value => new LastName(value));
        builder.Property(x=>x.Salary).IsRequired()
            .HasConversion(s => s.Value, value => new Money(value));    
        builder.Property(x=>x.TCNo).IsRequired()
            .HasConversion(tc => tc.Value, value => new TCNo(value));    

        
    }

    
}
