namespace Api.Models;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
		
		
		public DbSet<Caso> Caso { get; set; }
		public DbSet<Receta> Receta { get; set; }
		public DbSet<Estudio> Estudio { get; set; }
		public DbSet<Paciente> Paciente { get; set; }
		public DbSet<Patologia> Patologia { get; set; }
		public DbSet<Medicacion> Medicacion { get; set; }
		public DbSet<Prestacion> Prestacion { get; set; }
		public DbSet<Diagnostico> Diagnostico { get; set; }
		public DbSet<Especialidad> Especialidad { get; set; }
		public DbSet<Intervencion> Intervencion { get; set; }
		public DbSet<EspecialidadProfesional> EspecialidadProfesional { get; set; }
		public DbSet<Profesional> Profesional { get; set; }

		
		
	}