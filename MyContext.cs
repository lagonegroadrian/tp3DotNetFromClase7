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
        public DbSet<Tag> tags { get; set; }
        public DbSet<Reaccion> reacciones { get; set; }

        //Agregadas Reacciones y tags en los DbSet

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

            modelBuilder.Entity<Post>()
                .ToTable("Post")
                .HasKey(p => p.idPost);

            modelBuilder.Entity<Comentario>()
                .ToTable("Comentario")
                .HasKey(c => c.id);

            modelBuilder.Entity<Comentario>()
                .ToTable("Comentario")
                .HasKey(c => c.id);

            modelBuilder.Entity<Tag>()
                .ToTable("tag")
                .HasKey(t => t.id);

            modelBuilder.Entity<Reaccion>()
                .ToTable("reaccion")
                .HasKey(r => r.id);
            modelBuilder.Entity<UsuarioAmigo>()
                .ToTable("usuarioamigo")
                .HasKey(u => u.num_usr);

            modelBuilder.Entity<Reaccion>()
                .ToTable("reaccion")
                .HasKey(r => r.id);

            //==================== RELACIONES============================
            //DEFINICIÓN DE LA RELACIÓN ONE TO ONE USUARIO -> DNI
            /*    modelBuilder.Entity<dni o DNI>()
               .HasOne(P => P.usuario)
               .WithMany(U => U.posts)
               .HasForeignKey(P => P.idUsuario)
               .OnDelete(DeleteBehavior.Cascade);
            */

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
            //DEFINICIÓN DE LA RELACIÓN ONE TO MANY comentario-> tags
            modelBuilder.Entity<Tag>()
            .HasOne(P => P.Comentario)
            .WithMany(U => U.Tags)
            .HasForeignKey(P => P.Comentario)
            .OnDelete(DeleteBehavior.Cascade);

            //DEFINICIÓN DE LA RELACIÓN ONE TO MANY comentario-> reaccion
            modelBuilder.Entity<Reaccion>()
            .HasOne(P => P.Comentario)
            .WithMany(U => U.Reacciones)
            .HasForeignKey(P => P.Comentario)
            .OnDelete(DeleteBehavior.Cascade);


            //relacion many to many usuario ->amigos
            modelBuilder.Entity<UsuarioAmigo>()
                .HasOne(UA => UA.user)
                .WithMany(U => U.misAmigos)
                .HasForeignKey(u => u.num_usr)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UsuarioAmigo>()
                .HasOne(UA => UA.amigo)
                .WithMany(U => U.amigosMios)
                .HasForeignKey(u => u.num_usr2)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UsuarioAmigo>().HasKey(k => new { k.num_usr, k.num_usr2 });

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

            modelBuilder.Entity<Post>(
               usr =>
               {
                   usr.Property(p => p.idPost).HasColumnType("int");
                   usr.Property(p => p.contenido).HasColumnType("varchar(512)");
                   usr.Property(p => p.fecha).HasColumnType("varchar(50)");
                  
               });

            modelBuilder.Entity<Tag>(
              usr =>
              {
                  usr.Property(t => t.id).HasColumnType("int");
                  usr.Property(t => t.palabras).HasColumnType("varchar(512)");
                  

              });

            modelBuilder.Entity<Amigo>(
              usr =>
              {
                  usr.Property(a => a.idAmigo).HasColumnType("int");
                  usr.Property(a => a.nombre).HasColumnType("varchar(512)");
                  usr.Property(a => a.apellido).HasColumnType("varchar(512)");


              });

            modelBuilder.Entity<Comentario>(
              usr =>
              {
                  usr.Property(c => c.id).HasColumnType("int");
                  usr.Property(c => c.contenido).HasColumnType("varchar(512)");
                  usr.Property(c => c.fecha).HasColumnType("varchar(512)");


              });

            modelBuilder.Entity<Reaccion>(
              usr =>
              {
                  usr.Property(r => r.id).HasColumnType("int");
                  usr.Property(r => r.tipo).HasColumnType("varchar(512)");
                  usr.Property(r => r.Comentario).HasColumnType("varchar(512)");


              });
            //Ignoro, no agrego UsuarioManager a la base de datos
            modelBuilder.Ignore<RedSocial>();
        }
    }
}
