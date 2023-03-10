// <auto-generated />
using IndustrialPremisesRent.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IndustrialPremisesRent.Migrations
{
    [DbContext(typeof(IndustrialPremisesRentContext))]
    partial class IndustrialPremisesRentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IndustrialPremisesRent.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EquipmentAmount")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentTypeCode")
                        .HasColumnType("int");

                    b.Property<int>("IndustrialPremiseCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentTypeCode");

                    b.HasIndex("IndustrialPremiseCode");

                    b.ToTable("Contract", (string)null);
                });

            modelBuilder.Entity("IndustrialPremisesRent.Models.EquipmentType", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Code"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequiredSquare")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.ToTable("EquipmentType", (string)null);
                });

            modelBuilder.Entity("IndustrialPremisesRent.Models.IndustrialPremise", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Code"));

                    b.Property<int>("AvailableSquare")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("IndustrialPremise", (string)null);
                });

            modelBuilder.Entity("IndustrialPremisesRent.Models.Contract", b =>
                {
                    b.HasOne("IndustrialPremisesRent.Models.EquipmentType", "EquipmentType")
                        .WithMany()
                        .HasForeignKey("EquipmentTypeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IndustrialPremisesRent.Models.IndustrialPremise", "IndustrialPremise")
                        .WithMany()
                        .HasForeignKey("IndustrialPremiseCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquipmentType");

                    b.Navigation("IndustrialPremise");
                });
#pragma warning restore 612, 618
        }
    }
}
