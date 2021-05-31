using System.ComponentModel;

namespace AppFiscDf.Application.Model.Enum
{
    public enum RequestSource
    {
        [Description("Listar Agente Econômico")]
        ListOfEconomicAgent = 1,

        [Description("Listar Agente Econômico Externo")]
        ListOfEconomicAgentExternal = 2,

        [Description("Listar Agente de Fiscalização")]
        ListOfInspectionAgent = 3,

        [Description("Listar Documento de Fiscalização")]
        ListOfInspectionDocument = 4,

        [Description("Listar Sequencial")]
        ListOfSequential = 5,

        [Description("Listar UORG")]
        ListOfUorg = 6,

        [Description("Listar NrUf")]
        ListOfNrUf = 7,

        [Description("Listar Atividade")]
        ListOfActivity = 8,

        [Description("Listar Anexo")]
        ListOfAttachment = 9,

        [Description("Listar UF")]
        ListOfUf = 10,

        [Description("Enviar e-mail")]
        SendEmail = 11,

        [Description("Listar Setor de Julgamento do Processo de Inspeção")]
        ListOfJudgmentSector = 12,

        [Description("Salvar Documento de Fiscalização")]
        SaveInspectionDocument = 13,

        [Description("Salvar Anexo")]
        SaveAttachment = 14,

        [Description("Excluir Documento de Fiscalização")]
        DeleteInspectionDocument = 15,

        [Description("Excluir Anexo")]
        DeleteAttachment = 16,

        [Description("Inserir Sequencial")]
        InsertSequential = 17,

        [Description("Excluir Sequencial")]
        DeleteSequential = 18
    }
}