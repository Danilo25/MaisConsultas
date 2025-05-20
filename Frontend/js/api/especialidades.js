const API_BASE = "http://localhost:5000"; // ou detectável via ambiente

// Retorna todas as especialidades cadastradas
export async function listarEspecialidades() {
  const response = await fetch(`${API_BASE}/api/especialidades`);
  if (!response.ok) throw new Error("Erro ao buscar especialidades");
  return await response.json();
}

// Cadastra uma nova especialidade
export async function cadastrarEspecialidade(nome) {
  const response = await fetch(`${API_BASE}/api/especialidades`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ nome })
  });
  if (!response.ok) throw new Error("Erro ao cadastrar especialidade");
  return await response.json();
}