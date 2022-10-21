// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;
{
    DBXContext context = new();

    //Kitaplar kitap = new()
    //{
    //    KitapAD = "Sefiller",
    //    KitapAciklama = new()
    //    { KitapAcciklama = "Değerli bir kitap2" },
    //    KitaplarFıyatOZ = new() { KitapFiyat = 50, KitapStok = 2 }
    //};
    //context.Kitaplar.Add(kitap);
    //context.SaveChanges();


    //SILME IŞLEMI GERCEKLESTIRME
    Kitaplar kitaplar = context.Kitaplar.Include(p => p.KitaplarFıyatOZ).Include(p => p.KitapAciklama).FirstOrDefault(p => p.ID == 3);

    if (kitaplar.KitaplarFıyatOZ.KitapStok == 1)
    {
        context.KitaplarFiyatOZ.Remove(kitaplar.KitaplarFıyatOZ);
        context.Kitaplar.Remove(kitaplar);
        context.KitapAciklama.Remove(kitaplar.KitapAciklama);
        context.SaveChanges();
    }
    else
    {
        kitaplar.KitaplarFıyatOZ.KitapStok -= 1;
        context.SaveChanges();
    }



}


public class Kitaplar
{
    public int ID { get; set; }
    public string KitapAD { get; set; }
    public KitaplarFiyatOZ KitaplarFıyatOZ { get; set; }
    public KitapAciklama KitapAciklama { get; set; }
}
public class KitaplarFiyatOZ
{
    public int ID { get; set; }
    public int KitapFiyat { get; set; }
    public int KitapStok { get; set; }
    public Kitaplar Kitaplar { get; set; }
}
public class KitapAciklama
{
    public int ID { get; set; }
    public string KitapAcciklama { get; set; }
    public Kitaplar Kitaplar { get; set; }
}

public class DBXContext:DbContext
{
    public DbSet<Kitaplar> Kitaplar { get; set; }
    public DbSet<KitapAciklama> KitapAciklama { get; set; }
    public DbSet<KitaplarFiyatOZ> KitaplarFiyatOZ { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDb; Initial Catalog=Kitaplık");

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kitaplar>()
             .HasKey(p => p.ID);

        modelBuilder.Entity<KitapAciklama>()
            .HasKey(p => p.ID);

        modelBuilder.Entity<KitaplarFiyatOZ>()
            .HasKey(p => p.ID);

        modelBuilder.Entity<KitaplarFiyatOZ>()
              .HasOne(p => p.Kitaplar)
              .WithOne(p => p.KitaplarFıyatOZ)
              .HasForeignKey<KitaplarFiyatOZ>(p => p.ID);

        modelBuilder.Entity<KitapAciklama>()
            .HasOne(p=>p.Kitaplar)
            .WithOne(p=>p.KitapAciklama)
            .HasForeignKey<KitapAciklama>(p => p.ID);
    }
}
