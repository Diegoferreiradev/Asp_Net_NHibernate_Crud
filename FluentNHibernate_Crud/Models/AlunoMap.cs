using FluentNHibernate.Mapping;

namespace FluentNHibernate_Crud.Models
{
    public class AlunoMap : ClassMap<Aluno>
    {
        public AlunoMap()
        {
            Id(x => x.Id);
            Map(x => x.Nome);
            Map(x => x.Email);
            Map(x => x.Curso);
            Map(x => x.Sexo);
            Table("Alunos");
        }
    }
}