using System.ComponentModel;

namespace AppFiscDf.Application.Model.Enum
{
    public enum SuccessAndErrorMessages
    {
        [Description("Incluído com sucesso")]
        SuccessfullyIncluded = 1,

        [Description("Alterado com sucesso")]
        SuccessfullyChanged = 2,

        [Description("Excluído com sucesso")]
        SuccessfullyDeleted = 3,

        [Description("Listado com sucesso")]
        SuccessfullyListed = 4,

        [Description("Salvo com sucesso")]
        SuccessfullySaved = 5,

        [Description("Ocorreu um erro ao inserir")]
        ErrorOccurredWhileInserting = 6,

        [Description("Ocorreu um erro ao alterar")]
        ErrorOccurredWhileChanging = 7,

        [Description("Ocorreu um erro ao excluir")]
        ErrorOccurredWhileDeleting = 8,

        [Description("Ocorreu um erro ao listar")]
        ErrorOccurredWhileListing = 9,

        [Description("Ocorreu um erro ao salvar")]
        ErrorOccurredWhileSaving = 10,

        [Description("Nenhum dado encontrado")]
        NoDateFound = 11,

        [Description("É obrigatório informar ao menos uma informação ou preenchimento está incorreto")]
        IsRequiredForTheFilter = 12,

        [Description("Dado encontrado com sucesso")]
        SuccessfullyFinded = 13,

        [Description("Não é possível excluir um dado que não existe ou que já está sendo utilizado")]
        ErrorOccurredWhileDeletingNoDateFoundOrAlreadyUsed = 14,

        [Description("Referência inicial não pode ser maior que número final ou as duas referências não estão preenchidas ou está incorreta")]
        StartingNumberGreaterThanEndingNumber = 15,

        [Description("E-mail deve ser válido")]
        EmailMustValid = 16,

        [Description("E-mail enviado com sucesso")]
        SuccesssendEMail = 17,

        [Description("Campo não pode ser nulo")]
        FieldCannotNull = 18,

        [Description("Campo não pode ser vazio")]
        FieldCannotEmpty = 19,

        [Description("Campo precisa ser maior que 0 (zero)")]
        FieldMustGreaterThanZero = 20,

        [Description("Campo(s) obrigatório(s)")]
        RequiredField = 21,

        [Description("Campo está abaixo do número mínimo de caracteres")]
        FieldBelowMinimalCharacters = 22,

        [Description("Campo está acima do número máximo de caracteres")]
        FieldAboveMaximalCharacters = 23,

        [Description("Campo deve ter o número correto de caracteres")]
        FieldMustHaveCorrectNumberCharacters = 24,

        [Description("Campo deve ter uma opção selecionada")]
        FieldMustHaveOptionSelected = 25,

        [Description("Data deve ser igual ou maior que a data atual")]
        DateMustEqualOrGreaterThanCurrentDate = 26,

        [Description("Lista não pode ser nulo")]
        ListCannotNull = 27,

        [Description("Não é permitido mais que duas testemunhas")]
        NoMoreThan2WitnessesAreAllowed = 28,

        [Description("Arquivo com extensão inválida")]
        FileExtensionInvalid = 29,

        [Description("Arquivo com tamanho acima do permitido")]
        FileLargerThanAllowed = 30,

        [Description("Não é possível incluir um Documento de Fiscalização com informações iguais a um DF finalizado")]
        ErrorOccurredWhileSavingInspectionDocumentFinished = 31,

        [Description("Documento de Fiscalização informado não existe ou já foi finalizado")]
        ErrorOccurredWhileSavingDeletingInsDocAttachment = 32,

        [Description("O agente de fiscalização já contém este sequencial associado a ele")]
        ErrorOccurredWhileSavingSequentialInspectionAgent = 33,

        [Description("O agente de fiscalização não contém sequencial associado a ele")]
        ErrorOccurredWhileDeletingSequentialInspectionAgent = 34,

        [Description("Não é possível excluir um Documento de Fiscalização finalizado")]
        ErrorOccurredWhileDeletingInspectionDocumentFinished = 35,

        [Description("Só o primeiro fiscal pode excluir um Documento de Fiscalização")]
        ErrorOccurredWhileDeletingInspectionDocumentInspectionSecundary = 36
    }
}