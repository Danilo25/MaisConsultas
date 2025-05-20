const API_BASE = "http://localhost:5000";

export async function registrarAtendimento(agendamentoId, observacoes = "") {
  const response = await fetch(`${API_BASE}/api/atendimentos`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ agendamentoId, observacoes })
  });
  if (!response.ok) throw new Error("Erro ao registrar atendimento");
  return await response.json();
}

export async function listarAtendimentos(filtros = {}) {
  const params = new URLSearchParams(filtros).toString();
  const response = await fetch(`${API_BASE}/api/atendimentos?${params}`);
  if (!response.ok) throw new Error("Erro ao buscar atendimentos");
  return await response.json();
}