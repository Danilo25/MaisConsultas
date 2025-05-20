export function init() {
  const lista = document.getElementById("listaConsultas");

  fetch("/api/agendamentos")
    .then(res => res.json())
    .then(consultas => {
      if (consultas.length === 0) {
        lista.innerHTML = "<li>Nenhuma consulta agendada para hoje.</li>";
        return;
      }

      consultas.forEach(c => {
        const li = document.createElement("li");
        li.textContent = `${c.dataHora} - ${c.paciente} (${c.especialidadeNome})`;
        lista.appendChild(li);
      });
    })
    .catch(() => {
      lista.innerHTML = "<li>Erro ao buscar consultas.</li>";
    });
}