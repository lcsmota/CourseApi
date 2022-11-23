namespace CourseApi.DTOs;
public class CourseForCreationDTO
{
    public string Nome { get; set; }
    public string Categoria { get; set; }
    public string OferecidoPor { get; set; }
    public string Descricao { get; set; }
    public string Turno { get; set; }
    public short CargaHoraria { get; set; }
    public string Observacao { get; set; }
    public bool EOnline { get; set; }
}