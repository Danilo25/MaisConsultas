const API_BASE = "http://localhost:5000"; // ou detectável via ambiente

// Retorna todas as especialidades cadastradas
export async function listarConvenios() {
  const response = await fetch(`${API_BASE}/api/convenios`);
  if (!response.ok) throw new Error("Erro ao buscar os convênios");
  return await response.json();
}

// Cadastra uma nova especialidade
export async function cadastrarConvenio(nome) {
  const response = await fetch(`${API_BASE}/api/convenios`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ nome })
  });
  if (!response.ok) throw new Error("Erro ao cadastrar o convênio");
  return await response.json();
}