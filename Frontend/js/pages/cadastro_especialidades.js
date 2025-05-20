import { cadastrarEspecialidade } from "../api/especialidades.js";

export function init() {
  const form = document.getElementById("formEspecialidade");
  const mensagem = document.getElementById("mensagem");

  form.addEventListener("submit", async e => {
    e.preventDefault();
    const nome = document.getElementById("especialidadeNome").value.trim();

    if (!nome) {
      mensagem.textContent = "Informe o nome da especialidade.";
      mensagem.style.color = "red";
      return;
    }

    try {
      const data = await cadastrarEspecialidade(nome);
      mensagem.textContent = `Especialidade "${data.nome}" cadastrada com sucesso!`;
      mensagem.style.color = "green";
      form.reset();
    } catch {
      mensagem.textContent = "Erro ao cadastrar.";
      mensagem.style.color = "red";
    }
  });
}