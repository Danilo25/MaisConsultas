import { listarEspecialidades } from "../api/especialidades.js";
import { definirDisponibilidade } from "../api/disponibilidades.js";
import { adicionarPlaceholder } from "../utils/select.js";

export function init() {
  const espSelect = document.getElementById("especialidade");
  const mensagem = document.getElementById("mensagem");

  // Carrega especialidades
  listarEspecialidades().then(esps => {
    adicionarPlaceholder(espSelect);
    esps.forEach(e => {
      espSelect.appendChild(new Option(e.nome, e.id));
    });
  });

  document.getElementById("formDisponibilidade").addEventListener("submit", async e => {
    e.preventDefault();

    const payload = {
      medico: document.getElementById("medico").value,
      especialidadeId: parseInt(espSelect.value),
      diaSemana: document.getElementById("diaSemana").value,
      horaInicio: document.getElementById("horaInicio").value,
      horaFim: document.getElementById("horaFim").value,
      duracaoConsultaMinutos: parseInt(document.getElementById("duracao").value)
    };

    try {
      await definirDisponibilidade(payload);
      mensagem.textContent = "Disponibilidade registrada com sucesso!";
      mensagem.style.color = "green";
      e.target.reset();
    } catch {
      mensagem.textContent = "Erro ao registrar.";
      mensagem.style.color = "red";
    }
  });
}