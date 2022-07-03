using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Clase7
{
    class MyContext : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Post> posts { get; set; }
        public DbSet<Comentario> comentarios { get; set; }

        //falta REACCIONES y tags

        public MyContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Properties.Resources.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //nombre de la tabla
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios")
                .HasKey(u => u.idUsuario);

            //==================== RELACIONES============================
            //DEFINICIÓN DE LA RELACIÓN ONE TO ONE USUARIO -> DNI
            

            //DEFINICIÓN DE LA RELACIÓN ONE TO MANY USUARIO -> POST
            modelBuilder.Entity<Post>()
            .HasOne(P => P.usuario)
            .WithMany(U => U.posts)
            .HasForeignKey(P => P.idUsuario)
            .OnDelete(DeleteBehavior.Cascade);

            //DEFINICIÓN DE LA RELACIÓN ONE TO MANY Post -> Comentario
            modelBuilder.Entity<Comentario>()
            .HasOne(C => C.post)
            .WithMany(P => P.comentarios)
            .HasForeignKey(P => P.idPost)
            .OnDelete(DeleteBehavior.Cascade);

            //DEFINICIÓN DE LA RELACIÓN ONE TO MANY Post -> Comentario
            modelBuilder.Entity<Comentario>()
            .HasOne(C => C.usuario)
            .WithMany(U => U.comentarios)
            .HasForeignKey(C => C.idUsuario)
            .OnDelete(DeleteBehavior.Cascade);

            //FALTAN LAS RELACIONES DE TAGS Y REACCIONES Y AMIGOS



            //propiedades de los datos
            //faltan del resto de las clases, usuario NO está completa
            modelBuilder.Entity<Usuario>(
                usr =>
                {
                    usr.Property(u => u.nombre).HasColumnType("varchar(50)");
                    usr.Property(u => u.mail).HasColumnType("varchar(512)");
                    usr.Property(u => u.password).HasColumnType("varchar(50)");
                    usr.Property(u => u.esADM).HasColumnType("bit");
                    usr.Property(u => u.bloqueado).HasColumnType("bit");
                });
            //Ignoro, no agrego UsuarioManager a la base de datos
            modelBuilder.Ignore<RedSocial>();
        }
    }
}
