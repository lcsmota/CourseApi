namespace CourseApi.DTOs;
public class StudentForCreationDTO
{
    public string Nome { get; set; }
    public short Idade { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public int CursoId { get; set; }
}
