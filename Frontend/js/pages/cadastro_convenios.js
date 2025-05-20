import { cadastrarConvenio } from "../api/convenios.js";

export function init() {
  const form = document.getElementById("formConvenio");
  const mensagem = document.getElementById("mensagem");

  form.addEventListener("submit", async (e) => {
    e.preventDefault();
    const nome = document.getElementById("convenioNome").value.trim();

    if (!nome) {
      mensagem.textContent = "Preencha o nome do convênio.";
      mensagem.style.color = "red";
      return;
    }

    try {
      const data = await cadastrarConvenio(nome);
      mensagem.textContent = `Convênio "${data.nome}" cadastrado com sucesso!`;
      mensagem.style.color = "green";
      form.reset();
    } catch {
      mensagem.textContent = "Erro ao cadastrar.";
      mensagem.style.color = "red";
    }
  });
}