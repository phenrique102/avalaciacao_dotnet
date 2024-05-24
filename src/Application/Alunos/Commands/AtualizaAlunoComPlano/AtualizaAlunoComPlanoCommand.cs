using Application.Interfaces;
using Domain.Alunos;
using Domain.ValueObjects;

namespace Application.Alunos.Commands.AtualizaAlunoComPlano
{
    public class AtualizaAlunoComPlanoCommand(IMapperService mapperService, IAlunoRepository alunoRepository, IPlanoRepository planoRepository) : IAtualizaAlunoComPlanoCommand
    {
        public void Execute(AtualizaAlunoComPlanoInputModel inputModel)
        {
            if (inputModel.IdAluno <= 0)
                throw new ApplicationException("Prop IdAluno é obrigatório");

            if (string.IsNullOrEmpty(inputModel.NoAluno))
                throw new ApplicationException("Prop DsNome é obrigatório");

            if (inputModel.DtNascimento == DateTime.MinValue)
                throw new ApplicationException("Prop DtNascimento é obrigatório");

            if (string.IsNullOrEmpty(inputModel.DsSexo))
                throw new ApplicationException("Prop DsSexo é obrigatório");
            else
            {
                if (!SexoVO.SupportedSexos.Contains(new SexoVO(inputModel.DsSexo)))
                    throw new ApplicationException("Prop DsSexo é inválido");
            }

            if (inputModel.IdPlano == 0)
                throw new ApplicationException("Prop IdPlano é obrigatório");
            else
            {
                if (!planoRepository.ExistePlano(inputModel.IdPlano))
                    throw new ApplicationException("Plano não encontrado");
            }

            var aluno = mapperService.Map<AtualizaAlunoComPlanoInputModel, Aluno>(inputModel);

            alunoRepository.AtualizaAlunoComPlano(aluno);
        }
    }
}
