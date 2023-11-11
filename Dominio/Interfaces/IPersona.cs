
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IPersona : IGenericRepo<Persona>
{
    public Task<IEnumerable<object>> PersonasQSonAlunosOrdenado();
    public Task<IEnumerable<object>> AlumnoSinTelefono();
    public Task<IEnumerable<object>> AlumnoNacidoEn1999();
    public Task<IEnumerable<object>> ProfSinTelYNifEndK();
    public Task<IEnumerable<object>> AlumnasMatriculadoIngSistemasPlan2015();
    public Task<IEnumerable<object>> ProfXDepartamento();
    public Task<object> ProfConOSinDepartamento();
    public Task<IEnumerable<object>> DepartamentoSinProfesoresAsociados(); //consulta 13
    public Task<IEnumerable<object>> ProfesoresSinAsignatura();//consulta 14
    public Task<IEnumerable<object>> AsignaturasSinProfesores(); //consulta 15
    public Task<IEnumerable<object>> AsignaturaQueNoSeHayaImpartido();//consulta 16
    public Task<object> TotalAlumnas();//consulta 17
    public Task<object> TotalAlumnosHombresNac1999(); //consulta 18
    public Task<IEnumerable<object>> ProfEnCadaDepartamento(); //consulta 19
    public Task<IEnumerable<object>> DepartamentoYProfesor();//coinsulta 20
    public Task<IEnumerable<object>> AsignaturaPorProfesor(); //consulta 25
    public Task<object> AlumnoMaJoven(); //consulta 26
    public Task<IEnumerable<object>> ProfesoresSinDepartamentos(); // 27
    public Task<IEnumerable<object>> DepartamentosSinProfesor(); //28
    public Task<IEnumerable<object>> ProfesorConDeptPeroSinAsignatura(); //29
}
